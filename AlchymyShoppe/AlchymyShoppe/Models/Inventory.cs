using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    public class Inventory
    {

        public string Name { get; set; } = "Default";

        private List<Item> Items = new List<Item>();
        //Gold is no longer part of the inventory
        public Inventory()
        {
            //this.Items = generateRandomeInventory();
        }
        public Inventory(List<Item> ItemsForStartingInventory)
        {
            this.Items = ItemsForStartingInventory;
        }
        public Inventory(string name)
        {
            Name = name;
            //this.Items = generateRandomeInventory();
        }
        public Inventory(string name, List<Item> ItemsForStartingInventory)
        {
            Name = name;
            this.Items = ItemsForStartingInventory;
        }
        private List<Item> generateRandomeInventory()
        {
            throw new NotImplementedException();
        }
        //for displaying to the window not sure how to do
        public void ShowInventory()
        {

        }
        public void setitems(List<Item> items)
        {
            this.Items = items;
        }
        public List<Item> getItems()
        {
            return this.Items;
        }
        public void removeItemFromInventory(Item item)
        {
                Items.Remove(item);
        }
        public void addItemToInventory(Item item)
        {
            Items.Add(item);
        }
    }
}