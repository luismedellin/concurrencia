using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class lblNombre : Form
    {
        private static string _apiUrl = "https://localhost:44370";
        private HttpClient client;

        public lblNombre()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void btnIniciarProceso_Click(object sender, EventArgs e)
        {
            loadingGIF.Visible = true;

            //pgProcesamiento.Visible = true;
            var progress = new Progress<int>(ReportarProcesamiento);

            #region Intro
            //await Esperar();
            //var nombre = txtNombre.Text;
            //try
            //{
            //    var saludo = await GetSaludo(nombre);
            //    MessageBox.Show(saludo);
            //}
            //catch (HttpRequestException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //} 
            #endregion

            var tarjetas = await ObtenerTarjetasCredito(25000);
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                await ProcesarTarjetas(tarjetas, progress);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            MessageBox.Show($"Operación finalizada en {stopWatch.ElapsedMilliseconds / 1000} segundos");
            
            loadingGIF.Visible = false;
            //pgProcesamiento.Visible = false;
        }

        private void ReportarProcesamiento(int procesamiento)
        {
            pgProcesamiento.Value = procesamiento;
        }


        private async Task ProcesarTarjetas(List<string> tarjetas, IProgress<int> progress = null)
        {
            using var semaforo = new SemaphoreSlim(4000);
            
            var tareas = new List<Task<HttpResponseMessage>>();

            var indice = 0;

            tareas = tarjetas.Select(async tarjeta => 
            {
                var json = JsonConvert.SerializeObject(tarjeta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await semaforo.WaitAsync();
                try
                {
                    var proceso = await client.PostAsync($"{_apiUrl}/tarjetas", content);
                    indice++;

                    if (progress != null)
                    {
                        var porcentaje = (double)indice / tarjetas.Count;
                        var intValue = (int)Math.Round(porcentaje * 100,0);
                        progress.Report(intValue);
                    }

                    return proceso;
                }
                finally
                {
                    semaforo.Release();
                }
            }).ToList();

            var responses = await Task.WhenAll(tareas);

            var tarjetasRechazadas = new List<string>();

            var time = new Stopwatch();
            time.Start();
            foreach (var response in responses)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                var tarjeta = JsonConvert.DeserializeObject<RespuestaTarjeta>(contenido);
                await Task.Delay(500);
                if (!tarjeta.Aprobada)
                {
                    tarjetasRechazadas.Add(tarjeta.Tarjeta);
                }
            }

            Console.WriteLine($"time: {time.ElapsedMilliseconds /1000} s");

            foreach (var rechazada in tarjetasRechazadas)
            {
                Console.WriteLine(rechazada);
            }

        }

        private async Task<List<string>> ObtenerTarjetasCredito(int cantidad)
        {
            var tarjetas = new List<string>();

            await Task.Run(() => {
                for (int i = 0; i < cantidad; i++)
                {
                    tarjetas.Add(i.ToString().PadLeft(16, '0'));
                }
            });

            return tarjetas;
        }

        private async Task Esperar()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        private async Task<string> GetSaludo(string nombre)
        {
            using (var respuesta = await client.GetAsync($"{_apiUrl}/saludos2/{nombre}"))
            {
                respuesta.EnsureSuccessStatusCode();
                var saludo = await respuesta.Content.ReadAsStringAsync();
                return saludo;
            }
        }
    }
}
