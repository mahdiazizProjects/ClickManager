using ModelManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ModelManager.Engine
{
    public class FileUtility
    {
        public static (bool,BaseModel) GetBaseModel(string fileName)
        {
            var baseModelDTO = new BaseModel();
            var success = false;
            try
            {
                if (File.Exists(fileName))
                {
                    var content = File.ReadAllText(fileName);
                    baseModelDTO = JsonConvert.DeserializeObject<BaseModel>(content);
                    success = true;
                }
            }
            catch(Exception)
            {
                
            }
            return (success, baseModelDTO);
        }
    }
}
