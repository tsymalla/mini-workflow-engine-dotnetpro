using System;
using System.Collections.Generic;
using WorkflowEngine.Workflow.Nodes;

namespace WorkflowEngine.Workflow.Transition
{
    public class Transition
    {
        protected readonly WorkflowContext context;

        public ActionNode CurrentNode
        {
            get;
            set;
        }

        public ActionNode NextNode
        {
            get;
            set;
        }
        
        public Func<bool> CanTransition
        {
            get;
            set;
        }

        public Action ActionForward
        {
            get;
            set;
        }
        
        public List<string> Errors
        {
            get;
            set;
        }

        public bool HasErrors
        {
            get
            {
                return Errors != null && Errors.Count > 0;
            }
        }
        
        public Transition(WorkflowContext context)
        {
            this.context = context;
        }

        public void OnEnter()
        {
            this.NextNode.Execute();
        }
        
        public ActionNode Execute()
        {
            if (this.CanTransition != null)
            {
                bool result = this.CanTransition.Invoke();
                if (result)
                {
                    ActionForward?.Invoke();   
                }

                return NextNode;
            }

            return CurrentNode;
        }
    }
}