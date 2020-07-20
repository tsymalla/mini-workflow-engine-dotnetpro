using System;

namespace WorkflowEngine.Workflow.Nodes
{
    public class EndNode: ActionNode
    {
        public EndNode(WorkflowContext context, string name) : base(context, name)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("End of workflow reached.");
        }
    }
}