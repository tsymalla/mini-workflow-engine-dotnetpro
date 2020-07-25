using System;
using System.Linq;

namespace WorkflowEngine
{
    public class WorkflowEngine
    {
        public static void Execute(Workflow.Runner.Runner runner)
        {
            runner.Run();
        }
    }
}