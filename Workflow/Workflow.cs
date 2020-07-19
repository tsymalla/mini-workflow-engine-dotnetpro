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

        public StartNode StartNode
        {
            get;
            set;
        }

        public void Progress()
        {
            if (StartNode == null)
            {
                throw new ArgumentNullException("Start node not defined.");
            }
            
            var firstTransition = StartNode.Successors.First(f => f.CanTransition.Invoke());
            if (firstTransition == null)
            {
                Console.WriteLine("Could not execute initial transition.");
                return;
            }
            
            firstTransition.Execute();
        }
    }
}