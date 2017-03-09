using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    public class Inventory
    {

        public string Name { get; set; } = "Default";

        private ObservableCollection<Item> Items = new ObservableCollection<Item>();
        //Gold is no longer part of the inventory
        public Inventory()
        {
            //this.Items = generateRandomeInventory();
        }
        public Inventory(ObservableCollection<Item> ItemsForStartingInventory)
        {
            this.Items = ItemsForStartingInventory;
        }
        public Inventory(List<Item> ItemsForStartingInventory)
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            foreach(Item item in ItemsForStartingInventory)
            {
                items.Add(item);
            }
            this.Items = items;
        }
        public Inventory(string name)
        {
            Name = name;
            //this.Items = generateRandomeInventory();
        }
        public Inventory(string name, ObservableCollection<Item> ItemsForStartingInventory)
        {
            Name = name;
            this.Items = ItemsForStartingInventory;
        }
        private ObservableCollection<Item> generateRandomeInventory()
        {
            throw new NotImplementedException();
        }
        //for displaying to the window not sure how to do
        public void ShowInventory()
        {

        }
        public void setitems(ObservableCollection<Item> items)
        {
            this.Items = items;
        }
        public ObservableCollection<Item> getItems()
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