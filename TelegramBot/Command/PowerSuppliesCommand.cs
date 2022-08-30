using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot.Command
{
    class PowerSuppliesCommand : CommandClass
    {
        public static async Task<string> SetPower(TelegramBotClient bot, Message message, List<string> power)
        {
            List<KeyboardButton> list = new();
            foreach (string c in power)
            {
                list.Add(c);
            }
            var keyboard = new ReplyKeyboardMarkup(list)
            {
                ResizeKeyboard = true
            };

            await bot.SendTextMessageAsync(message.Chat.Id, "Выберите необходимую мощность:", replyMarkup: keyboard);

            return message.Text;
        }
    }
}
