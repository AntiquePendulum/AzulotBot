using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzulotBot.Models
{
    public static class Gacha
    {
        public static string[] Emoji =
        {
            "<:S_tom1:687991031744299017>",
            "<:S_tukasa1:683084728533778449>",
            "<:S_tanya1:683084337087774726>"
        };

        //もうちょっとどうにかいい感じにしたいところ
        public static (string x, string y, string z) Execute() => (RandomElementAt(Emoji), RandomElementAt(Emoji), RandomElementAt(Emoji));


        private static readonly Random Rand = new Random();
        private static T RandomElementAt<T>(IEnumerable<T> ie)
        {
            var enumerable = ie as T[] ?? ie.ToArray();
            return enumerable.ElementAt(Rand.Next(enumerable.Count()));
        }
    }
}
