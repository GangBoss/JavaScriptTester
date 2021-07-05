using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.SubLineTasks
{
    internal class SubLineTest<TSubLine> : IJSTest<TSubLine>
        where TSubLine : ISublLine
    {
        public static IEnumerable<object[]> Poems => CroppedPoems();
        private static void AssertRunner(TSubLine runner, string text, string subLine)
        {
            var expectedResult = JSSolver.SubLine.FindSubLine(text, subLine);
            var currentResult = runner.FindSubLine(text, subLine);

            currentResult.Should().Be(expectedResult);
        }

        [JSTest]
        [JSTestCase("On beginning", "aaabbba", "aaab")]
        [JSTestCase("On end", "aabbaabc", "bc")]
        [JSTestCase("In center", "aabbaabc", "bd")]
        [JSTestCaseSource("On parts of poems", nameof(Poems))]
        public static void FindSubstringsOnTexts(TSubLine runner, string text,string subLine)
        {
            AssertRunner(runner, text, subLine);
        }

        [JSTest]
        [JSTestCase("", "abcddcdcbea", "adcdee")]
        [JSTestCase("Subline Longer than line", "abcddc", "abcddca")]
        public static void OnZeroInclusion(TSubLine runner, string text, string subLine)
        {
            AssertRunner(runner, text, subLine);
        }

        [JSTest]
        [JSTestCase("Short Line", "abc", "bc")]
        [JSTestCase("Long Line", "abcabdcabcabcd", "abcd")]
        public static void FindMultiplySubstrings(TSubLine runner, string line, string subLine)
        {
            var text = TextGenerator.MultiplyLines(line, 50);

            AssertRunner(runner, text, subLine);
        }
        private static IEnumerable<object[]> CroppedPoems()
        {
            foreach (var poem in PoemContainer.AllPoems())
            {
                foreach (var p in Helper.TextCropper(poem))
                {
                    yield return new object[] { p, p.Substring(0, p.Length / 2) };
                    yield return new object[] { p, p.Substring(p.Length / 3, p.Length * 2 / 3) };
                    yield return new object[] { p, p.Substring(p.Length / 2) };
                    yield return new object[] { p,"не" };
                }
            }
        }
    }
}