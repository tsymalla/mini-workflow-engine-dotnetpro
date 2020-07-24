using System.Collections.Generic;

namespace WorkflowEngine.Workflow.Nodes
{
    public class StartNode: ActionNode
    {
        public StartNode(WorkflowContext context, string name) : base(context, name, TYPE.START_NODE)
        {
        }

        public override void Execute()
        {
        }
    }
}