using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TGBot_BonyaBot.Accessories;
using TGBot_BonyaBot.Command;

namespace TGBot_BonyaBot
{
    class Bot
    {
        private const string TOKEN = "5453699234:AAGZWAtRtcCcikZbNlAtu00JoMVYqHrjlzo";
        private readonly StartCommand startCommand = new();
        private readonly Processors processors = new();
        private readonly VideoCards videoCards = new();
        private readonly Motherboard motherboard = new();
        private readonly MemoryModules memoryModules = new();
        private readonly PowerSupplies powerSupplies = new();
        private readonly Case cases = new();

        public async Task GetUpdate()
        {
            TelegramBotClient bot = new(TOKEN);
            int offset = 0;
            int timeout = 0;
            string store = "";
            string currentAction = "initial";
            Location l = new();
            try
            {
                var updates = await bot.GetUpdatesAsync(offset, timeout);
                await bot.SetWebhookAsync("");
                
                while (true)
                {
                    switch (currentAction)
                    {
                        case "initial":
                            updates = await bot.GetUpdatesAsync(offset, timeout);
                            foreach (var update in updates)
                            {
                                var message = update.Message;
                                if (message.Text == "/start")
                                {
                                    StartCommand.StartComm(bot, message);
                                }
                                if (message.Location != null)
                                {
                                    _ = startCommand.LocationCommand(bot, message);
                                    store = l.GetNearestStores(message.Location.Longitude, message.Location.Latitude);
                                }
                                if (startCommand.startMenu.Contains(message.Text))
                                {
                                    currentAction = message.Text;
                                }
                                offset = update.Id + 1;
                            }
                            break;
                        case "Процессоры":
                            foreach (var update in updates)
                            {
                                var message = update.Message;
                                if (message.Text == "Процессоры")
                                {
                                    var mes = CommandClass.SetModel(bot, message, processors.model);
                                    message.Text = await mes;
                                }
                                if (processors.model.Contains(message.Text))
                                {
                                    switch (message.Text)
                                    {
                                        case "AMD":
                                            processors.modelName = "?f=discount.any%2Crating.any%2Camd &pf=discount.any%2Crating.any";
                                            break;
                                        case "Intel":
                                            processors.modelName = "?f=discount.any%2Crating.any%2Cintel &pf=discount.any%2Crating.any";
                                            break;
                                        case "Пропустить":
                                            processors.modelName = "?f=discount.any%2Crating.any%2Camd%2Cintel &pf=discount.any%2Crating.any%2Camd";
                                            break;
                                    }
                                    var mes = ProcessorsCommand.SetCore(bot, message, processors.core);
                                    message.Text = await mes;
                                }
                                if (processors.core.Contains(message.Text))
                                {
                                    switch (message.Text)
                                    {
                                        case "2-4 ядра":
                                            processors.coreNum = "%2C8554_262%2C8554_264";
                                            break;
                                        case "6-8 ядер":
                                            processors.coreNum = "%2C8554_266%2C8554_268";
                                            break;
                                        case "10 и более":
                                            processors.coreNum = "%2C8554_2612%2C8554_2616";
                                            break;
                                    }
                                    string[] model = processors.modelName.Split(" ");
                                    string url = "https://www.citilink.ru/catalog/processory/" + model[0] + processors.coreNum + model[1] + "&sorting=price_asc";
                                    AccessoriesClass.GetAccessories(url, processors.nameList, processors.priceList, processors.urlList);
                                    _ = CommandClass.Find(bot, message, processors.nameList, processors.priceList, processors.urlList, store);
                                }
                                if (message.Text == "Продолжить поиск")
                                {
                                    _ = StartCommand.SetMenuAccessoriesAsync(bot, message);
                                    currentAction = "initial";
                                }
                                if (message.Text == "Остановить поиск")
                                {
                                    _ = StartCommand.StartMenuAsync(bot, message);
                                    currentAction = "initial";
                                }
                                offset = update.Id + 1;
                            }
                            updates = await bot.GetUpdatesAsync(offset, timeout);
                            break;
                        case "Видеокарты":
                            foreach (var update in updates)
                            {
                                var message = update.Message;
                                if (message.Text == "Видеокарты")
                                {
                                    _ = CommandClass.SetModel(bot, message, videoCards.model);
                                }
                                if (videoCards.model.Contains(message.Text))
                                {
                                    switch (message.Text)
                                    {
                                        case "AMD":
                                            videoCards.modelName = "?sorting=price_asc&f=discount.any%2Crating.any%2C11525_29amd";
                                            break;
                                        case "Nvidia":
                                            videoCards.modelName = "?sorting=price_asc&f=discount.any%2Crating.any%2C11525_29nvidia";
                                            break;
                                        case "Пропустить":
                                            videoCards.modelName = "?sorting=price_asc&f=discount.any%2Crating.any%2C11525_29amd%2C11525_29nvidia";
                                            break;
                                    }
                                    var mes = VideoCardsCommand.SetMemoryType(bot, message, videoCards.memoryVolume);
                                    message.Text = await mes;
                                }
                                if (videoCards.memoryVolume.Contains(message.Text) || message.Text == "4-8")
                                {
                                    switch (message.Text)
                                    {
                                        case "2-4":
                                            videoCards.memoryVolumeName = "%2C304_292d1gb%2C304_294d1gb&pf=discount.any%2Crating.any%2C304_292d1gb";
                                            break;
                                        case "4-6":
                                            videoCards.memoryVolumeName = "%2C304_294d1gb%2C304_296d1gb&pf=discount.any%2Crating.any%2C304_294d1gb";
                                            break;
                                        case "8-12":
                                            videoCards.memoryVolumeName = "%2C304_298d1gb%2C304_2912d1gb&pf=discount.any%2Crating.any%2C304_298d1gb";
                                            break;
                                        case "4-8":
                                            videoCards.memoryVolumeName = "%2Crating.any%2C304_294d1gb%2C304_296d1gb%2C304_298d1gb&pf=discount.any%2Crating.any%2C304_294d1gb%2C304_296d1gb";
                                            break;
                                        case "12-16":
                                            videoCards.memoryVolumeName = "%2C304_2912d1gb%2C304_2916d1gb&pf=discount.any%2Crating.any%2C304_2912d1gb";
                                            break;
                                    }
                                    string url = "https://www.citilink.ru/catalog/videokarty/" + videoCards.modelName + videoCards.memoryVolumeName;
                                    AccessoriesClass.GetAccessories(url, videoCards.nameList, videoCards.priceList, videoCards.urlList);
                                    _ = CommandClass.Find(bot, message, videoCards.nameList, videoCards.priceList, videoCards.urlList, store);
                                }
                                if (message.Text == "Продолжить поиск")
                                {
                                    _ = StartCommand.SetMenuAccessoriesAsync(bot, message);
                                    currentAction = "initial";
                                }
                                if (message.Text == "Остановить поиск")
                                {
                                    _ = StartCommand.StartMenuAsync(bot, message);
                                    currentAction = "initial";
                                }
                                offset = update.Id + 1;
                            }
                            updates = await bot.GetUpdatesAsync(offset, timeout);
                            break;
                        case "Материнские платы":
                            foreach (var update in updates)
                            {
                                var message = update.Message;
                                if (message.Text == "Материнские платы")
                                {
                                    _ = MotherboardCommand.SetSocket(bot, message, motherboard.socket);
                                }
                                if (motherboard.socket.Contains(message.Text))
                                {
                                    switch (message.Text)
                                    {
                                        case "LGA 1151v2 - LGA 1200":
                                            motherboard.socketName = "?sorting=price_asc&f=discount.any%2Crating.any%2C239_27lgad11151v2%2C239_27lgad11200";
                                            break;
                                        case "LGA 1700 - LGA 2066":
                                            motherboard.socketName = "?sorting=price_asc&f=discount.any%2Crating.any%2C239_27lgad11700%2C239_27lgad12066";
                                            break;
                                        case "Socket sTRX4 - SocketAM4":
                                            motherboard.socketName = "?sorting=price_asc&f=discount.any%2Crating.any%2C239_27socketd1strx4%2C239_27socketam4";
                                            break;
                                    }
                                    var mes = MotherboardCommand.SetMemorySlot(bot, message, motherboard.memorySlot);
                                    message.Text = await mes;
                                }
                                if (motherboard.memorySlot.Contains(message.Text) || message.Text == "1-2")
                                {
                                    switch (message.Text)
                                    {
                                        case "1-2":
                                            motherboard.memorySlotName = "%2C8778_271%2C8778_272&pf=discount.any%2Crating.any%2C239_27lgad11151v2%2C239_27lgad11200%2C8778_271";
                                            break;
                                        case "2-4":
                                            motherboard.memorySlotName = "%2C8778_272%2C8778_274&pf=discount.any%2Crating.any%2C239_27lgad11700%2C239_27lgad12066%2C8778_272";
                                            break;
                                        case "4-8":
                                            motherboard.memorySlotName = "%2C8778_274%2C8778_278&pf=discount.any%2Crating.any%2C239_27socketd1strx4%2C239_27socketam4%2C8778_274";
                                            break;
                                    }
                                    string url = "https://www.citilink.ru/catalog/materinskie-platy/" + motherboard.socketName + motherboard.memorySlotName;
                                    AccessoriesClass.GetAccessories(url, motherboard.nameList, motherboard.priceList, motherboard.urlList);
                                    _ = CommandClass.Find(bot, message, motherboard.nameList, motherboard.priceList, motherboard.urlList, store);
                                }
                                if (message.Text == "Продолжить поиск")
                                {
                                    _ = StartCommand.SetMenuAccessoriesAsync(bot, message);
                                    currentAction = "initial";
                                }
                                if (message.Text == "Остановить поиск")
                                {
                                    _ = StartCommand.StartMenuAsync(bot, message);
                                    currentAction = "initial";
                                }
                                offset = update.Id + 1;
                            }
                            updates = await bot.GetUpdatesAsync(offset, timeout);
                            break;
                        case "Модули памяти":
                            foreach (var update in updates)
                            {
                                var message = update.Message;
                                if (message.Text == "Модули памяти")
                                {
                                    _ = MemoryModulesCommand.SetModuleVolume(bot, message, memoryModules.moduleVolume);
                                }
                                if (memoryModules.moduleVolume.Contains(message.Text))
                                {
                                    switch (message.Text)
                                    {
                                        case "2-4 ГБ":
                                            memoryModules.moduleVolumeName = "?sorting=price_asc&f=discount.any%2Crating.any  %2C650_282d1gb%2C650_284d1gb&pf=discount.any%2Crating.any %2C650_282d1gb";
                                            break;
                                        case "4-8 ГБ":
                                            memoryModules.moduleVolumeName = "?sorting=price_asc&f=discount.any%2Crating.any %2C650_284d1gb%2C650_288d1gb&pf=discount.any%2Crating.any %2C650_284d1gb";
                                            break;
                                        case "8-16 ГБ":
                                            memoryModules.moduleVolumeName = "?sorting=price_asc&f=discount.any%2Crating.any %2C650_288d1gb%2C650_2816d1gb&pf=discount.any%2Crating.any %2C650_288d1gb";
                                            break;
                                    }
                                    var mes = MemoryModulesCommand.SetType(bot, message, memoryModules.type);
                                    message.Text = await mes;
                                }
                                if (memoryModules.type.Contains(message.Text) || message.Text == "DDR2, DDR3")
                                {
                                    switch (message.Text)
                                    {
                                        case "DDR2, DDR3":
                                            memoryModules.typeName = "%2C647_28ddr2%2C647_28ddr3 %2C647_28ddr2%2C650_282d1gb";
                                            break;
                                        case "DDR3, DDR3L":
                                            memoryModules.typeName = "%2C647_28ddr3%2C647_28ddr3l%2C650_284d1gb %2C647_28ddr3%2C650_284d1gb";
                                            break;
                                        case "DDR3 - DDR4":
                                            memoryModules.typeName = "%2C647_28ddr3%2C647_28ddr3l%2C647_28ddr4 %2C647_28ddr3%2C647_28ddr3l%2C650_282d1g";
                                            break;
                                        case "DDR4, DDR5":
                                            memoryModules.typeName = "%2C647_28ddr4%2C647_28ddr5%2C650_288d1gb %2C647_28ddr4%2C650_288d1gb";
                                            break;
                                    }
                                    string[] moduleVolume = memoryModules.moduleVolumeName.Split(" ");
                                    string[] type = memoryModules.typeName.Split(" ");
                                    string url = "https://www.citilink.ru/catalog/moduli-pamyati/" + moduleVolume[0] + type[0] + moduleVolume[1] + type[1] + moduleVolume[2];
                                    memoryModules.GetMemoryModules(url);
                                    _ = CommandClass.Find(bot, message, memoryModules.nameList, memoryModules.priceList, memoryModules.urlList, store);
                                }
                                if (message.Text == "Продолжить поиск")
                                {
                                    _ = StartCommand.SetMenuAccessoriesAsync(bot, message);
                                    currentAction = "initial";
                                }
                                if (message.Text == "Остановить поиск")
                                {
                                    _ = StartCommand.StartMenuAsync(bot, message);
                                    currentAction = "initial";
                                }
                                offset = update.Id + 1;
                            }
                            updates = await bot.GetUpdatesAsync(offset, timeout);
                            break;
                        case "Блоки питания":
                            foreach (var update in updates)
                            {
                                var message = update.Message;
                                if (message.Text == "Блоки питания")
                                {
                                    _ = PowerSuppliesCommand.SetPower(bot, message, powerSupplies.power);
                                }
                                if (powerSupplies.power.Contains(message.Text))
                                {
                                    switch (message.Text)
                                    {
                                        case "300-490 Вт":
                                            powerSupplies.powerName = "?sorting=price_asc&f=discount.any%2Crating.any%2C314_40%2C315_40&pf=discount.any%2Crating.any%2C314_40";
                                            break;
                                        case "500-690 Вт":
                                            powerSupplies.powerName = "?sorting=price_asc&f=discount.any%2Crating.any%2C317_40%2C2834_40&pf=discount.any%2Crating.any%2C317_40";
                                            break;
                                        case "700-890 Вт":
                                            powerSupplies.powerName = "?sorting=price_asc&f=discount.any%2Crating.any%2C2835_40%2C2836_40&pf=discount.any%2Crating.any%2C2835_40";
                                            break;
                                        case "более 1000 Вт":
                                            powerSupplies.powerName = "?sorting=price_asc&f=discount.any%2Crating.any%2C2838_40&pf=discount.any%2Crating.any";
                                            break;
                                    }
                                    string url = "https://www.citilink.ru/catalog/bloki-pitaniya/" + powerSupplies.powerName;
                                    AccessoriesClass.GetAccessories(url, powerSupplies.nameList, powerSupplies.priceList, powerSupplies.urlList);
                                    _ = CommandClass.Find(bot, message, powerSupplies.nameList, powerSupplies.priceList, powerSupplies.urlList, store);
                                }
                                if (message.Text == "Продолжить поиск")
                                {
                                    _ = StartCommand.SetMenuAccessoriesAsync(bot, message);
                                    currentAction = "initial";
                                }
                                if (message.Text == "Остановить поиск")
                                {
                                    _ = StartCommand.StartMenuAsync(bot, message);
                                    currentAction = "initial";
                                }
                                offset = update.Id + 1;
                            }
                            updates = await bot.GetUpdatesAsync(offset, timeout);
                            break;
                        case "Корпуса":
                            foreach (var update in updates)
                            {
                                var message = update.Message;
                                if (message.Text == "Корпуса")
                                {
                                    _ = CaseCommand.SetSize(bot, message, cases.size);
                                }
                                if (cases.size.Contains(message.Text))
                                {
                                    switch (message.Text)
                                    {
                                        case "Desktop, Full-Tower, HTPC":
                                            cases.sizeName = "?sorting=price_asc&f=discount.any%2Crating.any%2C12828_41desktop%2C12828_41fulla5tower%2C12828_41htpc&pf=discount.any%2Crating.any%2C12828_41desktop%2C12828_41fulla5tower";
                                            break;
                                        case "Micro-Tower":
                                            cases.sizeName = "?sorting=price_asc&f=discount.any%2Crating.any%2C12828_41microa5tower&pf=discount.any%2Crating.any";
                                            break;
                                        case "Midi-Tower":
                                            cases.sizeName = "?sorting=price_asc&f=discount.any%2Crating.any%2C12828_41midia5tower&pf=discount.any%2Crating.any";
                                            break;
                                        case "Mini-Tower":
                                            cases.sizeName = "?sorting=price_asc&f=discount.any%2Crating.any%2C12828_41minia5tower&pf=discount.any%2Crating.any";
                                            break;
                                    }
                                    string url = "https://www.citilink.ru/catalog/korpusa/" + cases.sizeName;
                                    AccessoriesClass.GetAccessories(url, cases.nameList, cases.priceList, cases.urlList);
                                    _ = CommandClass.Find(bot, message, cases.nameList, cases.priceList, cases.urlList, store);
                                }
                                if (message.Text == "Продолжить поиск")
                                {
                                    _ = StartCommand.SetMenuAccessoriesAsync(bot, message);
                                    currentAction = "initial";
                                }
                                if (message.Text == "Остановить поиск")
                                {
                                    _ = StartCommand.StartMenuAsync(bot, message);
                                    currentAction = "initial";
                                }
                                offset = update.Id + 1;
                            }
                            updates = await bot.GetUpdatesAsync(offset, timeout);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

    }
}
