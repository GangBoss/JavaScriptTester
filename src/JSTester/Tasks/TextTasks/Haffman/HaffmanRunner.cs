using JSTester.JSCommon;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.TextTasks.Haffman
{
    internal class HaffmanRunner : JSRunner, IHaffman
    {
        private string PathToDictionary { get; }

        public HaffmanRunner(JSRunnerArgs args) : base(args)
        {
            PathToDictionary = $"{args.SessionPrefix}dic.txt";
        }

        public (string text, string dictionary) Encode(string line)
        {
            var res = GetResultFromFile($"{line}", GetArgs(HaffmanType.Encode));
            var dict = ReadFromFile(PathToDictionary);
            return (res,dict);
        }

        public string Decode(string line, string dictionary)
        {
            WriteInFile(dictionary, PathToDictionary);
            return GetResultFromFile($"{line}", GetArgs(HaffmanType.Decode));
        }

        public string GetArgs(HaffmanType type)
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath} {PathToDictionary} {(type == HaffmanType.Decode ? "-d" : "-e")}";
        }
    }
}