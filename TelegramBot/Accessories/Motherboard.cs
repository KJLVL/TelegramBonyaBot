using System.Collections.Generic;

namespace TGBot_BonyaBot.Accessories
{
    class Motherboard : AccessoriesClass
    {
        public List<string> socket;
        public string socketName;
        public List<string> memorySlot;
        public string memorySlotName;
        public List<string> urlList = new();
        public List<string> nameList = new();
        public List<string> priceList = new();

        public Motherboard()
        {
            socket = new();
            SetSocket();
            memorySlot = new();
            SetMemorySlot();
        }
        private void SetSocket()
        {
            socket.Add("LGA 1151v2 - LGA 1200");
            socket.Add("LGA 1700 - LGA 2066");
            socket.Add("Socket sTRX4 - SocketAM4");
        }
        private void SetMemorySlot()
        {
            memorySlot.Add("2-4");
            memorySlot.Add("4-8");
        }

    }
}
