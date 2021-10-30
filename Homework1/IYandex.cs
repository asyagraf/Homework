using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    interface IYandex
    {
        private static string url= "https://ya.ru/";

        public static void GetContent()
        {
            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = client.GetAsync(url).Result;
            using HttpContent content = response.Content;
            Stream result = content.ReadAsStream();
            using StreamReader sr = new StreamReader(result);
            string rslt = sr.ReadToEnd();
            StringBuilder sb = new StringBuilder(rslt);

            int i = 3000;
            string menu;

            while (sb.ToString().Length >= i)
            {
                Console.WriteLine(sb.ToString(0, i));
                sb = new StringBuilder(sb.ToString(i, sb.ToString().Length - i));
                Console.WriteLine("Продолжить вывод HTML? 1 - да, 2 - нет");
                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        break;
                    case "2":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат ввода");
                        return;
                }

            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine("Вывод HTML завершён");
        }
    }
}
