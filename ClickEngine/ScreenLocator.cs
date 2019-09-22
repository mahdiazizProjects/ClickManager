using System;
using System.Threading;
using ClickEngine.Engine;

namespace ClickEngine
{
    public class ScreenLocator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var point = SystemInteractions.GetMousePosition();
                // sample code
                Console.WriteLine("x: " + point.X + " y: " + point.Y);
                Thread.Sleep(100);

            }
        }
    }
}
