using JSTester.JSCommon;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.Float
{
    internal class FloatRunner : JSRunner, IFloat
    {
       

        public FloatRunner(JSRunnerArgs args) : base(args)
        {
        }

        public string Encode(string line)
        {
            WriteInFile(line, Args.InputFilePath);
            StartScript(Args.ScriptType, Args.WorkFilePath, GetArgs(FloatType.Encode)).WaitForExit();
            return ReadFromFile(Args.OutputFilePath);
        }

        public string Decode(string line)
        {
            WriteInFile(line, Args.InputFilePath);
            StartScript(Args.ScriptType, Args.WorkFilePath, GetArgs(FloatType.Decode)).WaitForExit();
            return ReadFromFile(Args.OutputFilePath);
        }


        public string GetArgs(FloatType type)
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath} {(type == FloatType.Decode ? "-d" : "-e")}";
        }
    }
}
