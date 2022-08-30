using System.Collections.Generic;
using TGBot_BonyaBot.Accessories;

namespace TGBot_BonyaBot
{
    class Processors : AccessoriesClass
    {

        public List<string> model;
        public string modelName;
        public List<string> core;
        public string coreNum;
        public List<string> urlList = new();
        public List<string> nameList = new();
        public List<string> priceList = new();

        public Processors()
        {
            model = new();
            SetModel();
            core = new();
            SetCore();
        }

        private void SetModel()
        {
            model.Add("AMD");
            model.Add("Intel");
            model.Add("Пропустить");
        }
        private void SetCore()
        {
            core.Add("2-4 ядра");
            core.Add("6-8 ядер");
            core.Add("10 и более");
        }

    }
}
