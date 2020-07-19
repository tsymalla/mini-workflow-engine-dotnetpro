using WorkflowEngine.Workflow.Nodes;

namespace WorkflowEngine.Workflow
{
    public class Workflow
    {
        public enum STATE
        {
            NOT_RUNNING,
            RUNNING,
            ON_HOLD,
            FINISHED
        };

        private STATE state = STATE.NOT_RUNNING;
        private StartNode startNode;

        public Workflow(StartNode node)
        {
            this.startNode = startNode;
        }
    }
}