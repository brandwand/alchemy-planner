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
        //Gold is no longer part of the inventory
        public Inventory()
        {
            this.Items = generateRandomeInventory();
        }
        private List<Item> generateRandomeInventory()
        {
            throw new NotImplementedException();
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