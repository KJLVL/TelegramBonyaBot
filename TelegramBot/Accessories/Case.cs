using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGBot_BonyaBot.Accessories
{
    class Case
    {
        public List<string> size;
        public string sizeName;
        public List<string> urlList = new();
        public List<string> nameList = new();
        public List<string> priceList = new();

        public Case()
        {
            size = new();
            SetSize();
        }
        private void SetSize()
        {
            size.Add("Desktop, Full-Tower, HTPC");
            size.Add("Micro-Tower");
            size.Add("Midi-Tower");
            size.Add("Mini-Tower");
        }
    }
}
