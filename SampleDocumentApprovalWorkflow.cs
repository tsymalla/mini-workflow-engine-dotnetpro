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
            public DoApprovalNode(WorkflowContext context, string name): base(context, name, TYPE.ACTION_NODE)
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
                    Execute();
                    return;
                }

                currentContext.Decision = decision;
            }
        }

        public SampleDocumentApprovalWorkflow()
        {
            context = new SampleDocumentApprovalWorkflowContext();
            var startNode = new StartNode(context, "BEGIN");
            CurrentNode = startNode;
            var approvalNode = new DoApprovalNode(context, "IN_APPROVAL");
            var finalNode = new EndNode(context, "FINISHED");

            Transitions.Add(item: new Transition(context)
            {
                NodeFrom = startNode,
                NodeTo = approvalNode,
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

            Transitions.Add(new Transition(context)
            {
                NodeFrom = approvalNode,
                NodeTo = finalNode,
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
            
            Transitions.Add(new Transition(context)
            {
                NodeFrom = approvalNode,
                NodeTo = startNode,
                CanTransition = () => 
                {
                    var currentContext = context as SampleDocumentApprovalWorkflowContext;
                    if (currentContext == null)
                    {
                        return false;
                    }

                    return currentContext.Decision == "decline" && currentContext.ApprovalState == APPROVAL_STATE.IN_PROGRESS;
                },
                ActionForward = () =>
                {
                    var currentContext = context as SampleDocumentApprovalWorkflowContext;
                    if (currentContext != null)
                    {
                        currentContext.Decision = null;
                        currentContext.ApprovalState = APPROVAL_STATE.UNAPPROVED;
                    }

                    Console.WriteLine("Moving back to initial state.");
                }
            });
        }
    }
}