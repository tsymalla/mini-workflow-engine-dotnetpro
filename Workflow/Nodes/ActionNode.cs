using System.Collections.Generic;

namespace WorkflowEngine.Workflow.Nodes
{
    public abstract class ActionNode: Node
    {
        private ActionNode() : base()
        {
        }

        public ActionNode(WorkflowContext context, string name, TYPE type) : base(context, name, type)
        {
        }

        public abstract void Execute();
    }
}