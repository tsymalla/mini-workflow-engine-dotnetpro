using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowEngine.Workflow.Nodes;
using WorkflowEngine.Workflow.Transitions;

namespace WorkflowEngine.Workflow
{
    public class Workflow
    {
        private bool initialized;

        protected WorkflowContext context;

        private StartNode startNode;

        private ActionNode currentNode;

        private List<Transition> transitionPool;

        public Workflow()
        {
            initialized = false;
            transitionPool = new List<Transition>();
        }

        public void Initialize(StartNode startNode)
        {
            this.startNode = startNode;
            currentNode = startNode;
            initialized = true;
        }

        public void Reset()
        {
            context.Reset();
            currentNode = startNode;
        }
        
        public void Progress()
        {
            if (!initialized)
            {
                throw new Exception("Workflow was not yet initialized.");
            }

            if (currentNode == null)
            {
                throw new ArgumentNullException("Current node not defined.");
            }

            if (currentNode is EndNode)
            {
                currentNode.Execute();
                return;
            }
            
            var firstTransition = transitionPool.FirstOrDefault(f => f.NodeFrom.Equals(currentNode) && f.CanTransition.Invoke());
            if (firstTransition != null)
            {
                currentNode = firstTransition.Execute();
            }
            
            if (currentNode != null)
            {
                currentNode.Execute();
            }

            Progress();
        }

        public void AddTransition(ActionNode nodeFrom, ActionNode nodeTo, Func<bool> condition, Action transitionAction)
        {
            if (nodeFrom == null || nodeTo == null)
            {
                throw new ArgumentNullException("Must define a start and an end node.");
            }

            if (nodeFrom.Equals(nodeTo))
            {
                throw new Exception("Start node cannot equal end node.");
            }

            // Does not prevent the user from creating circular dependencies.
            transitionPool.Add(new Transition(context)
            {
                NodeFrom = nodeFrom,
                NodeTo = nodeTo,
                CanTransition = condition,
                ActionForward = transitionAction
            });
        }
    }
}