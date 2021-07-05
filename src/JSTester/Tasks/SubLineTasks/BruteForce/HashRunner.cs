using JSTester.JSCommon;
using JSTester.Tasks.TextTasks.Caesar;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.SubLineTasks.BruteForce
{
    internal class HashRunner : JSRunner, ISublLine

    {
        private string PathToSubLine { get; }

        public HashRunner(JSRunnerArgs args) : base(args)
        {
            PathToSubLine = $"{args.SessionPrefix}sub.txt";
        }

        public string GetArgs(CaesarType type)
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath} {PathToSubLine} -h";
        }

        public string FindSubLine(string text, string subLine)
        {
            WriteInFile(subLine, PathToSubLine);
            return GetResultFromFile($"{text}", GetArgs(CaesarType.Decode));
        }
    }
}