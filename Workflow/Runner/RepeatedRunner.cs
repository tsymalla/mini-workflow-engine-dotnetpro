

namespace WorkflowEngine.Workflow.Runner
{
    public class RepeatedRunner: Runner
    {
        private uint times;
        private uint executionCount;

        public RepeatedRunner(uint times)
        {
            this.times = times;
            this.executionCount = 0;
        }

        public override void Run()
        {
            while (executionCount < times)
            {
                foreach (Workflow workflow in workflows)
                {
                    RunStep(workflow);
                }

                ++executionCount;
            }
        }
    }
}