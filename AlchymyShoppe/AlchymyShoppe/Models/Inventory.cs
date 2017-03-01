using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Inventory
    {
        private List<Item> Items;
        private int Gold;
        //Multiple construtors for possible difficulty selection. For now use the 2 parameter constructor.
        public Inventory(int gold)
        {
            Gold = gold;
        }
        public Inventory(int gold, List<Item> ItemsForStartingInventory)
        {
            this.Gold = gold;
            this.Items = ItemsForStartingInventory;
        }
        public Inventory(List<Item> ItemsForStartingInventory)
        {
            this.Items = ItemsForStartingInventory;
        }
        //for displaying to the window not sure how to do
        public void ShowInventory()
        {

        }
        public List<Item> getItems()
        {
            return this.Items;
        }
        public int getGold()
        {
            return this.Gold;
        }

        public void removeItemsFromInventory(Item item)
        {
                getItems().Remove(item);
        }

        public void addItemsFromInventory(Item item)
        {
            getItems().Remove(item);
        }
    }
}
