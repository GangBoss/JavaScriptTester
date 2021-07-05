using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.TextTasks.RLE
{
    internal class RLETests_EscapeEncode<TRle> : IJSTest<TRle>
        where TRle : IRLE
    {
        public static IEnumerable<object> Poems => PoemContainer.AllPoems();

        [JSTest]
        [JSTestCase("One", 1)]
        [JSTestCase("Two", 2)]
        [JSTestCase("Three", 3)]
        [JSTestCase("Four", 4)]
        [JSTestCase("MoreThan Four", 34)]
        [JSTestCase("A lot of", 128)]
        [JSTestCase("Maximum", 255)]
        [JSTestCase("More Than Maximum", 500)]
        [JSTestCase("More Than Maximum", 600)]
        public static void EncodeOnlyEscapeCorrectly(TRle runner, int countOfEscapeSymbols)
        {
            var standardSolution = JSSolver.RLE;
            var escInp = runner.EscapeSymbol;
            var escStd = standardSolution.EscapeSymbol;
            var generatedInp = TextGenerator.MultiplyLines(escInp.ToString(), countOfEscapeSymbols);
            var generatedStd = TextGenerator.MultiplyLines(escStd.ToString(), countOfEscapeSymbols);

            var runnerRes = runner.EscapeEncode(generatedInp);
            var standardResult = standardSolution.EscapeEncode(generatedStd);

            runnerRes.Length.Should().Be(standardResult.Length);
        }

        [JSTest]
        [JSTestCase("First phrase", "Мама мыла раму")]
        [JSTestCase("Second phrase", "Сок съел кот")]
        [JSTestCase("321", "aaabbc")]
        public static void DoNotDestroyPhrases(TRle runner, string line)
        {
            var escInp = runner.EscapeSymbol;
            if (!line.Contains(escInp))
            {
                var runnerRes = runner.EscapeEncode(line);
                runnerRes.Should().Be(line);
            }
        }

        [JSTest]
        [JSTestCase("Without overcount", new[] { "a", "b", "c", "d" }, new[] { 100, 3, 2, 1 })]
        [JSTestCase("With overcount", new[] { "a", "b", "c" }, new[] { 257, 257, 1 })]
        [JSTestCaseSource("On big data", nameof(Poems))]
        public static void EncodeTextCorrectly(TRle runner, string[] letters, int[] counts)
        {
            var standardSolution = JSSolver.RLE;
            var text = TextGenerator.CombineLines(letters, counts);

            var runnerRes = runner.EscapeEncode(text);
            var standardResult = standardSolution.EscapeEncode(text);

            runnerRes.Length.Should().Be(standardResult.Length);
        }

        [JSTest]
        public static void EncodeTextWithEscapeCorrectly(TRle runner)
        {
            var standardSolution = JSSolver.RLE;
            var escInp = runner.EscapeSymbol.ToString();
            var escStd = standardSolution.EscapeSymbol.ToString();

            var textRun = TextGenerator.CombineLines(new[] { "a", escInp, "c" }, new[] { 100, 4, 1 });
            var textStd = TextGenerator.CombineLines(new[] { "a", escStd, "c" }, new[] { 257, 257, 257 });

            var runnerRes = runner.EscapeEncode(textRun);
            var standardResult = standardSolution.EscapeEncode(textStd);

            runnerRes.Length.Should().Be(standardResult.Length);
        }
    }
}
