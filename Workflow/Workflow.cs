using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowEngine.Workflow.Nodes;

namespace WorkflowEngine.Workflow
{
    public class Workflow
    {
        public enum STATE
        {
            NOT_RUNNING,
            RUNNING,
            ON_HOLD,
            FINISHED
        };

        private STATE state = STATE.NOT_RUNNING;

        protected WorkflowContext context;

        private List<Node> nodePool;

        public ActionNode CurrentNode
        {
            get;
            set;
        }

        public List<Transition.Transition> Transitions
        {
            get;
            set;
        }

        public Workflow()
        {
            nodePool = new List<Node>();
            Transitions = new List<Transition.Transition>();
        }
        
        public void Progress()
        {
            if (CurrentNode == null)
            {
                throw new ArgumentNullException("Current node not defined.");
            }

            if (CurrentNode is EndNode)
            {
                this.state = STATE.FINISHED;
                return;
            }
            
            var firstTransition = Transitions.FirstOrDefault(f => f.NodeFrom.Equals(CurrentNode) && f.CanTransition.Invoke());
            if (firstTransition != null)
            {
                firstTransition.OnEnter();
                CurrentNode = firstTransition.Execute();
            }
            
            if (CurrentNode != null)
            {
                CurrentNode.Execute();
            }

            Progress();
        }
    }
}