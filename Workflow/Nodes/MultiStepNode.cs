using System.Collections.Generic;
using System;

namespace WorkflowEngine.Workflow.Nodes
{
    public abstract class MultiStepNode: ActionNode
    {
        private List<Action<WorkflowContext>> steps;

        public MultiStepNode(WorkflowContext context, string name, TYPE type) : base(context, name, type)
        {
            steps = new List<Action<WorkflowContext>>();
        }

        public void AddStep(Action<WorkflowContext> step)
        {
            steps.Add(step);
        }

        public void AddSteps(List<Action<WorkflowContext>> steps)
        {
            steps.AddRange(steps);
        }

        public override void Execute()
        {
            foreach (Action<WorkflowContext> step in steps)
            {
                step?.Invoke(context);
            }
        }
    }
}