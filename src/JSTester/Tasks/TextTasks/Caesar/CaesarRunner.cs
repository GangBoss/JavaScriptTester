using JSTester.JSCommon;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.TextTasks.Caesar
{
    internal class CaesarRunner : JSRunner, ICaesar
    {
        private string PathToDictionary { get; }

        public CaesarRunner(JSRunnerArgs args) : base(args)
        {
            PathToDictionary = $"{args.SessionPrefix}dic.txt";
        }

        public string Encode(string line, int offset)
        {
            return GetResultFromFile($"{offset}\n{line}", GetArgs(CaesarType.Encode));
        }

        public string Decode(string line, string dictionary)
        {
            WriteInFile(dictionary, PathToDictionary);
            return GetResultFromFile($"{line}", GetArgs(CaesarType.Decode));
        }

        public string GetArgs(CaesarType type)
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath} {(type == CaesarType.Decode ? $"-d {PathToDictionary}" : "-e")}";
        }
    }
}