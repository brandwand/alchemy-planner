using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    public class AlchymyShoppe
    {
        private Inventory itemsForSell;
        public AlchymyShoppe()
        {
        
        }

        public void addToSell(Player player, Item item)
        {
            player.getInventory().removeItemFromInventory(item);
            itemsForSell.addItemToInventory(item);
        }

        public void addPlayerGold(Player player, Item item)
        {
            int gold = player.getGold();
            gold += item.price;
        }

        public void takeAwayCustomerGold(Customer customer, Item item)
        {
            int gold = customer.gold;
            gold += item.price;
        }
    }
}
