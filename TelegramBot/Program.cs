using System;

namespace TGBot_BonyaBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new();
            while (true)
            {
                try
                {
                    bot.GetUpdate().Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
            }
        }
    }
}
