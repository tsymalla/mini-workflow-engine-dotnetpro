using System;

namespace WorkflowEngine.Workflow.Runner
{
    public abstract class Activity
    {
        protected WorkflowContext context;
        
        public Activity(WorkflowContext context)
        {
            this.context = context;
        }

        public abstract Action<bool> Execute();
    }
}