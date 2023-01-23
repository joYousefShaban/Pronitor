using System;
using System.Windows.Forms;
using Pronitor.ConsoleApplication;

namespace Pronitor
{
    static class Pronitor
    {
        [STAThread]
        public static void CallUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
            MainMenu.isActive = false;
        }
        

        private static void CallConsole(string name, int lifeTime, int frequency)
        {
            _ = new Utility(name, lifeTime, frequency);
        }
        private static void ValidateInput(string[] args)
        {
            if (int.TryParse(args[1], out int lifeTime) && int.TryParse(args[2], out int frequency))
                CallConsole(args[0], lifeTime, frequency);
            else
                throw new FormatException();
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                CallUI();
            }
            else if (args.Length == 3)
            {
                ValidateInput(args);
            }
            else
            {
                throw new MissingFieldException();
            }
        }
    }
}