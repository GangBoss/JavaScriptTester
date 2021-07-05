using System;

namespace JSTester.TestEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    class JSTestCaseSource : Attribute
    {
        public string ParamName { get; }

        public string Name { get; }

        public JSTestCaseSource(string name, string paramName)
        {
            ParamName = paramName;
            Name = name;
        }
    }
}
