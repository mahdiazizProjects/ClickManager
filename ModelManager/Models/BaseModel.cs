using System.Collections.Generic;

namespace ModelManager.Models
{
    /// <summary>
    /// This base model is designed for creating different models in processing the application. 
    /// </summary>
    public class BaseModel
    {
        public List<BaseViewModel> PreProcessModel { get; set; } = new List<BaseViewModel>();
        public List<BaseViewModel> RunModel { get; set; } = new List<BaseViewModel>();
        public List<BaseViewModel> ProcessModel { get; set; } = new List<BaseViewModel>();
        public List<BaseViewModel> PostProcessModel { get; set; } = new List<BaseViewModel>();
        public string ProcessName { get; set; }
    }
}
