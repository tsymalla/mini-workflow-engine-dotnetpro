using System;
using WorkflowEngine.Workflow.Nodes;
using WorkflowEngine.Workflow.Transition;
using WorkflowEngine.Workflow.Runner;

namespace WorkflowEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleDocumentApprovalWorkflow wf = new SampleDocumentApprovalWorkflow();
            SequentialRunner runner = new SequentialRunner();
            runner.AddWorkflow(wf);

            WorkflowEngine.Execute(runner);
        }
    }
}
