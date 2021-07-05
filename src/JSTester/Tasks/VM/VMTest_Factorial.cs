using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.VM
{
    internal class VMTest_Factorial<VM> : IJSTest<VM>
        where VM : IVM
    {
        public static IEnumerable<object[]> PositiveSequence => Sequence(1);
        public static IEnumerable<object[]> NegativeSequence => Sequence(-1);

        [JSTest]
        [JSTestCase("Zero_ReturnError", 0)]
        [JSTestCaseSource("NegativeSequence_ReturnError", nameof(NegativeSequence))]
        [JSTestCaseSource("PositiveSequence_CalculateFactorial", nameof(PositiveSequence))]

        public static void FactorialTests(VM runner, int a)
        {
            var expectedResult=JSSolver.VM.CalculateFactorial(a);
            var currentResult=runner.CalculateFactorial(a);

                currentResult.Should().Be(expectedResult);
        }


        private static IEnumerable<object[]> Sequence(int multiply)
        {
            for (var i = 1; i < 15; i++)
            {
                yield return new object[] { multiply * i };
            }
        }

    }
}
