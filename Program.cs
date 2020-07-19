using System;
using WorkflowEngine.Workflow.Nodes;
using WorkflowEngine.Workflow.Transition;

namespace WorkflowEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleDocumentApprovalWorkflow wf = new SampleDocumentApprovalWorkflow();
            WorkflowEngine.Workflow.WorkflowEngine.Execute(wf);
        }
    }
}
