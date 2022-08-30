using HtmlAgilityPack;
using System.Collections.Generic;

namespace TGBot_BonyaBot.Accessories
{
    class AccessoriesClass
    {
        public static void GetAccessories(string url, List<string> nameList, List<string> priceList, List<string> urlList)
        {
            nameList.Clear();
            urlList.Clear();
            priceList.Clear();

            HtmlWeb web = new();
            HtmlDocument doc = web.Load(url);

            var nodesName = doc.DocumentNode.SelectNodes("//a[@class='ProductCardHorizontal__title  Link js--Link Link_type_default']");
            var nodesPrice = doc.DocumentNode.SelectNodes("//span[@class='ProductCardHorizontal__price_current-price js--ProductCardHorizontal__price_current-price ']");
            var nodesUrl = doc.DocumentNode.SelectNodes("//div[@class='ProductCardHorizontal__image-block']");
            for (int i = 0; i < 3; i++)
            {

                string output = nodesUrl[i].InnerHtml.Split('"', '"')[1];
                urlList.Add(output);
                string[] price = nodesPrice[i].InnerText.Split(" ");
                nameList.Add(nodesName[i].InnerText);
                priceList.Add(price[36] + price[37]);
            }
        }
    }

}