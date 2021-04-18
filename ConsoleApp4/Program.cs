using Ensayo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp4
{
    class Program
    {

        static int countManipulations(string s1,
                              string s2)
        {

            int count = 0;

            // store the count of character 
            int[] char_count = new int[26];

            // iterate though the first String 
            // and update count 
            for (int k = 0; k < s1.Length; k++)
            {
                char_count[s1[k] - 'a']++;
            }

            // iterate through the second string 
            // update char_count. 
            // if character is not found in 
            // char_count then increase count 
            for (int i = 0; i < s2.Length; i++)
            {
                if (char_count[s2[i] - 'a']-- <= 0)
                    count++;
            }   

            return count;
        }

        static void countManipulations(string s1)
        {
            s1 = "HOla";
        }

        static void checkMagazine(string[] magazine, string[] note)
        {
            var message = new Hashtable();
            foreach (var word in note)
            {
                if (message.Contains(word))
                {
                    message[word] = Convert.ToInt32(message[word]) + 1;
                }
                else
                {
                    message.Add(word, 1);
                }
            }

            foreach (var word in magazine)
            {
                if (message.Contains(word))
                {
                    var value = Convert.ToInt32(message[word])-1;
                    if (value == 0)
                    {
                        message.Remove(word);
                    }
                    else
                    {
                        message[word] = value;
                    }
                }
            }

            Console.WriteLine(message.Count == 0 ? "Yes" : "No");
        }

        

        static void Main(string[] args)
        {
            var result = MyAnagram.anagramDifference(new string[] { "tea", "tea", "act" }, new string[] { "ate", "toe", "acts" });

            MyAnagram.makeAnagram("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");

            checkMagazine(new string[] { "give", "me", "one", "grand", "today", "night" }, new string[] { "give", "one", "grand", "today" });

            var mensaje = "mundo";
            countManipulations(mensaje);
            Console.WriteLine(mensaje);

            //var a = new List<string>() { "a", "jk", "abb", "mn", "abc" };
            //var b = new List<string>() { "bb", "kj", "bbc", "op", "def" };

            var a = new List<string>() { "tae", "tea", "act"};
            var b = new List<string>() { "ate", "toe", "acts"};

            var result = new List<int>();

            for (int i = 0; i < a.Count(); i++)
            {
                if(a[i].Length != b[i].Length)
                {
                    result.Add(-1);
                }
                else
                {
                    result.Add(countManipulations(a[i], b[i]));
                }
            }
                //countManipulations()


            //int count = 0;

            //for (int i = 0; i < a.Count(); i++)
            //{

            //    if(a[i].Length == b[i].Length)
            //    {


            //        var counter = 0;

            //        for (int j = 0; j < a[i].Length; j++)
            //        {
            //            Console.WriteLine(a[i][j]);

            //            for (int bb = 0; bb < b[i].Length; bb++)
            //            {
            //                if(a[i][j] == b[i][bb])
            //                {

            //                }
            //            }

            //        }



            //    }
            //    else
            //    {
            //        count++;
            //        data.Add(-1);
            //    }
                
            //    Console.WriteLine(".....");

            //}

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
