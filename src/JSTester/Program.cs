using System;
using JSTester.Tasks;
using JSTester.Tasks.VM;
using JSTester.TestEngine;

namespace JSTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var myfirstProg = "const fs = require('fs');\r\nfs.writeFileSync(\"1out.txt\",process.argv);";
            //var jsArgs = new VMArgs(myfirstProg, "", "", 1, ScriptType.JavaScript);
            //var runner = new VMRunner(jsArgs);
            ////runner.StartScript(ScriptType.JavaScript, "F:\\1work.js");

            //runner.CalculateFactorial(1);
            //var tester = new VMTest_Factorial<VMRunner>();
            //Tester.GetResultFromFile(runner, tester);
            //Console.WriteLine("Hello World!");

            var runner = new VMTest_Factorial<IVM>();
            var a = new JSSolver(new VMFG());
            Tester.GetResult(new VMFB(), runner);
        }
    }

    public class VMFG : IVM
    {
        public string CalculateNod(int a, int b)
        {
            throw new NotImplementedException();
        }

        public string CalculateFactorial(int a)
        {
            if (a < 0)
                return "err";
            var res = 1;
            while (a > 0)
            {
                res *= a--;
            }

            return res.ToString();
        }
    }
    public class VMFB : IVM
    {
        public string CalculateNod(int a, int b)
        {
            if (a < 0)
                return "err";
            var res = 1;
            while (a > 0)
            {
                res *= a--;
            }

            return res.ToString();

        }

        public string CalculateFactorial(int a)
        {
            var res = 1;
            while (a < 10 && a > 1)
                res *= a--;
            return res.ToString();
        }
    }
}
