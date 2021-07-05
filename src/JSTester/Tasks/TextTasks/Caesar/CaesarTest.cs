using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.TextTasks.Caesar
{
    internal class CaesarTest<TCaesar> : IJSTest<TCaesar>
        where TCaesar : ICaesar
    {
        public static IEnumerable<object[]> Poems => TextOffsetPairs();
        public static IEnumerable<object[]> OverCountPoems => TextOffsetPairsWithOvercount();


        [JSTest]
        [JSTestCase("Phrase mama", "Мама мыла раму", 4)]
        [JSTestCase("Phrase cat", "Сок съел кот", 5)]
        [JSTestCaseSource("On parts of poems", nameof(Poems))]
        [JSTestCaseSource("On parts of poems with over count", nameof(OverCountPoems))]
        public static void EncodeTexts(TCaesar runner, string text, int offset)
        {
            var expectedResult = JSSolver.Caesar.Encode(text, offset);
            var currentResult = runner.Encode(text, offset);

            currentResult.Should().Be(expectedResult);
        }

        [JSTest]
        [JSTestCase("Phrase mama", "Мама мыла раму", 4)]
        [JSTestCase("Phrase cat", "Сок съел кот", 5)]
        [JSTestCaseSource("On parts of poems", nameof(Poems))]
        [JSTestCaseSource("On parts of poems with over count", nameof(OverCountPoems))]
        public static void DecodeTexts(TCaesar runner, string text, int offset)
        {
            var realOffset = offset % text.Length;

            var encodedText = JSSolver.Caesar.Encode(text, offset);

            foreach (var dictionary in Helper.TextCropper(text))
            {
                var currentResult = runner.Decode(text, dictionary);
                if (JSSolver.Caesar.Decode(text, dictionary).Contains(realOffset.ToString()))
                    currentResult.Should().Contain(realOffset.ToString());
            }
        }

        private static IEnumerable<object[]> TextOffsetPairsWithOvercount()
        {
            var offsets = new int[] { 1, 2, 40 };
            for (var i = 1; i < 4; i++)
            {
                foreach (var offset in offsets)
                {
                    foreach (var text in CroppedPoems())
                    {
                        yield return new object[] { text, offset + text.Length * i };
                    }
                }
            }
        }

        private static IEnumerable<object[]> TextOffsetPairs()
        {
            var offsets = new int[] { 1, 2, 3, 6, 7, 9, 10, 11, 40 };
            foreach (var offset in offsets)
            {
                foreach (var text in CroppedPoems())
                {
                    yield return new object[] { text, offset };
                }
            }
        }

        private static IEnumerable<string> CroppedPoems()
        {
            foreach (var poem in PoemContainer.AllPoems())
            {
                foreach (var p in Helper.TextCropper(poem)) yield return p;
            }
        }
    }
}