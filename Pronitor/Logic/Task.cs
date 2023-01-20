using System;
using System.Diagnostics;
using System.Timers;

namespace Pronitor.Logic
{
    class Task
    {
        private Monitor parent;
        private int processID;
        private DateTime startTime;
        Timer timer;


        public Task(Monitor parent, int processID)
        {
            //Dependency injection
            this.parent = parent;
            this.processID = processID;
            startTime = DateTime.Now;
            InitTimer();
        }

        public DateTime StartTime { get => startTime; }


        private void InitTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 60000 * parent.Frequency; //millisecond to minute * frequency
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.Subtract(startTime).TotalMinutes > parent.LifeTime && !DoesProcessExist()) //TotalMinutesExceeded
            {
                Manager.KillProcess(parent.Name, processID);//Kill me
            }
        }

        public bool DoesProcessExist()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id == processID)
                    return true;
            }
            return false;
        }
    }
}