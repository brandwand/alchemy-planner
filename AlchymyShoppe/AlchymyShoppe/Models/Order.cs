using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    public class Order : MundaneItem
    {
        //Sets a new order Item.
        private Item orderItem;

        public Order(string name, string orderPath, int price, Rarity rarity, Item orderItem) : base(name, orderPath, price, rarity)
        {
            this.orderItem = orderItem;
        }

        public Item OrderItem
        {
            get { return orderItem; }
        }

    }
}
