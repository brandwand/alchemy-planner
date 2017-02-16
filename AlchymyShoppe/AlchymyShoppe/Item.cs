using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
   
    abstract class  Item
    {
        private String name { get; set; }
        private int price { get; set; }
        private ItemRaritys rarity { get; set; }
        private AlchymicEffects effect { get; set; }
        private Item(String name, int price, ItemRaritys rarity, AlchymicEffects effect)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
            this.effect = effect;
        }
    }
}
