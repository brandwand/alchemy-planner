using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    class Customer
    {
        private List<Order> orders;
        private int gold;

        public Customer(List<Order> orders, int gold)
        {
            this.orders = orders;
            this.gold = gold;
        }

        public List<Order> getOrders()
        {
            return orders;
        }
    }
}
