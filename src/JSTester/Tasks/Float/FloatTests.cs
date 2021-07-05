using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.JSCommon.Texts;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.Float
{
    internal class FloatTests<Float> : IJSTest<Float>
        where Float : IFloat
    {

        public static IEnumerable<object> PositiveNumbers => TestNumbers();
        public static IEnumerable<object> NegativeNumbers => TextGenerator.AddToBeginningOfEach(TestNumbers(), "-");

        [JSTest]
        [JSTestCaseSource("Positive", nameof(PositiveNumbers))]
        [JSTestCaseSource("Negative", nameof(NegativeNumbers))]
        public static void NumbersEncode(Float runner, string number)
        {
            var standardRunner = JSSolver.Float;

            var runnerEnc = runner.Encode(number);
            var standardEnc = standardRunner.Encode(number);

            runnerEnc.Should().Be(standardEnc);
        }

        [JSTest]
        [JSTestCaseSource("Positive", nameof(PositiveNumbers))]
        [JSTestCaseSource("Negative", nameof(NegativeNumbers))]
        public static void NumbersDecode(Float runner, string number)
        {
            var standardRunner = JSSolver.Float;

            var runnerEnc = runner.Encode(number);
            var standardEnc = standardRunner.Encode(number);
            var runnerDec = runner.Decode(runnerEnc);
            var standardDec = standardRunner.Decode(standardEnc);

            runnerDec.Should().Be(standardDec);
        }


        [JSTest]
        [JSTestCase("Plus Zero", "00000000000000000000000000000000")]
        [JSTestCase("Minus Zero", "00000000000000000000000000000000")]
        [JSTestCase("Plus Inf", "01111111100000000000000000000000")]
        [JSTestCase("Minus Inf", "11111111100000000000000000000000")]
        [JSTestCase("Not A Number", "01111111100000000000000000000001")]
        public static void ConstantsDecode(Float runner, string number)
        {
            var standardRunner = JSSolver.Float;

            var runnerResult = runner.Decode(number);
            var standardResult = standardRunner.Decode(number);

            runnerResult.Should().Be(standardResult);
        }

        [JSTest]
        [JSTestCase("Plus Zero", "00000000000000000000000000000000")]
        [JSTestCase("Minus Zero", "00000000000000000000000000000000")]
        [JSTestCase("Plus Inf", "01111111100000000000000000000000")]
        [JSTestCase("Minus Inf", "11111111100000000000000000000000")]
        [JSTestCase("Not A Number", "01111111100000000000000000000001")]
        public static void ConstantsEncode(Float runner, string number)
        {
            var standardRunner = JSSolver.Float;

            var runnerDec = runner.Decode(number);
            var standardDec = standardRunner.Decode(number);
            var runnerEnc = runner.Encode(runnerDec);
            var standardEnc = standardRunner.Encode(standardDec);

            runnerEnc.Should().Be(standardEnc);
        }

        private static IEnumerable<string> TestNumbers()
        {
            return new[]
            {
                "0.0000000000000000000000000000000001",
                "340282326356119256160033759537265639424",
                "0.0000019",
                "9999999.001",
                "123.1",
                "0.111",
                "0.0000001",
                "0.000",
                "0.",
                "123"
            };
        }

    }
}
