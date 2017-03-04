using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    public class MundaneItem : Item
    {

        public MundaneItem(string name, string imagePath, int price, Rarity rarity) : base(name, imagePath, price, rarity)
        {

        }
    }
}