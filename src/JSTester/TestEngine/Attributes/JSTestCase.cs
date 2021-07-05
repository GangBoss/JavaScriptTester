using System;

namespace JSTester.TestEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    class JSTestCase : Attribute
    {
        public string Name { get; }
        public object[] Arguments { get; }

        public JSTestCase(string name, params object[] arguments)
        {
            Arguments = arguments;
            Name = name;
        }
    }
}
