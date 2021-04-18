using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class MyAnagram
    {
        public static int[] anagramDifference(string[] a, string[] b)
        {
            if (a.Length != b.Length) return new int[] { -1 };

            var result = new int[3];

            for (int i = 0; i < a.Length; i++)
            {
                var wordA = a[i];
                var wordB = b[i];

                var letters = new Dictionary<char, int>();

            }
            

            return result;
        }

        public static int makeAnagram(string a, string b)
        {
            var letters = new Dictionary<char, int>();
            foreach (var letter in a)
            {
                if (letters.ContainsKey(letter))
                {
                    letters[letter]++;
                }
                else
                {
                    letters.Add(letter, 1);
                }
            }

            foreach (var letter in b)
            {
                if (letters.ContainsKey(letter))
                {
                    letters[letter]--;
                }
                else
                {
                    letters.Add(letter, -1);
                }
            }

            var counter = 0;
            foreach (var letter in letters)
            {
                var dif = Math.Abs(letter.Value);
                counter += dif;
            }

            return counter;
        }
    }
}
