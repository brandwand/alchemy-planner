using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Ingredient : Item
    {
        String name = "";
        AlchymicEffect[] alchymicEffects = new AlchymicEffect[0];
        int price = 0;

        public Ingredient(String name, int price, ItemRarity rarity, AlchymicEffect[] effects)
        {
            super(name, price, rarity, effects);
        }

        public AlchymicEffect[] getAlchymicEffects()
        {
            return this.alchymicEffects;
        }
        
    }
}
