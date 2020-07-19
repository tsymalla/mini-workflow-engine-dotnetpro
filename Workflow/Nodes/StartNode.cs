using System.Collections.Generic;

namespace WorkflowEngine.Workflow.Nodes
{
    public class StartNode: ActionNode
    {
        public List<Transition.Transition> Successors
        {
            get;
            set;
        }
        
        public StartNode(WorkflowContext context, string name) : base(context, name)
        {
            this.Successors = new List<Transition.Transition>();
        }

        public override void Execute()
        {
        }
    }
}