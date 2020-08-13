

namespace WorkflowEngine.Workflow.Runners
{
    public class SequentialRunner: Runner
    {
        public override void Run()
        {
            foreach (Workflow workflow in workflows)
            {
                RunStep(workflow);
            }
        }
    }
}