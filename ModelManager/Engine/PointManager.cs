using ClickEngine.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelManager.Engine
{
    public class PointManager
    {
        public static List<Point> ConvertPositionStringToPosition(string position)
        {
            var points = new List<Point>();
            var positionsString = position.Split(';').ToList();
            positionsString.ForEach(ps =>
            {
                var positionString = ps.Split(',').ToList();
                if (positionString.Count == 2)
                {
                    points.Add(new Point()
                    {
                        X = Convert.ToInt32(positionString[0]),
                        Y = Convert.ToInt32(positionString[1])
                    });
                }
            });
            return points;
        }
    }
}
