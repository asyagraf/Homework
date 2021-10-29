using System;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("1 - Чтение из файла");
                Console.WriteLine("2 - Квадратный корень");
                Console.WriteLine("3 - HTML Яндекса");
                Console.WriteLine("4 - Выход");

                menu = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;

                switch (menu)
                {
                    case "1":
                        //
                        break;
                    case "2":
                        SquareRoot.GetSquareRoot();
                        break;
                    case "3":
                        //
                        break;
                    case "4":
                        break;
                    default:
                        //errors
                        break;
                }
            }
            while (menu != "4");
        }
    }
}
