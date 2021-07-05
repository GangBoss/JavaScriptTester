using JSTester.TestEngine.Params;

namespace JSTester.Tasks.SubLineTasks.BruteForce
{
    internal class SubBruteRunner
    {
        public ISublLine Hash { get; }
        public ISublLine Brute { get; }

        public SubBruteRunner(JSRunnerArgs args)
        {
            Hash = new HashRunner(args);
            Brute=new BruteForceRunner(args);
        }
    }
}