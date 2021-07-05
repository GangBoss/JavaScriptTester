using JSTester.JSCommon;

namespace JSTester.Tasks.VM
{
    internal class VMRunner : JSRunner, IVM
    {
        private string NodPath { get; }
        private string FactorialPath { get; }

        public VMRunner(VMArgs args) : base(args)
        {

            WriteInFile(args.FactorialProgram, args.FactorialPath);
            WriteInFile(args.NodProgram, args.NodPath);
            FactorialPath = args.FactorialPath;
            NodPath = args.NodPath;
        }


        public string CalculateNod(int a, int b)
        {
           return GetResultFromFile($"{a}\n{b}", GetArgs(VMType.NOD));
        }

        public string CalculateFactorial(int a)
        {
            return GetResultFromFile($"{a}", GetArgs(VMType.Factorial));

        }

        public string GetArgs(VMType type)
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath} {(type == VMType.NOD ? NodPath : FactorialPath)}";
        }

    }
}
