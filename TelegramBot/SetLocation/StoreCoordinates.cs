using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TGBot_BonyaBot.TelegramBot.SetLocation
{
    class StoreCoordinates
    {
        private List<List<double>> coordinates;
        private List<string> storeList;
        public string store;

        public StoreCoordinates()
        {
            coordinates = new();
            storeList = new();
            SetStoreList();
        }

        public async Task<string> GetNearestStoreAsync(double Latitude, double Longitude)
        {
            for (int i = 0; i < storeList.Count; i++)
            {
                var url = "https://geocode-maps.yandex.ru/1.x/?apikey=d3bf67ba-c017-4736-b18e-b3dc709a7ed1&geocode=" + storeList[i];
                WebRequest request1 = WebRequest.Create(url);
                WebResponse response1 = await request1.GetResponseAsync();
                using (Stream stream = response1.GetResponseStream())
                {
                    using StreamReader reader = new(stream);
                    string s = reader.ReadToEnd();
                    string[] s1 = s.Split("<pos>");
                    string[] s2 = s1[1].Split("</pos>");
                    string[] coord = s2[0].Replace('.', ',').Split(" ");
                    List<double> a = new();
                    a.Add(Convert.ToDouble(coord[0]));
                    a.Add(Convert.ToDouble(coord[1]));
                    coordinates.Add(a);
                }
                response1.Close();
            }
            double min = 100;
            for (int i = 0; i < coordinates.Count; i++)
            {
                double a = Math.Abs((Longitude - coordinates[i][0]) * 2);
                double b = Math.Abs((Latitude - coordinates[i][1]) * 2);
                double line = Math.Sqrt(a + b);
                
                if (line < min)
                {
                    min = line;
                    store = storeList[i];
                }
            }
            return store;
        }

        private void SetStoreList()
        {
            storeList.Add("Азов, ул Московская, д.86, 2 этаж");
            storeList.Add("Батайск, ул Кирова, д.1, 2 этаж");
            storeList.Add("Ростов-на-Дону, ул Таганрогская, д.114И, ТЦ Джанфида -1 этаж");
            storeList.Add("Ростов-на-Дону, пр-кт Соколова, д.80\\206, 2 этаж");
            storeList.Add("Ростов-на-Дону, пр-кт Королева, д.12, корп.Б, ТЦ Полюс 1 этаж");
            storeList.Add("Ростов-на-Дону, ул Орская, д.31, ТЦ Меркурий 1 этаж");
            storeList.Add("Ростов-на-Дону, пр-кт Коммунистический, д.30, ТЦ Плаза 1 этаж");
            storeList.Add("Ростов-на-Дону, ул Малиновского, д.25, ТЦ Золотой Вавилон");
        }
    }
}
