using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.TextTasks.RLE
{
    internal class RLETests_JumpDecode<TRle> : IJSTest<TRle>
        where TRle : IRLE
    {
        public static IEnumerable<object> Poems => PoemContainer.AllPoems();

        [JSTest]
        [JSTestCase("First phrase", "Мама мыла раму")]
        [JSTestCase("Second phrase", "Сок съел кот")]
        [JSTestCaseSource("On big data", nameof(Poems))]
        public static void DoNotDestroyPhrases(TRle runner, string line)
        {
            var runnerRes = runner.JumpEncode(line);
            var decodedRes = runner.JumpDecode(runnerRes);

            decodedRes.Should().Be(line);
        }

        [JSTest]
        [JSTestCase("Only Repeated Chars", new[] { "a", "b" }, new[] { 10, 127 })]
        [JSTestCase("Text WithLong Line", new[] { "a", "ab", "c" }, new[] { 127, 60, 127 })]
        [JSTestCase("Only Repeated Chars With overcount", new[] { "a", "b" }, new[] { 10, 130 })]
        [JSTestCase("Text WithLong Line With overcount", new[] { "a", "ab", "c" }, new[] { 130, 100, 130 })]
        public static void EncodeTextCorrectly(TRle runner, string[] letters, int[] counts)
        {
            var text = TextGenerator.CombineLines(letters, counts);

            var runnerRes = runner.JumpEncode(text);
            var decodedRes = runner.JumpDecode(runnerRes);

            runnerRes.Should().Be(decodedRes);
        }
    }
}