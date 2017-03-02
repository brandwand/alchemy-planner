using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
   class Player
    {

        private List<Order> orders;
        private Inventory inventory;
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
    }
}
