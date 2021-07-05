using System;
using System.Collections.Generic;
using System.Text;

namespace JSTester.JSCommon.Texts
{
    class TextGenerator
    {
        public static string MultiplyLines(string line, int count)
        {
            var stb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                stb.Append(line);
            }

            return stb.ToString();
        }

        public static string CombineLines(string[] letters, int[] lettersCount)
        {
            var stb = new StringBuilder();
            var count = Math.Min(lettersCount.Length, letters.Length);
            for (int i = 0; i < count; i++)
            {
                stb.Append(MultiplyLines(letters[i], lettersCount[i]));
            }

            return stb.ToString();
        }

        public static IEnumerable<string> AddToBeginningOfEach(IEnumerable<string> collection, string addition)
        {
            foreach (var line in collection)
            {
                yield return $"{addition}{collection}";
            }
        }
    }
}
