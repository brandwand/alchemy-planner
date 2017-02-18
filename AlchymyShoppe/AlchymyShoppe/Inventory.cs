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
        //Multiple construtors for possible difficulty selection. For now use the 2 parameter constructor.
        public Inventory(int gold)
        {
            Gold = gold;
        }
        public Inventory(int gold, List<> ItemsForStartingInventory)
        {
            this.Gold = gold;
            this.Items = ItemsForStartingInventory;
        }
        public Inventory(List<> ItemsForStartingInventory)
        {
            this.Items = ItemsForStartingInventory;
        }
        //used for saving the inventory from outside the class.      
        public bool StoreInventory()
        {
            Chest.SaveInventory();
        }
        public bool LoadInventory()
        {
            this = Chest.LoadInventory();
        }
        //for displaying to the window not sure how to do
        public void ShowInventory()
        {

        }
        public List<> getItems()
        {
            return this.Items;
        }
        public int getGold()
        {
            return this.Gold;
        }
    }
}
