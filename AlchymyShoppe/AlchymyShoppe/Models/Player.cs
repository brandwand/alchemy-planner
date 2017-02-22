using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Player
    {
        private String name { get; set; }
        private int gold { get; set; }
        public Player(String name, int gold)
        {
            this.name = name;            
            this.gold = gold;
        }
    }
}
