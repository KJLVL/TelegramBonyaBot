using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot.Command
{
    class VideoCardsCommand: CommandClass
    {
        public static async Task<string> SetMemoryType(TelegramBotClient bot, Message message, List<string> memoryVolume)
        {
            ReplyKeyboardMarkup keyboard;
            if (message.Text == "AMD")
            {
                keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new[] {
                    new KeyboardButton("4-8"),
                    new KeyboardButton("12-16")
                    }
                })
                {
                    ResizeKeyboard = true
                };
            }
            else if (message.Text == "Nvidia")
            {
                keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new[] {
                    new KeyboardButton("2-4"),
                    new KeyboardButton("4-6"),
                    new KeyboardButton("8-12")
                    }
                })
                {
                    ResizeKeyboard = true
                };
            }
            else {
                List<KeyboardButton> list = new();
                foreach (string c in memoryVolume)
                {
                    list.Add(c);
                }
                keyboard = new ReplyKeyboardMarkup(list)
                {
                    ResizeKeyboard = true
                };
            }

            await bot.SendTextMessageAsync(message.Chat.Id, "Какой объем видеопамяти вам требуется?", replyMarkup: keyboard);

            return message.Text;
        }
    }
}
