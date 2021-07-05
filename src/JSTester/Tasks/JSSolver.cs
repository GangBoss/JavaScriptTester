using System;
using System.Collections.Generic;
using System.Text;
using JSTester.Tasks.Float;
using JSTester.Tasks.SubLineTasks;
using JSTester.Tasks.TextTasks.Caesar;
using JSTester.Tasks.TextTasks.Entropy;
using JSTester.Tasks.TextTasks.Haffman;
using JSTester.Tasks.TextTasks.RLE;
using JSTester.Tasks.VM;

namespace JSTester.Tasks
{
    //Should be singleton that creates in DI container
    internal class JSSolver
    {
        public static IHaffman Haffman;
        public static IVM VM { get; private set; }
        public static IRLE RLE { get; private set; }
        public static IEntropy Entropy { get; private set; }

        public static IFloat Float { get; private set; }
        public static ICaesar Caesar { get; private set; }
        public static ISublLine SubLine { get; }


        internal JSSolver(IVM vm)
        {
            VM = vm;
        }
    }
}
