using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickEngine.Engine.SeedWork
{
    public class FileUtility
    {
        public static string GetUniqueTxtFileName(string name)
        {
            return $"{name}_{DateTime.Now.ToFileTimeUtc()}.txt";
        }
    }
}
