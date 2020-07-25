

namespace WorkflowEngine.Workflow.Runner
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