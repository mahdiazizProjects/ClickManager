using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRunner.Models
{
    public class BaseModelDTO
    {
        public List<BaseViewModelDTO> PreProcessModel { get; set; } = new List<BaseViewModelDTO>();
        public List<BaseViewModelDTO> RunModel { get; set; } = new List<BaseViewModelDTO>();
        public List<BaseViewModelDTO> ProcessModel { get; set; } = new List<BaseViewModelDTO>();
        public List<BaseViewModelDTO> PostProcessModel { get; set; } = new List<BaseViewModelDTO>();
    }
    public class BaseViewModelDTO
    {
        public string Name { get; set; }
        public bool IsMultiClick { get; set; }
        public string Positions { get; set; }

        public void SetPosition(string position)
        {
            Positions = position;
        }
    }
}
