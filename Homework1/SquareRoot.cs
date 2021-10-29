using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public static class SquareRoot
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
            Console.WriteLine(Math.Sqrt(i));        
        }
    }
}
