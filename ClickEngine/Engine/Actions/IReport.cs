using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickEngine.Engine.Models;
using ClickEngine.Engine.Positions.Models;

namespace ClickEngine.Engine.Positions
{
    public enum FillType
    {
        None,
        All,
        Random,
        Input
    }
    public interface IClick
    {
        void Fill(FillType fillType, List<ActionModel> actions = null);
        void PreProcess();
        void PostProcess();
        void Run(string fileName);
    }
}
