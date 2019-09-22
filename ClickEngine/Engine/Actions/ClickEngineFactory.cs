using ClickEngine.Engine.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickEngine.Engine.Actions
{
    public abstract class ClickEngineFactory
    {
        public abstract IClick Create();
    }
}
