using ClickEngine.Engine.Positions;
using ClickEngine.Engine.Positions.Models;
using System.Collections.Generic;
namespace ModelRunner.Engine
{
    public class GenericRunner : ClickEngine.Engine.ClickEngine,IClick
    {
        public GenericRunner(List<ActionModel> preProcessActions, List<ActionModel> runActions,
            List<ActionModel> processActions, List<ActionModel> postProcessActions,string processName)
        {
            AllActions = runActions;
            PreProcessActions = preProcessActions;
            ProcessActions = processActions;
            PostProcessActions = postProcessActions;
            ProcessName = processName;
        }
        protected override List<ActionModel> Actions { get; set; }
        protected override List<ActionModel> AllActions { get; set; }
        private List<ActionModel> PreProcessActions { get; set; }
        private List<ActionModel> ProcessActions { get; set; }
        private List<ActionModel> PostProcessActions { get; set; }
        protected override string ProcessName { get; set; }

        protected override void View()
        {
            RunAllActions(ProcessActions);
        }
        public new void PreProcess()
        {
            RunAllActions(PreProcessActions);
        }
        public new void PostProcess()
        {
            RunAllActions(PostProcessActions);
        }
    }
}
