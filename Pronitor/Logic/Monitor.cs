using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Pronitor.Logic
{
    public class Monitor
    {
        private readonly string name;
        private readonly int lifeTime;
        private readonly int frequency;
        private readonly char killKey;
        public List<Task> tasks;
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

        // Initialize timer upon scan seconds
        private void InitScanTimer()
        {
            scanTimer = new Timer();
            scanTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            scanTimer.Interval = 3000; //assigned to tick ence each three second
            scanTimer.Enabled = true;
        }

        // Timer event listener
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            ScanProcesses();
        }

        // Periodically scans the tasks in monitorList and checks if they are active in windows processes
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

        // Checks if the task already exist based on taskID
        public bool IsInTasks(int taskID)
        {
            return tasks.Any(x => x.TaskID == taskID);
        }

        // Removes a task object in a monitor from monitoringList and kills the corresponding windows process
        public void KillTask(Task passedTask, string killReasonCode)
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

                // Dispose the thread when killing the instanse
                passedTask.ScanTimer.Dispose();

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