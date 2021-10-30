using System;
using System.IO;

namespace Homework1
{
    interface IReadFromFile
    {
        public static void ReadFromFile()
        {
            Console.WriteLine("Введите путь:");
            string path = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                using StreamReader sr = new StreamReader(path);
                Console.WriteLine(sr.ReadToEnd());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл не найден");
            }
        }

    }
}
