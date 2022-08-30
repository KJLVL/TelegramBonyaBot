using System.Collections.Generic;

namespace TGBot_BonyaBot.Accessories
{
    class PowerSupplies : AccessoriesClass
    {
        public List<string> power;
        public string powerName;
        public List<string> urlList = new();
        public List<string> nameList = new();
        public List<string> priceList = new();

        public PowerSupplies()
        {
            power = new();
            SetPower();
        }
        private void SetPower()
        {
            power.Add("300-490 Вт");
            power.Add("500-690 Вт");
            power.Add("700-890 Вт");
            power.Add("более 1000 Вт");
        }
    }
}
