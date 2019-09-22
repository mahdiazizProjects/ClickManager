using ClickEngine.Engine.Positions.Models;
using ModelManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelManager.Engine
{
    public class ModelUtility
    {

        public static (List<ActionModel>, List<ActionModel> , List<ActionModel> , List<ActionModel>,string processName ) ConvertBaseModelToActionModels(BaseModel baseModel)
        {
            List<ActionModel> preProcess = new List<ActionModel>();
            List<ActionModel> run = new List<ActionModel>();
            List<ActionModel> process = new List<ActionModel>();
            List<ActionModel> postProcess = new List<ActionModel>();
            preProcess = ConvertBaseModelToActionModel(baseModel.PreProcessModel);
            run = ConvertBaseModelToActionModel(baseModel.RunModel);
            process = ConvertBaseModelToActionModel(baseModel.ProcessModel);
            postProcess = ConvertBaseModelToActionModel(baseModel.PostProcessModel);
            var processName = baseModel.ProcessName;

            return (preProcess, run, process, postProcess, processName);
        }
        private static List<ActionModel>ConvertBaseModelToActionModel(List<BaseViewModel>baseViewModelDTOs)
        {
           return baseViewModelDTOs.Select(bvm => new ActionModel() { ActionName = bvm.Name, Position = PointManager.ConvertPositionStringToPosition(bvm.Positions) }).ToList();
        }
    }
}
