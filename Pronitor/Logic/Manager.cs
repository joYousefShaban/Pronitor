using System;
using System.Collections.Generic;

namespace Pronitor.Logic
{
    static class Manager
    {
        static List<Monitor> monitoringList = new List<Monitor>();
        public static bool Validator(string name, int lifeTime, int frequency)
        {
            //make sure name is unique
            for (int i = 0; i < monitoringList.Count; i++)
            {
                if (monitoringList[i].Name.Equals(name))
                {
                    throw new ArgumentException(name + "already exists!");
                }
            }
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


        public static void AddMonitor(string name, int lifetime, int frequency, char killkey = 'A')
        {
            try
            {
                if (Validator(name, lifetime, frequency))//check if the input is valid, then add it to the monitoring list
                {
                    monitoringList.Add(new Monitor(name, lifetime, frequency, killkey));
                    //write to log
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has accured adding a new monitor");
                throw e;
            }
        }

        public static void DeleteMonitor(char killKey)
        {
            for (int i = 0; i < monitoringList.Count; i++)
            {
                if (monitoringList[i].KillKey.Equals(killKey))
                {
                    monitoringList.RemoveAt(i);
                    i--;
                }
            }
            //write to log
        }

        public static void KillProcess(string name, int taskID)
        {
            for (int i = 0; i < monitoringList.Count; i++)
            {
                if (monitoringList[i].Name.Equals(name))
                {
                    monitoringList[i].DeleteTask(taskID);
                    i--;
                }
            }
            //write to log
        }
    }
}
