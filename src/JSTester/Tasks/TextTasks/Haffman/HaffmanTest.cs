using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.TextTasks.Haffman
{
    internal class HaffmanTest<THaffman> : IJSTest<THaffman>
        where THaffman : IHaffman
    {
        public static IEnumerable<object> Poems => CroppedPoems();


        [JSTest]
        [JSTestCase("Phrase mama", "Мама мыла раму", 4)]
        [JSTestCase("Phrase cat", "Сок съел кот", 5)]
        [JSTestCaseSource("On parts of poems", nameof(Poems))]
        public static void EncodeTexts(THaffman runner, string text)
        {
            var expectedResult = JSSolver.Haffman.Encode(text).text;
            var currentResult = runner.Encode(text).text;

            currentResult.Length.Should().Be(expectedResult.Length);
        }

        [JSTest]
        [JSTestCase("Phrase mama", "Мама мыла раму", 4)]
        [JSTestCase("Phrase cat", "Сок съел кот", 5)]
        [JSTestCaseSource("On parts of poems", nameof(Poems))]
        public static void DecodeTexts(THaffman runner, string text)
        {
                var encoded = runner.Encode(text);
                var decoded = runner.Decode(encoded.text, encoded.dictionary);
                    decoded.Should().Be(text);
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