using System;
using System.Collections.Generic;
using WorkflowEngine.Workflow.Nodes;

namespace WorkflowEngine.Workflow.Transition
{
    public abstract class Transition
    {
        protected readonly WorkflowContext context;

        public Node CurrentNode
        {
            get;
            set;
        }

        public Node PreviousNode
        {
            get;
            set;
        }

        public Node NextNode
        {
            get;
            set;
        }
        
        Transition(WorkflowContext context)
        {
            this.context = context;
        }
        
        public abstract Func<bool> CanTransition();
        public abstract Action<bool> ActionForward();
        public abstract Action<bool> ActionBackward();
        public abstract List<string> Errors();
    }
}