using ClickEngine.Engine.Actions;
using ClickEngine.Engine.Positions;
using ClickEngine.Engine.Positions.Models;
using ClickEngine.Engine.SeedWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace ClickEngine.Engine
{
    public abstract class ClickEngine:IClick
    {
        protected abstract string ProcessName { get; set; }

        private readonly IList<ClickEngineFactory> _factories;
        protected abstract List<ActionModel> Actions { get; set; }
        protected abstract List<ActionModel> AllActions { set; get; }
        private const int waitInterAction = 500;
        private const int CPUUsageWaitTime = 1000;


        private bool IsRunning()
        {
            var isRunning = false;
            var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ProcessName));
            if (processes?.Length > 0)
            {
                var cpuUsage = GetCPUUsage(processes.FirstOrDefault());
                if (cpuUsage > 0||!processes.FirstOrDefault().Responding)
                {
                    isRunning = true;
                }
            }

            return isRunning;
        }
        private double GetCPUUsage(Process process)
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = process.TotalProcessorTime;
            Thread.Sleep(CPUUsageWaitTime);
            var endTime = DateTime.UtcNow;
            var endCpuUsage = process.TotalProcessorTime;
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            return cpuUsageTotal * 100;
        }
        protected void RunAllActions(List<ActionModel> Actions) => Actions.ForEach(action =>
                                      {
                                          action.Position.ForEach(position =>
                                          {
                                              SystemInteractions.LeftMouseClick(position);
                                              Thread.Sleep(waitInterAction);
                                          });
                                      });
        public virtual void Run(string fileName)
        {
            // Set the Timer
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            // Run All actions
            RunAllActions(Actions);

            // Run View Action
            View();
            // Check and wait for the appplication to run!
            while ((IsRunning())) ;
            //stop time
            stopWatch.Stop();
            // Save the time
            var timeElapsed = stopWatch.ElapsedMilliseconds / 1000.0;
            // Record the actions
            SaveActions(fileName, timeElapsed.ToString());
        }
        public void Fill(FillType fillType, List<ActionModel> actions = null)
        {
            switch (fillType)
            {
                case FillType.All:
                    Actions = AllActions;
                    break;
                case FillType.Random:
                    Actions = ActionUtility<ClickEngine>.GetRandomActions(AllActions);
                    break;
                case FillType.Input:
                    Actions = actions;
                    break;
                case FillType.None:
                    Actions = new List<ActionModel>();
                    break;
            }
        }
        private void SaveActions(string fileName,string timeElapsed)
        {
            var content = string.Empty;
            if(File.Exists(fileName))
            {
                content = File.ReadAllText(fileName);
            }
            content = $"{content} {Environment.NewLine} time elapsed (s): {timeElapsed} \t , actions:{string.Join("-", Actions.Select(action => action.ActionName))}";

            File.WriteAllText(fileName, content);

        }
        protected abstract void View();

        public void PreProcess()
        {
            throw new NotImplementedException();
        }

        public void PostProcess()
        {
            throw new NotImplementedException();
        }

    }
}
