using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot.Command
{
    class CommandClass
    {
        public static async Task<string> SetModel(TelegramBotClient bot, Message message, List<string> model)
        {
            List<KeyboardButton> list = new();
            foreach (string m in model)
            {
                list.Add(m);
            }
            var keyboard = new ReplyKeyboardMarkup(list)
            {
                ResizeKeyboard = true
            };
            string model1 = message.Text;

            await bot.SendTextMessageAsync(message.Chat.Id, "Какого производителя вы рассматриваете?", replyMarkup: keyboard);
            return model1;
        }

        public static async Task Find(TelegramBotClient bot, Message message, List<string> nameList, List<string> priceList, List<string> urlList, string store)
        {
            var sticker = new InputOnlineFile("CAACAgIAAxkBAAEEuHJifuHoeZTYb1lGQ3dRcQMo7-OBcwACBgUAAnlc4glSqNb8bNcSwCQE");
            await bot.SendStickerAsync(message.Chat.Id, sticker);
            Thread.Sleep(1000);
            _ = PrintResultAsync(bot, message, nameList, priceList, urlList, store);
        }

        private static async Task PrintResultAsync(TelegramBotClient bot, Message message, List<string> nameList, List<string> priceList, List<string> urlLust, string store)
        {
            await bot.SendTextMessageAsync(message.Chat.Id, "Вот что мне удалось найти:");
            for (int i = 0; i < 3; i++)
            {
                await bot.SendTextMessageAsync(message.Chat.Id, nameList[i] + "\nЦена: " + priceList[i] + "\n" + "https://www.citilink.ru/" + urlLust[i]);
            }
            await bot.SendTextMessageAsync(message.Chat.Id, "Ближайший магазин: " + store);
            GetStartMenu(bot, message);
        }

        private static void GetStartMenu(TelegramBotClient bot, Message message)
        {
            _ = StartCommand.GetStartMenu(bot, message);
        }
    }
}
