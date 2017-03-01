using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    class AlchymyShoppe
    {
        private Inventory itemsForSell;
        public AlchymyShoppe()
        {
        
        }

        public void addToSell(Player player, Item item)
        {
            player.getInventory().removeItemsFromInventory(item);
            itemsForSell.addItemsFromInventory(item);
        }
    }
}
