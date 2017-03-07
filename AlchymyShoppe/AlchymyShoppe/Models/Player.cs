using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
   public class Player
    {
        private RecipeBook book;
        private List<Order> orders;
        private Inventory inventory;
        private String name;
        private int gold;
        public Player(String name, int gold)
        {
            this.name = name;
            this.gold = gold;
            inventory = new Inventory();
//            book = new RecipeBook();
        }
        public Inventory getInventory()
        {
            return inventory;
        }
        public void setInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }
        public int getGold()
        {
            return this.gold;
        }
        public void setGold(int gold)
        {
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
        public String getName()
        {
            return this.name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public List<Order> getOrders()
        {
            return this.orders;
        }
        public void setOrders(List<Order> orders)
        {
            this.orders = orders;
        }
    }
}