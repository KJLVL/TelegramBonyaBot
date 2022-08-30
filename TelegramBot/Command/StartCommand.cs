using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot_BonyaBot
{
    class StartCommand
    {
        private string city;
        private string street;
        public List<string> startMenu;

        public StartCommand()
        {
            startMenu = new();
            startMenu.Add("Процессоры");
            startMenu.Add("Видеокарты");
            startMenu.Add("Материнские платы");
            startMenu.Add("Модули памяти");
            startMenu.Add("Блоки питания");
            startMenu.Add("Корпуса");
        }

        public static async void StartComm(TelegramBotClient bot, Message message)
        {
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new[] {
                new KeyboardButton("Поделиться местоположением") { RequestLocation = true,  }
                }
            })
            {
                ResizeKeyboard = true
            };
            var sticker = new InputOnlineFile("CAACAgIAAxkBAAEEcdpiVKMpxSUFFS_1NnAETLsmJoSX7gACOAcAAnlc4gmROp_JHzI1PCME");
            await bot.SendStickerAsync(message.Chat.Id, sticker);
            await bot.SendTextMessageAsync(message.Chat.Id, "Я бот для поиска выгодных цен на комплектующие для пк");
            await bot.SendTextMessageAsync(message.Chat.Id, "Для поиска мне необходимо узнать твой адрес. Нажми на кнопкy, чтобы я нашел где ты находишься.", replyMarkup: keyboard);
        }

        public async Task LocationCommand(TelegramBotClient bot, Message message)
        {
            Location l = new();
            city = await l.GetLocationAsync(message.Location.Longitude, message.Location.Latitude);
            string[] c = city.Split(",");
            city = c[0];
            street = c[1];
            await bot.SendTextMessageAsync(message.Chat.Id, "Ваш адрес: " + city + ", " + street);
            _ = GetMessLocationAsync(bot, message);
        }

        private static async Task GetMessLocationAsync(TelegramBotClient bot, Message message)
        {
            var sticker = new InputOnlineFile("CAACAgIAAxkBAAEEc_tiVeRTxaBSeVGUPRKFBfjEqv6chAACIgUAAnlc4gmbJC1m6sAZxSME");
            await bot.SendStickerAsync(message.Chat.Id, sticker);
            await bot.SendTextMessageAsync(message.Chat.Id, "Теперь давайте найдем комплектующие, которые вас интересуют!");
            _ = SetMenuAccessoriesAsync(bot, message);
        }
        public static async Task SetMenuAccessoriesAsync(TelegramBotClient bot, Message message)
        {
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new[] {
                new KeyboardButton("Процессоры"),
                new KeyboardButton("Видеокарты"),
                new KeyboardButton("Материнские платы")
                },
                new[] {
                new KeyboardButton("Модули памяти"),
                new KeyboardButton("Блоки питания"),
                new KeyboardButton("Корпуса")
                }
            })
            {
                ResizeKeyboard = true
            };
            await bot.SendTextMessageAsync(message.Chat.Id, "Выберите из списка то, что хотите найти", replyMarkup: keyboard);
        }

        public static async Task GetStartMenu(TelegramBotClient bot, Message message)
        {
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new[] {
                new KeyboardButton("Продолжить поиск"),
                new KeyboardButton("Остановить поиск")
                }
            })
            {
                ResizeKeyboard = true
            };
            await bot.SendTextMessageAsync(message.Chat.Id, "Выберите:", replyMarkup: keyboard);
        }

        public static async Task StartMenuAsync(TelegramBotClient bot, Message message)
        {
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new[] {
                new KeyboardButton("/start")
                }
            })
            {
                ResizeKeyboard = true
            };
            _ = await bot.SendTextMessageAsync(message.Chat.Id, "Для нового поиска нажмите кнопку:", replyMarkup: keyboard);
        }

    }
}
