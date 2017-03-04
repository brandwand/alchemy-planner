using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
   class Player
    {
        private RecipeBook book;
        private List<Order> orders;
        private Inventory inventory = new Inventory(10, new List<Item>());
        public Inventory getInventory()
        {
            return inventory;
        }
        public void setInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }
        private String name { get; set; }
        public int gold { get; set; }
        public Player(String name, int gold)
        {
            this.name = name;            
            this.gold = gold;
        }
        public RecipeBook getPlayerBook()
        {
            return book;
        }
        public void setPlayerBook(RecipeBook book)
        {
            this.book = book;
        }

        public void addItemToInventory(Item item)
        {
            inventory.addItemToInventory(item);
        }
    }
}
