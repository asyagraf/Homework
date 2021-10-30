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
            Console.WriteLine(sr.ReadToEnd());
        }


    }
}
