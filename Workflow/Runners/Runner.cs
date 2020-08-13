using System.Collections.Generic;

namespace WorkflowEngine.Workflow.Runners
{
    public abstract class Runner
    {
        protected List<Workflow> workflows;

        public Runner()
        {
            workflows = new List<Workflow>();
        }

        public void AddWorkflow(Workflow workflow)
        {
            workflows.Add(workflow);
        }

        public void AddWorkflows(List<Workflow> workflows)
        {
            workflows.AddRange(workflows);
        }

        public abstract void Run();

        public void RunStep(Workflow workflow)
        {
            workflow.Progress();
        }
    }
}