using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pronitor.Logic
{
    class Monitor
    {
        private string name;
        private int lifeTime;
        private int frequency;
        private char? killKey;
        private List<Task> tasks = new List<Task>();

        public Monitor(string name, int lifeTime, int frequency, char? killKey)
        {
            this.name = name;
            this.lifeTime = lifeTime;
            this.frequency = frequency;
            this.killKey = killKey;
            ScanProcesses();
        }

        public int Frequency { get => frequency; }
        public int LifeTime { get => lifeTime; }
        public string Name { get => name; }
        public char? KillKey { get => killKey; }

        public void ScanProcesses()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Equals(name))
                    tasks.Add(new Task(this, theprocess.Id));
            }
        }

        public void DeleteTask(int taskID)
        {
            tasks.RemoveAt(taskID);
        }
    }
}
