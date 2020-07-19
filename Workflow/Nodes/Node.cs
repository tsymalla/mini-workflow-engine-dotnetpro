using WorkflowEngine.Workflow.Runner;

namespace WorkflowEngine.Workflow.Nodes
{
    public abstract class Node
    {
        protected readonly WorkflowContext context;
        
        public string Name
        {
            get;
            set;
        }

        public Activity Activity
        {
            get;
            set;
        }

        public Node(WorkflowContext context, string name)
        {
            this.context = context;
            this.Name = name;
        }
    }
}