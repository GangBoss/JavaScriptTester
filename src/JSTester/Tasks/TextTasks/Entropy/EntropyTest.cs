using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.TextTasks.Entropy
{
    internal class EntropyTest<Entropy> : IJSTest<Entropy>
        where Entropy : IEntropy
    {
        public static IEnumerable<object> Poems => PoemContainer.AllPoems();
        private static float precision = 0.01f;
        [JSTest]
        [JSTestCase("First phrase", "Мама мыла раму")]
        [JSTestCase("Second phrase", "Сок съел кот")]
        [JSTestCase("321", "aaabbc")]
        [JSTestCaseSource("On big data", nameof(Poems))]
        public static void OnSimplePhrases(Entropy runner, string text)
        {
            var standardRes = JSSolver.Entropy.Calculate(text);
            var runnerRes = runner.Calculate(text);

            var resultIsParsable = float.TryParse(runnerRes, out var runnerResFloat);
            if (!float.TryParse(standardRes, out var standardResFloat))
                throw new InvalidDataException("Can't parse data from reference model");

            resultIsParsable.Should().Be(true);
            runnerResFloat.Should().BeApproximately(standardResFloat, precision);
        }
    }
}
