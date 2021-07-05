using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.TextTasks.RLE
{
    internal class RLETests_EscapeDecode<TRle> : IJSTest<TRle>
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
            var escInp = runner.EscapeSymbol;
            var text = TextGenerator.MultiplyLines(escInp.ToString(), countOfEscapeSymbols);

            var runnerRes = runner.EscapeEncode(text);
            var decodedRes = runner.EscapeDecode(runnerRes);

            runnerRes.Should().Be(decodedRes);
        }

        [JSTest]
        [JSTestCase("First phrase", "Мама мыла раму")]
        [JSTestCase("Second phrase", "Сок съел кот")]
        [JSTestCase("321", "aaabbc")]
        [JSTestCaseSource("On big data", nameof(Poems))]
        public static void DoNotDestroyPhrases(TRle runner, string text)
        {
            var runnerRes = runner.EscapeEncode(text);
            var decodedRes = runner.EscapeDecode(runnerRes);
         
            decodedRes.Should().Be(text);
        }

        [JSTest]
        [JSTestCase("Without overcount", new[] { "a", "b", "c", "d" }, new[] { 100, 3, 2, 1 })]
        [JSTestCase("With overcount", new[] { "a", "b", "c" }, new[] { 257, 257, 1 })]
        public static void EncodeTextCorrectly(TRle runner, string[] letters, int[] counts)
        {
            var text = TextGenerator.CombineLines(letters, counts);

            var runnerRes = runner.EscapeEncode(text);
            var decodedRes = runner.EscapeDecode(runnerRes);

            runnerRes.Should().Be(decodedRes);
        }
    }
}