using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickEngine.Engine.Models;
using ClickEngine.Engine.Positions.Models;

namespace ClickEngine.Engine.SeedWork
{
    public class ActionUtility<T>
    {
        public static List<ActionModel> GetActions(T classModel)
        {
            var actions = new List<ActionModel>();
            foreach (var prop in classModel.GetType().GetProperties())
            {
                var tempPoint = prop.GetValue(classModel, null);
                if (tempPoint is List<Point> points)
                {
                    actions.Add(new ActionModel() { ActionName = prop.Name, Position = points });
                }
                else if(tempPoint is Point point)
                {
                    actions.Add(new ActionModel() { ActionName = prop.Name, Position =new List<Point>() { point } });
                }
            }
            return actions;
        }
        public static List<ActionModel> GetRandomActions(List<ActionModel> allActions)
        {
            var randomList = new List<ActionModel>();
            Random random = new Random();
            if (allActions.Count > 0)
            {
                var randomCount = random.Next(1, allActions.Count);
                randomList = allActions.OrderBy(x => random.Next()).Take(randomCount).ToList();
            }
            return randomList;
        }
    }
}
