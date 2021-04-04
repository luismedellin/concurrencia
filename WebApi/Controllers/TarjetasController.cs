using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("tarjetas")]
    public class TarjetasController: ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> ProcesarTarjetas([FromBody] string tarjeta)
        {
            var valorAleatorio = RandomGen.NextDouble();
            var aprobada = valorAleatorio > 0.5;
            await Task.Delay(1000);
            Console.WriteLine($"Tarjeta {tarjeta} procesada-{aprobada}");
            return Ok(new {Tarjeta = tarjeta, Aprobada = aprobada});
        }
    }
}
