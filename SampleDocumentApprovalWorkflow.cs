using System;
using WorkflowEngine.Workflow;
using WorkflowEngine.Workflow.Nodes;
using WorkflowEngine.Workflow.Transition;
using static WorkflowEngine.SampleDocumentApprovalWorkflowContext;

namespace WorkflowEngine
{
    public class SampleDocumentApprovalWorkflow: Workflow.Workflow
    {
        private SampleDocumentApprovalWorkflowContext context;
        
        public SampleDocumentApprovalWorkflow() : base()
        {
            this.context = new SampleDocumentApprovalWorkflowContext();
            StartNode = new StartNode(context, "BEGIN");
            StartNode.Successors.Add(item: new Transition(context)
            {
                PreviousNode = null,
                NextNode = new ActivityNode(context, "IN_APPROVAL"),
                CanTransition = () =>
                {
                    var currentContext = context;
                    if (currentContext == null)
                    {
                        return false;
                    }
                    
                    return currentContext.ApprovalState == APPROVAL_STATE.UNAPPROVED;
                },
                ActionForward = () =>
                {
                    Console.WriteLine("Approval worked out.");
                }
            });
        }
    }
}