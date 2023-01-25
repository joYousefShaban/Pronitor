using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Pronitor.Logic
{
    public class Task
    {
        private readonly Monitor parent;
        private readonly int taskID;
        private readonly DateTime startTime;
        Timer scanTimer;


        public Task(Monitor parent, int taskID)
        {
            //Dependency injection
            this.parent = parent;
            this.taskID = taskID;
            startTime = DateTime.Now;
            InitTimer();
        }

        public DateTime StartTime { get => startTime; }
        public int TaskID { get => taskID; }
        public Timer ScanTimer { get => scanTimer; set => scanTimer = value; }

        // Initialize timer upon scan seconds
        private void InitTimer()
        {
            scanTimer = new Timer();
            scanTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            scanTimer.Interval = 60000 * parent.Frequency; //it's assigned to tick once minutes multiplied by frequency
            scanTimer.Enabled = true;
        }

        // Initialize timer upon scan seconds
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            //TotalMinutesExceeded
            if (DateTime.Now.Subtract(startTime).TotalMinutes < parent.LifeTime)
            {
                parent.KillTask(this, "timeout");//Kill me
            }
            else if (!DoesProcessExist())
            {
                parent.KillTask(this, "not existing anymore");
            }
        }

        // Checks if the task already exist in windows processes based on taskID
        public bool DoesProcessExist()
        {
            return Process.GetProcesses().Any(x => x.Id == taskID);
        }
    }
}