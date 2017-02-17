using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class AlchemyTable
    {
        Player player;
        Ingredient ingredient1;
        Ingredient ingredient2;
        Ingredient ingredient3;
        Potion potion;

        public AlchemyTable(Player player, Ingredient ingredient1, Ingredient ingredient2, Ingredient ingredient3, Potion potion)
        {
            this.player = player;
            this.ingredient1 = ingredient1;
            this.ingredient2 = ingredient2;
            this.ingredient3 = ingredient3;
            this.potion = potion;
        }
    }
}
