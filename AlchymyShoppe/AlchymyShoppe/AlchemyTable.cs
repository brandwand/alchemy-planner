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
        public Ingredient ingredient1 { get; set; }
        public Ingredient ingredient2 { get; set; }
        public Ingredient ingredient3 { get; set; }
        Potion potion;
        public AlchemyTable(Player player, Ingredient ingredient1, Ingredient ingredient2, Ingredient ingredient3, Potion potion)
        {
            this.player = player;
            this.ingredient1 = ingredient1;
            this.ingredient2 = ingredient2;
            this.ingredient3 = ingredient3;
            this.potion = potion;
        }

        public void craftPotion()
        {

        }
        /// <summary>
        /// Takes in an array of AlchymicEffects and crafts them into a Potion
        /// </summary>
        /// <param name="effects"></param>
        /// <returns></returns>\
        public List<AlchymicEffect> Brew(params AlchymicEffect[] effects)
        {
            //Convert effects into a List
            List<AlchymicEffect> effectsList = new List<AlchymicEffect>();
            foreach (AlchymicEffect effect in effects)
            {
                effectsList.Add(effect);
            }
            return Brew(effectsList);
        }

        public List<AlchymicEffect> Brew(List<AlchymicEffect> effects)
        {
            //   List of effects that appear in the list more than once 
            // we're going to keep these
            List<AlchymicEffect> appearMoreThanOnce = new List<AlchymicEffect>();

            // List that will save whether that ingredient has appeared yet
            List<AlchymicEffect> appearedOnce = new List<AlchymicEffect>();

            foreach (AlchymicEffect effect in effects)
            {
                if (appearedOnce.Contains(effect))
                {
                    if (!appearMoreThanOnce.Contains(effect))
                        appearMoreThanOnce.Add(effect);
                }
                else
                {
                    appearedOnce.Add(effect);
                }
            }

            return appearMoreThanOnce;
        }

        public List<AlchymicEffect> ingredientEffectConverter(List<Ingredient> ingredients)
        {
            foreach (Ingredient ingredient in ingredients)
            {

            }
        }

    }
}