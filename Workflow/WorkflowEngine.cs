using System;
using System.Linq;

namespace WorkflowEngine.Workflow
{
    public class WorkflowEngine
    {
        public static void Execute(Workflow wf)
        {
            wf.Progress();
        }
    }
}