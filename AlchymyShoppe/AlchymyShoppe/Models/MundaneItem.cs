using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class MundaneItem : Item
    {

        MundaneItem(string name, String imagePath, int price, Rarity rarity) : base(name, imagePath, price, rarity)
        {

        }
    }
}