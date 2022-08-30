using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot.Command
{
    class ProcessorsCommand : CommandClass
    {
        public static async Task<string> SetCore(TelegramBotClient bot, Message message, List<string> core)
        {
            List<KeyboardButton> list = new();
            foreach (string c in core)
            {
                list.Add(c);
            }
            var keyboard = new ReplyKeyboardMarkup(list)
            {
                ResizeKeyboard = true
            };
            await bot.SendTextMessageAsync(message.Chat.Id, "Какое количество ядер вам необходимо?", replyMarkup: keyboard);
            
            return message.Text;
        }

    }
}
