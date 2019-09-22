using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManager.Models
{
    public class BaseViewModel
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
