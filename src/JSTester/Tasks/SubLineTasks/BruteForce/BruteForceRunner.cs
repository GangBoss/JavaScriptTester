using JSTester.JSCommon;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.SubLineTasks.BruteForce
{
    internal class BruteForceRunner : JSRunner, ISublLine
    {
        public string PathToSubLine { get; }

        public BruteForceRunner(JSRunnerArgs args) : base(args)
        {
            PathToSubLine = $"{args.SessionPrefix}sub.txt";
        }


        public string GetArgs()
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath} {PathToSubLine} -b";
        }

        public string FindSubLine(string text, string subLine)
        {
            WriteInFile(subLine, PathToSubLine);
            return GetResultFromFile(text, GetArgs());
        }
    }
}