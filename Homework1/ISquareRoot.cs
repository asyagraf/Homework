using System;

namespace Homework1
{
    interface ISquareRoot
    {
        public static void GetSquareRoot()
        {
            Console.WriteLine("Введите число:");
            try
            {
                double number = Convert.ToDouble(Console.ReadLine());
                Count(number);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат ввода");
            }
            
        }
        private static void Count(double i)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Math.Sqrt(i));        
        }
    }
}
