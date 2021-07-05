using System;

namespace JSTester.TestEngine.Params
{
    /// <summary>
    /// Arguments for starting an script
    /// </summary>
    class JSRunnerArgs
    {
        internal static readonly string WorkFolder = "f:\\jsTester\\";
        internal  string InputProgram { get; }
        internal Guid Session { get; }
        internal ScriptType ScriptType { get; }
        internal string SessionPrefix=> $"{WorkFolder}{Session}";
        internal string WorkFilePath => $"{SessionPrefix}work.js";
        internal string InputFilePath => $"{SessionPrefix}in.txt";
        internal string OutputFilePath => $"{SessionPrefix}out.txt";

        public JSRunnerArgs(string inputProgram, Guid session, ScriptType scriptType)
        {
            InputProgram = inputProgram;
            Session = session;
            ScriptType = scriptType;
        }
    }
}