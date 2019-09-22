using ClickEngine.Engine;
using ModelManager.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelManager.Engine
{
    public class ModelCreator
    {
        public static bool IsModelValid(List<BaseViewModel> baseModel)
        {
            var success = true;
            if(baseModel!=null&&baseModel.Count>0)
            {
                success = baseModel.All(bm=>!string.IsNullOrEmpty(bm.Name)&&!string.IsNullOrEmpty(bm.Positions));
            }
            return success;
        }
        public static bool CreateOrUpdateModel(List<BaseViewModel> preProcessModel, List<BaseViewModel> runModel, List<BaseViewModel> processModel, List<BaseViewModel> postProcessModel, string modelName,string processName)
        {
            var success = false;

            success = CreateModel(preProcessModel,runModel, processModel, postProcessModel, modelName,processName);
            return success;
        }
        private static bool CreateModel(List<BaseViewModel> preProcessModel, List<BaseViewModel> runModel, List<BaseViewModel> processModel, List<BaseViewModel> postProcessModel, string modelName,string processName)
        {
            var success = false;

            BaseModel baseModel = new BaseModel() { PreProcessModel = preProcessModel, RunModel = runModel, ProcessModel = processModel, PostProcessModel = postProcessModel,ProcessName=processName };
            var content = JsonConvert.SerializeObject(baseModel);
            string fileName = $"{modelName}";
            File.WriteAllText(fileName,content);
            success = true;
            return success;
        }
        public static void UpdateModel(List<BaseViewModel> runModel,int selected_Index)
        {
            if (selected_Index < runModel.Count && selected_Index >= 0)
            {

                var point = SystemInteractions.GetMousePosition();
                if (runModel[selected_Index].IsMultiClick)
                {
                    runModel[selected_Index].SetPosition($"{runModel[selected_Index].Positions};{point.X},{point.Y}");
                }
                else
                {
                    runModel[selected_Index].SetPosition($"{point.X},{point.Y}");
                }

            }
        }

    }
}
