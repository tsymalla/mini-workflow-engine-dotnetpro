using System;

namespace WorkflowEngine.Workflow.Nodes
{
    public class EndNode: ActionNode
    {
        public EndNode(WorkflowContext context, string name) : base(context, name, TYPE.END_NODE)
        {
        }

        public override void Execute()
        {
        }
    }
}