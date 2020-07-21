using System;
using WorkflowEngine.Workflow;
using WorkflowEngine.Workflow.Nodes;
using WorkflowEngine.Workflow.Transition;
using static WorkflowEngine.SampleDocumentApprovalWorkflowContext;

namespace WorkflowEngine
{
    public class SampleDocumentApprovalWorkflow: Workflow.Workflow
    {
        class DoApprovalNode: ActionNode
        {
            public DoApprovalNode(WorkflowContext context, string name): base(context, name)
            {

            }

            public override void Execute()
            {
                var currentContext = context as SampleDocumentApprovalWorkflowContext;
                if (currentContext == null)
                {
                    return;
                }

                Console.WriteLine("Please enter 'approve' or 'decline'.");
                
                string decision = Console.ReadLine().ToLower();
                if (decision != "approve" && decision != "decline")
                {
                    this.Execute();
                    return;
                }

                currentContext.Decision = decision;
            }
        }

        public SampleDocumentApprovalWorkflow() : base()
        {
            context = new SampleDocumentApprovalWorkflowContext();
            CurrentNode = new StartNode(context, "BEGIN");
            var approvalNode = new DoApprovalNode(context, "IN_APPROVAL");
            var finalNode = new EndNode(context, "FINISHED");

            CurrentNode.Successors.Add(item: new Transition(context)
            {
                NextNode = approvalNode,
                CanTransition = () =>
                {
                    var currentContext = context as SampleDocumentApprovalWorkflowContext;
                    if (currentContext == null)
                    {
                        return false;
                    }
                    
                    return currentContext.ApprovalState == APPROVAL_STATE.UNAPPROVED;
                },
                ActionForward = () =>
                {
                    Console.WriteLine("Going forward to approval state.");
                    Console.WriteLine("Sent e-mail to manager.");

                    var currentContext = context as SampleDocumentApprovalWorkflowContext;
                    if (currentContext == null)
                    {
                        return;
                    }

                    currentContext.ApprovalState = APPROVAL_STATE.IN_PROGRESS;
                }
            });

            approvalNode.Successors.Add(new Transition(context)
            {
                NextNode = finalNode,
                CanTransition = () => 
                {
                    var currentContext = context as SampleDocumentApprovalWorkflowContext;
                    if (currentContext == null)
                    {
                        return false;
                    }

                    return currentContext.Decision == "approve" && currentContext.ApprovalState == APPROVAL_STATE.IN_PROGRESS;
                },
                ActionForward = () =>
                {
                    Console.WriteLine("Finishing approval workflow.");
                }
            });
        }
    }
}