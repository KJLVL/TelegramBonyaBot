using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot.Command
{
    class CaseCommand
    {
        public static async Task<string> SetSize(TelegramBotClient bot, Message message, List<string> size)
        {
            List<KeyboardButton> list = new();
            foreach (string c in size)
            {
                list.Add(c);
            }
            var keyboard = new ReplyKeyboardMarkup(list)
            {
                ResizeKeyboard = true
            };

            await bot.SendTextMessageAsync(message.Chat.Id, "Какой типоразмер вы рассматриваете?", replyMarkup: keyboard);

            return message.Text;
        }
    }
}
