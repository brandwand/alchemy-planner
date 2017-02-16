using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Ingredient
    {
        String name = "";
        AlchymicEffect[] alchymicEffects = new AlchymicEffect[0];
        int price = 0;

        public Ingredient(String name, AlchymicEffect[] effects, int price)
        {
            int[] bob = new int[3];
            this.name = name;
            this.setAlchymicEffects(effects);
            this.price = price;
        }

        public AlchymicEffect[] getAlchymicEffects()
        {
            return this.alchymicEffects;
        }

        public void setAlchymicEffects(params AlchymicEffect[] effects)
        {
            foreach (AlchymicEffect e in effects)
            {
                this.addAlchymicEffect(e);
            }
        }

        public void addAlchymicEffect(AlchymicEffect alchymicEffect)
        {
            AlchymicEffect[] newAlchymicEffects = new AlchymicEffect[(alchymicEffects.Length + 1)];
            for(int i = 0; i < alchymicEffects.Length; i++)
            {
                newAlchymicEffects[i] = alchymicEffects[i];

            }
            newAlchymicEffects[newAlchymicEffects.Length-1] = alchymicEffect;
            this.setAlchymicEffects(newAlchymicEffects);
        }
    }
}
