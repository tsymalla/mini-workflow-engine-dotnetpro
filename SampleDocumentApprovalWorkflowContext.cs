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
        public string Decision { get; set; }

        public override void Reset()
        {
            ApprovalState = APPROVAL_STATE.UNAPPROVED;
            Decision = null;
        }
    }
}