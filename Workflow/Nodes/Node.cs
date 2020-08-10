using System;

namespace WorkflowEngine.Workflow.Nodes
{
    public abstract class Node
    {
        public enum TYPE
        {
            START_NODE,
            END_NODE,
            ACTION_NODE
        };
        
        protected WorkflowContext context;

        public TYPE type
        {
            get;
            set;
        }
        
        public string Name
        {
            get;
            set;
        }

        protected Node()
        {
        }   

        public Node(WorkflowContext context, string name, TYPE type)
        {
            this.context = context;
            Name = name;
        }
    }
}