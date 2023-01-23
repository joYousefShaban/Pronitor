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
            ConsoleKey enterUIKey = ConsoleKey.Enter;
            if (killKey == ConsoleKey.Spacebar)
            {
                Console.WriteLine("Spacebar key => has been changed to Enter key");
                killKey = ConsoleKey.Enter; 
            }
            if (killKey == ConsoleKey.Enter)
                enterUIKey = ConsoleKey.Tab;

            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Press ({killKey}) anytime to stop, remember that you can acsses UI anytime by pressing ({enterUIKey})");
            Console.ResetColor();

            Manager.AddMonitor(name, lifeTime, frequency, (char)killKey);

            var CheckInput = Console.ReadKey(true).Key;
            /*            while (!(Console.KeyAvailable && CheckInput == killKey))// Kill Utility if user hits the killKey immediately
                        {
                            *//*if (CheckInput == enterUIKey)// Enter UI enterUIKey immediately
                            {
                                Pronitor.CallUI();
                                break;
                            }*//*
                            CheckInput = Console.ReadKey(true).Key;
                        }*/
            while (CheckInput != killKey)
            {
                if (CheckInput == enterUIKey)// Enter UI enterUIKey immediately
                {
                    Pronitor.CallUI();
                }
                CheckInput = Console.ReadKey(true).Key;
            }
        }


        public static void TypeMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
