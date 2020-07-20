using System;
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

        public ActionNode CurrentNode
        {
            get;
            set;
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
            
            var firstTransition = CurrentNode.Successors.First(f => f.CanTransition.Invoke());
            if (firstTransition == null)
            {
                Console.WriteLine("Could not execute initial transition.");
                return;
            }
            
            firstTransition.OnEnter();
            CurrentNode = firstTransition.Execute();

            this.Progress();
        }
    }
}