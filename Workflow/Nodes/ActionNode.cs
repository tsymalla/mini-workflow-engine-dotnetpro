using System.Collections.Generic;

namespace WorkflowEngine.Workflow.Nodes
{
    public abstract class ActionNode: Node
    {
        public ActionNode Predecessor
        {
            get;
            set;
        }

        public List<Transition.Transition> Successors
        {
            get;
            set;
        }

        public ActionNode(WorkflowContext context, string name) : base(context, name)
        {
            this.Successors = new List<Transition.Transition>();
        }

        public abstract void Execute();
    }
}