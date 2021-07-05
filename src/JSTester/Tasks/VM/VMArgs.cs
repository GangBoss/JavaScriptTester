using System;
using JSTester.TestEngine.Params;

namespace JSTester.Tasks.VM
{
    class VMArgs:JSRunnerArgs
    {
        internal string NodProgram { get; }
        internal string FactorialProgram { get; }
        internal string NodPath=> $"{SessionPrefix}nod.txt";
        internal string FactorialPath=> $"{SessionPrefix}factorial.txt";

        public VMArgs(string inputProgram, string nodProgram, string factorialProgram, Guid session, ScriptType scriptType) 
            : base(inputProgram, session, scriptType)
        {
            NodProgram = nodProgram;
            FactorialProgram = factorialProgram;
        }
    }
}
