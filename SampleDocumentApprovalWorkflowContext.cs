using WorkflowEngine.Workflow;

namespace WorkflowEngine
{
    public class SampleDocumentApprovalWorkflowContext: WorkflowContext
    {
        public enum APPROVAL_STATE
        {
            UNAPPROVED,
            IN_PROGRESS,
            APPROVED
        };
        
        public APPROVAL_STATE ApprovalState { get; set; }

        public SampleDocumentApprovalWorkflowContext()
        {
            ApprovalState = APPROVAL_STATE.UNAPPROVED;
        }
    }
}