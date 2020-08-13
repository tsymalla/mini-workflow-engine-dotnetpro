using System;
using System.Linq;
using WorkflowEngine.Workflow.Runners;

namespace WorkflowEngine.Workflow
{
    public class WorkflowEngine
    {
        public static void Execute(Runner runner)
        {
            runner.Run();
        }
    }
}