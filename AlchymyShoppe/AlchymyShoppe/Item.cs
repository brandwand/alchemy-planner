using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
   
    abstract class  Item
    {
        public String name { get; set; }
        public int price { get; set; }
        public String rarity { get; set; }
        public String effect { get; set; }
        public Item(String name, int price, String rarity, String rffect)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
            this.effect = effect;
        }
    }
}
