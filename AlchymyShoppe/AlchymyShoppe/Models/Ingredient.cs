﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Ingredient : Item
    {
        public Ingredient(String name, int price, Rarity rarity, AlchymicEffect[] effects) : base(name, price, rarity, effects){}
    }
}