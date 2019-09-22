using System.Collections.Generic;
using ClickEngine.Engine.Models;

namespace ClickEngine.Engine.Positions.Models
{
    public class ActionModel
    {
        public List<Point> Position { get; set; } = new List<Point>();
        public string ActionName { get; set; }
    }
}
