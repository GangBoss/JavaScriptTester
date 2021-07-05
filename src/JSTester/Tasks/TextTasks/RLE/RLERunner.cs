using System.Collections.Concurrent;
using JSTester.JSCommon;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.TextTasks.RLE
{
    internal class RLERunner : JSRunner, IRLE
    {

        public char EscapeSymbol { get; }


        public RLERunner(JSRunnerArgs args) : base(args)
        {
            EscapeSymbol = FindEscapeChar();
        }

        private char FindEscapeChar()
        {
            var textWithEscape = EscapeEncode("a");
            return textWithEscape[0];

        }

        public string EscapeEncode(string line)
        {
            return GetResultFromFile(line, GetArgs(RLEType.EscapeEncode));
        }

        public string EscapeDecode(string line)
        {
            return GetResultFromFile(line, GetArgs(RLEType.EscapeDecode));
        }

        public string JumpEncode(string line)
        {
            return GetResultFromFile(line, GetArgs(RLEType.JumpEncode));
        }

        public string JumpDecode(string line)
        {
            return GetResultFromFile(line, GetArgs(RLEType.JumpDecode));
        }

        private static ConcurrentDictionary<RLEType, string> commandArguments = new ConcurrentDictionary<RLEType, string>()
        {
            [RLEType.EscapeEncode] = "ee",
            [RLEType.EscapeDecode] = "ed",
            [RLEType.JumpEncode] = "je",
            [RLEType.JumpDecode] = "jd",
        };
        public string GetArgs(RLEType type)
        {
            return $"{Args.InputFilePath} {Args.OutputFilePath} {commandArguments[type]}";
        }
    }
}
