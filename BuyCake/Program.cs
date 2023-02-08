using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;


namespace BuyCake
{
    public class Programm
    {

        static void Main(string[] argrs)
        {
            int pose = 2;
            Cake newCake = new Cake();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pose <= 2)
                    {
                        pose += 6;
                    }
                    else
                    {
                        pose--;
                    }

                }
                else if (key.Key == ConsoleKey.DownArrow)
                {

                    if (pose >= 8)
                    {
                        pose -= 6;
                    }
                    else
                    {
                        pose++;
                    }

                }

                if (key.Key == ConsoleKey.Enter)
                {
                    newCake = CheckAndMenu.checkMenu(pose, newCake);
                    
                }
                Console.Clear();
                CheckAndMenu.MenuMain(pose, newCake);
                Console.SetCursorPosition(0, pose);
                Console.Write("->");

            }
        }

    }
}
         