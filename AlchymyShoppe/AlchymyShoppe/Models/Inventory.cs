using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    public class Inventory
    {
        private List<Item> Items;
        private List<Ingredient> Ingredients;
        private List<Potion> Potions;
        private List<MundaneItem> RegularItems;
        //Gold is no longer part of the inventory
        public Inventory()
        {
            this.Items = generateRandomeInventory();
        }
        private List<Item> generateRandomeInventory()
        {
            throw new NotImplementedException();
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