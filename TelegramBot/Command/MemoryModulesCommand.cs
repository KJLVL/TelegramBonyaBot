using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot.Command
{
    class MemoryModulesCommand : CommandClass
    {
        public static async Task<string> SetModuleVolume(TelegramBotClient bot, Message message, List<string> moduleVolume)
        {
            List<KeyboardButton> list = new();
            foreach (string c in moduleVolume)
            {
                list.Add(c);
            }
            var keyboard = new ReplyKeyboardMarkup(list)
            {
                ResizeKeyboard = true
            };

            await bot.SendTextMessageAsync(message.Chat.Id, "Выберите объем модуля:", replyMarkup: keyboard);

            return message.Text;
        }

        public static async Task<string> SetType(TelegramBotClient bot, Message message, List<string> type)
        {
            ReplyKeyboardMarkup keyboard;
            if (message.Text == "2-4 ГБ")
            {
                keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new[] {
                    new KeyboardButton("DDR2, DDR3"),
                    new KeyboardButton("DDR3 - DDR4")
                    }
                })
                {
                    ResizeKeyboard = true
                };
            }
            else if (message.Text == "4-8 ГБ")
            {
                keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new[] {
                    new KeyboardButton("DDR3, DDR3L"),
                    new KeyboardButton("DDR3 - DDR4")
                    }
                })
                {
                    ResizeKeyboard = true
                };
            }
            else
            {
                List<KeyboardButton> list = new();
                foreach (string c in type)
                {
                    list.Add(c);
                }
                keyboard = new ReplyKeyboardMarkup(list)
                {
                    ResizeKeyboard = true
                };
            }

            await bot.SendTextMessageAsync(message.Chat.Id, "Какое количество тип модуля вам необходим?", replyMarkup: keyboard);

            return message.Text;
        }
    }
}
