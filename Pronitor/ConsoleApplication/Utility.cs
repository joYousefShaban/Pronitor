using System;
using Pronitor.Logic;

namespace Pronitor.ConsoleApplication
{
    class Utility
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

        public void Run()
        {
            Console.Write("Please enter your keyboard key to kill the utility => ");
            ConsoleKey killKey = Console.ReadKey().Key;
            Console.WriteLine();

            //Kill key validations
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


            InputReminder(killKey,enterUIKey);
            ConsoleKey CheckInput = Console.ReadKey(true).Key;
            while (CheckInput != killKey)
            {
                if (CheckInput == enterUIKey)// Enter UI enterUIKey immediately
                {
                    DecideInterface.CallUI();
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

        public void InputReminder(ConsoleKey killKey, ConsoleKey enterUIKey)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Please remember that you can press ({killKey}) anytime to kill the utility, and ({enterUIKey}) to access UI");
            Console.ResetColor();
        }


        public static void TypeMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
