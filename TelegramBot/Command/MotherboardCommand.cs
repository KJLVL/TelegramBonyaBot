using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot.Command
{
    class MotherboardCommand : CommandClass
    {
        public static async Task<string> SetSocket(TelegramBotClient bot, Message message, List<string> socket)
        {
            List<KeyboardButton> list = new();
            foreach (string c in socket)
            {
                list.Add(c);
            }
            var keyboard = new ReplyKeyboardMarkup(list)
            {
                ResizeKeyboard = true
            };

            await bot.SendTextMessageAsync(message.Chat.Id, "Выберите подходящий сокет:", replyMarkup: keyboard);

            return message.Text;
        }

        public static async Task<string> SetMemorySlot(TelegramBotClient bot, Message message, List<string> memorySlot)
        {
            ReplyKeyboardMarkup keyboard;
            if (message.Text == "LGA 1151v2 - LGA 1200")
            {
                keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new[] {
                    new KeyboardButton("1-2"),
                    new KeyboardButton("2-4")
                    }
                })
                {
                    ResizeKeyboard = true
                };
            }
            else
            {
                List<KeyboardButton> list = new();
                foreach (string c in memorySlot)
                {
                    list.Add(c);
                }
                keyboard = new ReplyKeyboardMarkup(list)
                {
                    ResizeKeyboard = true
                };
            }

            await bot.SendTextMessageAsync(message.Chat.Id, "Какое количество слотов памяти вам требуется?", replyMarkup: keyboard);

            return message.Text;
        }
    }
}
