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
        private List<Ingredient> Ingredients;
        private List<Potion> Potions;
        private List<MundaneItem> RegularItems;
        //Gold is no longer part of the inventory
        public Inventory()
        {
            this.Items = generateRandomeInventory();
        }
        public Inventory(List<Item> ItemsForStartingInventory)
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
        public Inventory(string name, List<Item> ItemsForStartingInventory)
        {
            Name = name;
            this.Items = ItemsForStartingInventory;
        }
        private List<Item> generateRandomeInventory()
        {
            Random rand = new Random();
            List<Ingredient> newPlayerIngredients;
            for(int i = 0; i < 15; i++)
            {
                int temp = rand.Next(WorldController.allIngredients.Count);

            }
            return newPlayerIngredients;
        }
        //for displaying to the window not sure how to do
        public void ShowInventory()
        {

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