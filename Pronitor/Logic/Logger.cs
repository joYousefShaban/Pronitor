using System;
using System.IO;
using System.Reflection;

namespace Pronitor.Logic
{
    public class Logger
    {
        public static string exePath;
        private static readonly object _syncObject = new object();
        static Logger()
        {
            exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "log.txt";
        }

        // Write to log file
        public static void LogWrite(string logMessage)
        {
            using (StreamWriter w = File.AppendText(exePath))
            {
                Log(logMessage, w);
            }
        }

        // Perform lock writing operation for logging
        public static void Log(string logMessage, TextWriter w)
        {

            // Only one thread can own this lock, so other threads entering this method will wait here until lock is available.
            lock (_syncObject)
            {
                w.WriteLine(logMessage);

                // Update the underlying file.
                w.Flush();
            }
        }
    }
}