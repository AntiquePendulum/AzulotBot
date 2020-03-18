using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzulotBot.Models
{
    public class Gacha
    {
        public static string[] Emoji =
        {
            "S_tom1",
            "S_tukasa1",
            "S_tanya1",
            "S_azumi1",
            "S_kazuma2",
            "S_kuwano1",
            "S_haruki2"
        };

        //もうちょっとどうにかいい感じにしたいところ
        public (string x, string y, string z) Execute() => (RandomElementAt(Emoji), RandomElementAt(Emoji), RandomElementAt(Emoji));


        private static readonly Random Rand = new Random();
        private static T RandomElementAt<T>(IEnumerable<T> ie)
        {
            var enumerable = ie as T[] ?? ie.ToArray();
            return enumerable.ElementAt(Rand.Next(enumerable.Count()));
        }
    }
}
