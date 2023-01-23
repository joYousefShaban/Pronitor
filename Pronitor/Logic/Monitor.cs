using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Pronitor.Logic
{
    class Monitor
    {
        private readonly string name;
        private readonly int lifeTime;
        private readonly int frequency;
        private readonly char killKey;
        private List<Task> tasks;
        Timer scanTimer;

        public Monitor(string name, int lifeTime, int frequency, char killKey)
        {
            this.name = name;
            this.lifeTime = lifeTime;
            this.frequency = frequency;
            this.killKey = killKey;
            tasks = new List<Task>();
            ScanProcesses();
            InitScanTimer();
        }

        public int Frequency { get => frequency; }
        public int LifeTime { get => lifeTime; }
        public string Name { get => name; }
        public char KillKey { get => killKey; }
        internal List<Task> Tasks { get => tasks; set => tasks = value; }
        public Timer ScanTimer { get => scanTimer; set => scanTimer = value; }

        private void InitScanTimer()
        {
            scanTimer = new Timer();
            scanTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            scanTimer.Interval = 3000; //assigned to tick ence each three second
            scanTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            ScanProcesses();
        }

        private void ScanProcesses()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Equals(name) && tasks.Count >= 0 && !IsInTasks(theprocess.Id))
                {
                    tasks.Add(new Task(this, theprocess.Id));
                    string message = Manager.MessageTemplate($"({name}) process with the ID ({theprocess.Id}) has been added \n new total active processes is: {tasks.Count}");
                    Logger.LogWrite(message);
                    Console.WriteLine(message);
                }
            }
        }

        public bool IsInTasks(int taskID)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].TaskID == taskID)
                    return true;
            }
            return false;
        }

        public void KillTask(Task passedTask ,string killReasonCode)
        {
            try
            {
                Process[] processlist = Process.GetProcesses();
                foreach (Process theprocess in processlist)
                {
                    if (theprocess.Id == passedTask.TaskID)
                    {
                        theprocess.Kill();
                        theprocess.WaitForExit();
                    }
                }
            }
            catch (Exception e)
            {
                string message = Manager.MessageTemplate($"({name}) process with the ID ({passedTask.TaskID}) has caused the following error: {e.Message}!!!! | \"due to {killReasonCode}\" \n new total active processes is: {tasks.Count}");
                Logger.LogWrite(message);
                Console.WriteLine(message);
            }
            finally
            {
                passedTask.Timer.Dispose();
                if (tasks.Contains(passedTask))
                {
                    tasks.Remove(passedTask);
                }
                string message = Manager.MessageTemplate($"({name}) process with the ID ({passedTask.TaskID}) has been deleted | \"due to {killReasonCode}\" \n new total active processes is: {tasks.Count}");
                Logger.LogWrite(message);
                Console.WriteLine(message);
            }
        }
    }
}
