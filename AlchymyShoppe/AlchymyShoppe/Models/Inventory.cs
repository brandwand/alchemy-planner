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
        private List<Ingredient> Ingredients;
        private List<Potion> Potions;
        private List<MundaneItem> RegularItems;
        //Gold is no longer part of the inventory
        public Inventory()
        {
            this.Items = generateRandomeInventory();
        }
        public Inventory(ObservableCollection<Item> ItemsForStartingInventory)
        {
            this.Items = ItemsForStartingInventory;
        }
        public Inventory(List<Ingredient> ItemsForStartingInventory, List<Potion> PotionsForStartingInventory, List<MundaneItem> regurlarItemsForStartingInventory)
        {
            this.Ingredients = ItemsForStartingInventory;
            this.Potions = PotionsForStartingInventory;
            this.RegularItems = regurlarItemsForStartingInventory;
            this.Items.Concat(Ingredients);
            this.Items.Concat(Potions);
            this.Items.Concat(RegularItems);
        }
        public Inventory(string name)
        {
            Name = name;
            this.Items = generateRandomeInventory();
        }
        public Inventory(string name, ObservableCollection<Item> ItemsForStartingInventory)
        {
            Name = name;
            this.Items = ItemsForStartingInventory;
        }
        private ObservableCollection<Item> generateRandomeInventory()
        {
            Random rand = new Random();
            List<Ingredient> newPlayerIngredients = new List<Ingredient>();
            for(int i = 0; i < 15; i++)
            {
                int temp = rand.Next(WorldController.allIngredients.Count);
                int numOfItem = rand.Next(3) + 1;
                for (int j = 0; j < numOfItem; j++)
                {
                    newPlayerIngredients.Add(WorldController.allIngredients[temp]);
                }
            }
            return newPlayerIngredients.Cast<Item>().ToList();
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