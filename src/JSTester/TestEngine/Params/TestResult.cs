using System;

namespace JSTester.TestEngine.Params
{
    class TestResult
    {
        private static readonly string NewTabLine= "\n" + (char)9;
        public TestResult(bool passed)
        {
            Passed = passed;
        }
        public TestResult(bool passed, string message)
        {
            Passed = passed;
            Message = message;
        }

        public bool Passed { get; }
        public string Message{ get; }

        public string GetResultInfo(string methodName,string CaseName)
        {
            if (Passed)
                return $"Passed{NewTabLine}{methodName} {CaseName??""}\n";
            return $"Failed {NewTabLine}{methodName} {CaseName ?? ""}{NewTabLine}" +
                   $"{String.Join(NewTabLine, Message.Split('\n'))}\n";
        }

        public string GetResultInfo(string methodName)
        {
            return GetResultInfo(methodName, null);
        }

        internal string GetResultInfo(string methodName, string CaseName, object[] arguments)
        {
            if (Passed)
                return $"Passed{NewTabLine}{methodName} {CaseName ?? ""} {arguments}\n";
           
            return $"Failed {NewTabLine}{methodName} {CaseName ?? ""}{NewTabLine}" +
                   $"{String.Join(NewTabLine, Message.Split('\n'))} {arguments}\n";
        }
    }
}
