using System;
using System.Linq;

namespace PenAndPaper.NUnit.HelpClasses
{
    internal class StringRandomizer
    {
        private static readonly Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string NormalizerString(string name)
        {
            if (name.Contains(string.Empty))
                return RandomString(8);

            name.Replace(@":", "");
            name.Replace(@"\", "");
            name.Replace(@"/", "");
            name.Replace(@"*", "");
            name.Replace(@"?", "");
            name.Replace(@"<", "");
            name.Replace(@">", "");
            name.Replace(@"|", "");

            if (name.Contains(string.Empty))
                return RandomString(8);
            return name;
        }
    }
}
