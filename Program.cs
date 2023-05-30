using System;
using System.Collections.Generic;


namespace Haven___Text_Adventure
{
    public class Program
    {
        static public Game gameTest;
        static void Main(string[] args)
        {
            int i = 0;
            bool gameRunning = true;
            // creating new game & generating info
            while (gameRunning)
            {
                gameTest = new Game();
                gameTest.SetStartColor();
                gameTest.GenerateAllInfo();
                if(i == 1)
                {
                    gameTest.Hero.Name = $"CoolHero";
                }
                else if (i >= 2)
                {
                    gameTest.Hero.Name = $"CoolHero.V{i}";
                }

                // gameplay loop

                while (gameTest.Hero.IsAlive() && gameTest.gameEnd == false)
                {
                    gameTest.PlayerActionsList();
                }
                
                // game end, good and bad

                if (gameTest.gameEnd == true)
                {
                    Console.Clear();
                    gameTest.MainScreenPos();
                    Console.Write("Thanks for playing!");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("You died and was quickly forgotten. . .");
                    Console.SetCursorPosition(gameTest.mainXOffSet, gameTest.mainYOffSet+1);
                    Console.Write("As newer, better looking heroes took your place.");
                    Console.SetCursorPosition(gameTest.mainXOffSet, gameTest.mainYOffSet + 3);
                    Console.Write("Try again:");
                    i++;
                    gameTest.DrawUI();
                    Console.ReadKey();
                    Console.WriteLine("x");
                    Console.Clear();
                }
            }
           

        }
    }
}
