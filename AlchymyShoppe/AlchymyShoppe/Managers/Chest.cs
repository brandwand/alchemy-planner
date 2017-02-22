using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    static class Chest
    {
        public static Inventory LoadInventory()
        {
            Inventory inventory = new Inventory(3);
            return inventory;
        }
        public static bool SaveInventory()
        {
            return false;
        }
    }
}
