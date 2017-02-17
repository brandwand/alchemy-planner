using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Inventory
    {
        private List<> Items;
        private int Gold;
        public Inventory(int gold)
        {
            Gold = gold;
        }
        public Inventory(int gold, List<> ItemsForStartingInventory)
        {
            Gold = gold;
            Items = ItemsForStartingInventory;
        }
        public Inventory(List<> ItemsForStartingInventory)
        {
            Items = ItemsForStartingInventory;
        }
        public bool StoreInventory()
        {

        }
        public bool LoadInventory()
        {

        }
        public void ShowInventory()
        {

        }
    }
}
