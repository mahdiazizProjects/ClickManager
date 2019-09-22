using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickEngine.Engine.Models;

namespace ClickEngine.Engine.Positions.Models
{
    public class SampleModel
    {
        public Point ShowBudget { get => new Point { X = 31, Y = 272 }; }
        public Point ShowDetail { get => new Point { X = 31, Y = 288 }; }
        public Point InvSpecialOrder { get => new Point { X = 31, Y = 304 }; }
        public Point OverSold { get => new Point { X = 186, Y = 272 }; }
        public Point ZeroStock { get => new Point { X = 186, Y = 288 }; }
        public Point ZeroValueInventory { get => new Point { X = 186, Y = 304 }; }
        //public Point SubCategory { get => new Point { X = 41, Y = 335 }; }

    }
}
