using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Pronitor.Logic
{
    class Task
    {
        private readonly Monitor parent;
        private readonly int taskID;
        private readonly DateTime startTime;
        Timer timer;


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
        public Timer Timer { get => timer; set => timer = value; }

        private void InitTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 60000 * parent.Frequency; //it's assigned to tick once minutes multiplied by frequency
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.Subtract(startTime).TotalMinutes < parent.LifeTime) //TotalMinutesExceeded
            {
                parent.KillTask(this,"timeout");//Kill me
            }
            else if (!DoesProcessExist())
            {
                parent.KillTask(this, "not existing anymore");
            }
        }

        public bool DoesProcessExist()
        {
            return Process.GetProcesses().Any(x => x.Id == taskID);
        }
    }
}