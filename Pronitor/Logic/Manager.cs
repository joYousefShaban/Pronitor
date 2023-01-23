using System;
using System.Collections.Generic;

namespace Pronitor.Logic
{
    static class Manager
    {
        private static readonly List<Monitor> monitoringList = new List<Monitor>();

        internal static List<Monitor> MonitoringList { get => monitoringList; }

        public static bool IsNameUnique(string name)
        {
            //make sure name is unique
            for (int i = 0; i < monitoringList.Count; i++)
            {
                if (monitoringList[i].Name.Equals(name))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Validator(string name, int lifeTime, int frequency)
        {
            if (!IsNameUnique(name))
                throw new ArgumentException(name + "already exists!");
            if (frequency <= 0)
            {
                throw new ArgumentException("frequency can't be less that or equal zero!");
            }
            if (lifeTime <= 0)
            {
                throw new ArgumentException("lifeTime can't be less that or equal zero!");
            }
            return true;
        }

        public static void AddMonitor(string name, int lifetime, int frequency, char killkey = 'Q')
        {
            try
            {
                if (Validator(name, lifetime, frequency))//check if the input is valid, then add it to the monitoring list
                {
                    Monitor addedMonitor = new Monitor(name, lifetime, frequency, killkey);
                    monitoringList.Add(addedMonitor);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has accured adding a new monitor");
                Console.WriteLine(e);
            }
        }

        public static void DeleteMonitor(string name = null)
        {
            for (int i = 0; i < monitoringList.Count; i++)
            {
                if (name == null || (name != null && monitoringList[i].Name.Equals(name))) //check if to delete all monitors or a specified one
                {
                    for (int j = 0; j < monitoringList[i].Tasks.Count; j++) //kill all the tasks in the monitor
                    {
                        monitoringList[i].KillTask(monitoringList[i].Tasks[j],"manual reason");
                    }
                    monitoringList[i].ScanTimer.Dispose();
                    monitoringList.RemoveAt(i);
                    i--;
                    if (name != null) //if you found the specified one, no need to check the rest
                    {
                        return;
                    }
                }
            }
        }

        public static void KillTask(string name = null)
        {
            for (int i = 0; i < monitoringList.Count; i++)
            {
                if (name == null) //kill all the tasks in the monitor
                {
                    for (int j = 0; j < monitoringList[i].Tasks.Count; j++)
                    {
                        monitoringList[i].KillTask(monitoringList[i].Tasks[j],"manual reason");
                    }
                }
                else if (monitoringList[i].Name.Equals(name) && monitoringList[i].Tasks.Count > 0)
                {
                    monitoringList[i].KillTask(monitoringList[i].Tasks[0],"manual reason"); //kill the first task for this monitor
                }
            }
        }

        public static string MessageTemplate(string message)
        {
            return ($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}\n :\n :{message}\n-------------------------------");
        }
    }
}