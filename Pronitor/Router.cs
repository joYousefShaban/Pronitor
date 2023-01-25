using System;
using System.Windows.Forms;
using Pronitor.ConsoleApplication;

namespace Pronitor
{
    public class Router
    {
        // Invokes the UI
        public static void CallUI()
        {
            Application.EnableVisualStyles();
            Application.Run(new UIMainMenu());
        }

        // Invokes the console
        public static void CallConsole(string[] args)
        {
            new Utility(args[0], int.Parse(args[1]), int.Parse(args[2]));
        }

        // Returns whether to call the UI or not
        private static bool ShouldCallUI(string[] args)
        {
            return args.Length == 0;
        }

        // Returns whether to call the console or not 
        private static bool ShouldCallConsole(string[] args)
        {
            if (args.Length != 3)
            {
                throw new MissingFieldException();
            }
            else if (int.TryParse(args[1], out _) && int.TryParse(args[2], out _))
            {
                return true;
            }
            else
            {
                throw new FormatException();
            }
        }

        // Application entry point
        public static void Main(string[] args)
        {
            if (ShouldCallUI(args))
            {
                CallUI();
            }
            else if (ShouldCallConsole(args))
            {
                CallConsole(args);
            }
        }
    }
}