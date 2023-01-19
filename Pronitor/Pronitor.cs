using System;
using System.Windows.Forms;

namespace Pronitor
{
    static class Pronitor
    {
        [STAThread]
        private static void CallUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }

        private static void CallConsole(string name, int lifetime, int frequency)
        {
            //TODO
        }

        private static void ValidateInput(string[] args)
        {
            if (int.TryParse(args[1], out int lifetime) && int.TryParse(args[2], out int frequency))
                CallConsole(args[0], lifetime, frequency);
            else
                throw new FormatException();
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                CallUI();
            }
            else if (args.Length==3)
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