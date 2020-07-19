using System;
using WorkflowEngine.Workflow.Nodes;

namespace WorkflowEngine
{
    class Program
    {
        private class SampleWorkflowContext: Workflow.WorkflowContext
        {
            public enum APPROVAL_STATE
            {
                UNAPPROVED,
                IN_PROGRESS,
                APPROVED
            };
            
            public APPROVAL_STATE ApprovalState { get; set; }

            public SampleWorkflowContext()
            {
                ApprovalState = APPROVAL_STATE.UNAPPROVED;
            }
        }
        static void Main(string[] args)
        {
            SampleWorkflowContext context = new SampleWorkflowContext();
            StartNode startNode = new StartNode(context, "Start");

            Workflow.Workflow wf = new Workflow.Workflow(startNode);
            WorkflowEngine.Workflow.WorkflowEngine.Execute(wf);
        }
    }
}
