using System;
using WorkflowEngine.Workflow;
using WorkflowEngine.Workflow.Nodes;
using WorkflowEngine.Workflow.Transitions;
using WorkflowEngine.Workflow.Runners;

namespace WorkflowEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running sequential workflow.");
            SampleDocumentApprovalWorkflow wf1 = new SampleDocumentApprovalWorkflow();
            SequentialRunner sequentialRunner = new SequentialRunner();
            sequentialRunner.AddWorkflow(wf1);

            Workflow.WorkflowEngine.Execute(sequentialRunner);
            Console.WriteLine("Sequential workflow finished.");
            
            /*Console.WriteLine("Running repeated workflow.");
            SampleDocumentApprovalWorkflow wf2 = new SampleDocumentApprovalWorkflow();
            RepeatedRunner repeatedRunner = new RepeatedRunner(3);
            repeatedRunner.AddWorkflow(wf2);

            WorkflowEngine.Execute(repeatedRunner);
            Console.WriteLine("Repeated workflow finished.");*/
        }
    }
}
