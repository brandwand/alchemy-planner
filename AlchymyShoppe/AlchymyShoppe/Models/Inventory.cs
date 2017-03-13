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
        private ObservableCollection<Ingredient> Ingredients = new ObservableCollection<Ingredient>();
        private ObservableCollection<Potion> Potions = new ObservableCollection<Potion>();
        private ObservableCollection<MundaneItem> RegularItems = new ObservableCollection<MundaneItem>();

        //Gold is no longer part of the inventory
        public Inventory()
        {
            this.Items = generateRandomInventory();
        }
        public Inventory(ObservableCollection<Item> ItemsForStartingInventory)
        {
            this.Items = ItemsForStartingInventory;
        }
        public Inventory(List<Ingredient> ItemsForStartingInventory, List<Potion> PotionsForStartingInventory, List<MundaneItem> RegularItemsForStartingInventory)
        {
            if(ItemsForStartingInventory != null)
            {
                ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
                foreach(Ingredient ing in ItemsForStartingInventory)
                {
                    ingredients.Add(ing);
                }
                this.Ingredients = ingredients;
                this.Items.Concat(Ingredients);
            }

            if (PotionsForStartingInventory != null)
            {
                ObservableCollection<Potion> potions = new ObservableCollection<Potion>();
                foreach (Potion pot in PotionsForStartingInventory)
                {
                    potions.Add(pot);
                }
                this.Potions = potions;
                this.Items.Concat(Potions);
            }

            if (RegularItemsForStartingInventory != null)
            {
                ObservableCollection<MundaneItem> mundaneItems = new ObservableCollection<MundaneItem>();
                foreach (MundaneItem item in RegularItemsForStartingInventory)
                {
                    mundaneItems.Add(item);
                }
                this.RegularItems = mundaneItems;
                this.Items.Concat(RegularItems);
            }
        }
        public Inventory(string name)
        {
            Name = name;
            this.Items = generateRandomInventory();
        }
        public Inventory(string name, ObservableCollection<Item> ItemsForStartingInventory)
        {
            Name = name;
            this.Items = ItemsForStartingInventory;
        }
        private ObservableCollection<Item> generateRandomInventory()
        {
            Random rand = new Random();
            ObservableCollection<Item> newPlayerIngredients = new ObservableCollection<Item>();
            for(int i = 0; i < 15; i++)
            {
                int ingredientIndex = rand.Next(WorldController.allIngredients.Count);
                int numOfItem = rand.Next(2) + 1;
                for (int j = 0; j < numOfItem; j++)
                {
                    newPlayerIngredients.Add(WorldController.allIngredients[ingredientIndex]);
                    Ingredients.Add(WorldController.allIngredients[ingredientIndex]);
                }
            }
            return newPlayerIngredients;
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
        public ObservableCollection<Ingredient> getIngredients()
        {
            return Ingredients;
        } 
        public void removeIngredientFromInventory(Ingredient ingredient)
        {
            Items.Remove(ingredient);
            Ingredients.Remove(ingredient);
        }
        public void addIngredientToInventory(Ingredient ingredient)
        {
            Items.Add(ingredient);
            Ingredients.Add(ingredient);
        }
        public void removeItemFromInventory(Item item)
        {
            if(typeof(Ingredient) == item.GetType())
            {
                Ingredients.Remove((Ingredient)item);
            } else if(typeof(Potion) == item.GetType())
            {
                Potions.Remove((Potion)item);
            } else if(typeof(MundaneItem) == item.GetType())
            {
                RegularItems.Remove((MundaneItem)item);
            }

            Items.Remove(item);
        }
        public void addItemToInventory(Item item)
        {
            if (typeof(Ingredient) == item.GetType())
            {
                Ingredients.Add((Ingredient)item);
            }
            else if (typeof(Potion) == item.GetType())
            {
                Potions.Add((Potion)item);
            }
            else if (typeof(MundaneItem) == item.GetType())
            {
                RegularItems.Add((MundaneItem)item);
            }

            Items.Add(item);

        }
    }
}