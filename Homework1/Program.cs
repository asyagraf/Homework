using System;

namespace Homework1
{
    class Program : ISquareRoot, IReadFromFile, IYandex
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

                switch (menu)
                {
                    case "1":
                        IReadFromFile.ReadFromFile();
                        break;
                    case "2":
                        ISquareRoot.GetSquareRoot();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.White;
                        IYandex.GetContent();
                        break;
                    case "4":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат ввода");
                        break;
                }
            }
            while (menu != "4");
        }
    }
}
