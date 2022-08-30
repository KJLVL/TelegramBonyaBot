using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGBot_BonyaBot.Accessories
{
    class MemoryModules
    {
        public List<string> moduleVolume;
        public string moduleVolumeName;
        public List<string> type;
        public string typeName;
        public List<string> urlList = new();
        public List<string> nameList = new();
        public List<string> priceList = new();

        public MemoryModules()
        {
            moduleVolume = new();
            SetModuleVolume();
            type = new();
            SetType();
        }
        private void SetModuleVolume()
        {
            moduleVolume.Add("2-4 ГБ");
            moduleVolume.Add("4-8 ГБ");
            moduleVolume.Add("8-16 ГБ");
        }
        private void SetType()
        {
            type.Add("DDR3, DDR3L");
            type.Add("DDR3 - DDR4");
            type.Add("DDR4, DDR5");
        }
        public void GetMemoryModules(string url)
        {
            urlList = new();
            nameList = new();
            priceList = new();
            HtmlWeb web = new();
            HtmlDocument doc = web.Load(url);

            var nodesName = doc.DocumentNode.SelectNodes("//a[@class=' ProductCardVertical__name  Link js--Link Link_type_default']");
            var nodesPrice = doc.DocumentNode.SelectNodes("//span[@class='ProductCardVerticalPrice__price-current_current-price js--ProductCardVerticalPrice__price-current_current-price ']");
            var nodesUrl = doc.DocumentNode.SelectNodes("//a[@class=' ProductCardVertical__link link_gtm-js  Link js--Link Link_type_default']");
            for (int i = 0; i < 3; i++)
            {
                var href = nodesUrl[i].Attributes["href"].Value;
                urlList.Add(href);
                string[] price = nodesPrice[i].InnerText.Split(" ");
                nameList.Add(nodesName[i].InnerText);
                priceList.Add(price[36] + price[37]);
            }
        }

    }
}
