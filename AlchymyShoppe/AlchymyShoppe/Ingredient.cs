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
        Effect[] effects = new Effect[0]();
        int price = 0;

        public Ingredient(String name, Effect[] effects, int price)
        {
            this.name = name;
            this.setEffects(effects);
            this.price = price;
        }

        public Effect[] getEffects()
        {
            return this.effects;
        }

        public void setEffects(params Effect[] effects)
        {
            foreach (Effect e in effects)
            {
                this.addEffect(e);
            }
        }

        public void addEffect(Effect effect)
        {
            Effect[] newEffects = new Effect[(effects.Length + 1)]();
            for(int i = 0; i < effects.Length; i++)
            {
                newEffects[i] = effects[i];

            }
            newEffects[newEffects.Length-1] = effect;
            this.setEffects(newEffects);
        }
    }
}
