using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Pronitor.Logic
{
    class Task
    {
        private Monitor parent;
        private int taskID;
        private DateTime startTime;
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
            timer.Interval = 1000 * parent.Frequency; //millisecond to minute * frequency
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.Subtract(startTime).TotalMinutes > parent.LifeTime || !DoesProcessExist()) //TotalMinutesExceeded
            {
                parent.KillTask(this);//Kill me
            }
        }

        public bool DoesProcessExist()
        {
            return Process.GetProcesses().Any(x => x.Id == taskID);
        }
    }
}