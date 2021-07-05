using JSTester.JSCommon;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.RPN
{
    internal class RPNRunner : JSRunner, IRPN
    {

        public RPNRunner(JSRunnerArgs args) : base(args)
        {
        }


        public string GetArgs()
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath}";
        }

        public string AnalyzeNotation(string text)
        {
            return GetResultFromFile(text, GetArgs());
        }
    }
}