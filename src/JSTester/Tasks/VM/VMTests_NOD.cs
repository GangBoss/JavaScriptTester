using System.Collections.Generic;
using FluentAssertions;
using JSTester.JSCommon;
using JSTester.TestEngine.Attributes;

namespace JSTester.Tasks.VM
{
    internal class VMTest_NOD<VM> : IJSTest<VM>
        where VM:IVM
    {
        [JSTest]
        [JSTestCase("Number with zero", 0, 15)]
        [JSTestCase("Two prime numbers", 3, 5)]
        [JSTestCase("Two composite numbers 1 nod", 9, 15)]
        [JSTestCase("To composite numbers with non 1 nod ", 8, 15)]
        [JSTestCase("Equal composite numbers", 8, 8)]
        [JSTestCase("Two equal prime numbers", 3, 3)]
        public static void OnPositiveNumbers(VM runner,int a,int b)
        {
            var runnerResult = runner.CalculateNod(a, b);
            var standardResult = JSSolver.VM.CalculateNod(a, b);
            runnerResult.Should().Be(standardResult);
        }

        [JSTest]
        [JSTestCase("Number with zero", 0, -15)]
        [JSTestCase("Two prime numbers", 3, -5)]
        [JSTestCase("Two composite numbers 1 nod", -8, -15)]
        [JSTestCase("To composite numbers with non 1 nod ", 9, 15)]
        [JSTestCase("Equal composite numbers", -8,-8)]
        [JSTestCase("Two equal prime numbers", -3, 3)]
        public static void OnNegativeNumbers(VM runner, int a, int b)
        {
            var runnerResult=runner.CalculateNod(a, b);
            var standardResult = JSSolver.VM.CalculateNod(a, b);
            runnerResult.Should().Be(standardResult);
        }
    }
}
