using System;
using System.IO;
using System.Reflection;

namespace Pronitor.Logic
{
    public static class Logger
    {
        public static string exePath;
        private static readonly object _syncObject = new object();
        static Logger()
        {
            exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "log.txt";
        }
        public static void LogWrite(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(exePath))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception)
            {
                //any exeptions here accuring means that the log method was locked, which means it will try again later on 
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            // only one thread can own this lock, so other threads
            // entering this method will wait here until lock is
            // available.
            lock (_syncObject)
            {
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
                // Update the underlying file.
                w.Flush();
            }
        }
    }
}