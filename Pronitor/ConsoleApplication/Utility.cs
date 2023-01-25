using System;
using Pronitor.Logic;

namespace Pronitor.ConsoleApplication
{
    public class Utility
    {
        private readonly string name;
        private readonly int lifeTime;
        private readonly int frequency;

        public Utility(string name, int lifeTime, int frequency)
        {
            this.name = name;
            this.lifeTime = lifeTime;
            this.frequency = frequency;
            Run();
        }

        // Prompts user for initial input
        public void Run()
        {
            Console.Write("Please enter your keyboard key to kill the utility => ");
            ConsoleKey killKey = Console.ReadKey().Key;
            Console.WriteLine();

            //Keys validations
            ConsoleKey enterUIKey = ConsoleKey.Tab;
            if (killKey == ConsoleKey.Spacebar)
            {
                Console.WriteLine("Spacebar key => has been changed to Enter key");
                killKey = ConsoleKey.Enter;
            }
            if (killKey == ConsoleKey.Tab)
                enterUIKey = ConsoleKey.Enter;

            Console.WriteLine("-------------------------------");
            Manager.AddMonitor(name, lifeTime, frequency, (char)killKey);

            ListenForConsoleStream(killKey, enterUIKey);
        }

        // Console stream input listner
        public void ListenForConsoleStream(ConsoleKey killKey, ConsoleKey enterUIKey)
        {
            InputReminder(killKey, enterUIKey);
            ConsoleKey CheckInput = Console.ReadKey(true).Key;
            while (CheckInput != killKey)
            {
                if (CheckInput == enterUIKey)
                {
                    Router.CallUI();
                    Console.WriteLine("UI Form has been launched");
                }
                else
                {
                    Console.WriteLine($"You just typed {CheckInput}, which is not an acceptable key.");
                }
                InputReminder(killKey, enterUIKey);
                CheckInput = Console.ReadKey(true).Key;
            }
        }

        // Reminds the user with the mapped keys
        public void InputReminder(ConsoleKey killKey, ConsoleKey enterUIKey)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Please remember that you can press ({killKey}) anytime to kill the utility, and ({enterUIKey}) to access UI");
            Console.ResetColor();
        }
    }
}
