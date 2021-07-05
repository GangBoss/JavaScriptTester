using JSTester.JSCommon;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.TextTasks.Entropy
{
    internal class EntropyRunner : JSRunner, IEntropy
    {
       

        public EntropyRunner(JSRunnerArgs args) : base(args)
        {

        }

        public string Calculate(string line)
        {
            WriteInFile(line, Args.InputFilePath);
            StartScript(Args.ScriptType, Args.WorkFilePath, GetArgs()).WaitForExit();
            return ReadFromFile(Args.OutputFilePath);
        }
        public string GetArgs()
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath}";
        }
    }
}
