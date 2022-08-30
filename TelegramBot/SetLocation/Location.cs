using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using TGBot_BonyaBot.TelegramBot.SetLocation;

namespace TGBot_BonyaBot
{
    class Location
    {
        private readonly string sURL = "https://geocode-maps.yandex.ru/1.x/";
        public double longitude;
        public double latitude;

        public Location()
        {
        }
        public async Task<string> GetLocationAsync(double longitude, double latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;

            string info = "";
            string data = "?format=json&lang=ru_RU&kind=house&geocode=" + longitude + "," + latitude + "&apikey=d3bf67ba-c017-4736-b18e-b3dc709a7ed1";
            WebRequest request = WebRequest.Create(sURL + data);
            WebResponse response = await request.GetResponseAsync();

            using (Stream stream = response.GetResponseStream())
            {
                using StreamReader reader = new(stream);
                string s = reader.ReadToEnd();
                if (!s.Split("\"")[37].Equals("0"))
                {
                    string[] s1 = s.Split(",");
                    string addres = s1[12] + s1[13];
                    info = s1[11];
                    info = info + "," + addres;
                }
                else
                {
                    data = "?format=json&lang=ru_RU&kind=house&geocode=" + latitude + "," + longitude + "&apikey=d3bf67ba-c017-4736-b18e-b3dc709a7ed1";
                    request = WebRequest.Create(sURL + data);
                    response = await request.GetResponseAsync();
                    using Stream stream1 = response.GetResponseStream();
                    using StreamReader reader1 = new(stream1);
                    string s0 = reader1.ReadToEnd();
                    string[] s1 = s0.Split(",");
                    string addres = s1[12] + s1[13] + s1[14];
                    info = s1[11];
                    info = info + "," + addres;
                }
            }
            response.Close();

            return info;
        }

        public string GetNearestStores(double longitude, double latitude)
        {
            StoreCoordinates sc = new();
            return sc.GetNearestStoreAsync(latitude, longitude).Result;
        }

    }
}
