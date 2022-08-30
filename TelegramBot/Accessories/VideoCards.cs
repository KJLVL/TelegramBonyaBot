using System.Collections.Generic;
using TGBot_BonyaBot.Accessories;

namespace TGBot_BonyaBot.Command
{
    class VideoCards : AccessoriesClass
    {
        public List<string> model;
        public string modelName;
        public List<string> memoryVolume;
        public string memoryVolumeName;
        public List<string> urlList = new();
        public List<string> nameList = new();
        public List<string> priceList = new();

        public VideoCards()
        {
            model = new();
            SetModel();
            memoryVolume = new();
            SetMemoryVolume();           
        }

        private void SetModel()
        {
            model.Add("Nvidia");
            model.Add("AMD");
            model.Add("Пропустить");
        }

        private void SetMemoryVolume()
        {
            memoryVolume.Add("2-4");
            memoryVolume.Add("4-6");
            memoryVolume.Add("8-12");
            memoryVolume.Add("12-16");
        }

    }
}
