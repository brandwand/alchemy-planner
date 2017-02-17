using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    /// <summary>
    /// To be used as an end result of a combination of ingredients
    /// </summary>
    class Potion : Item
    {
        #region Constructors
        /// <summary>
        /// Takes in the required parameters and makes a Potion
        /// </summary>
        /// <param name="name">Name of the Potion</param>
        /// <param name="price">Base Price of the Potion</param>
        /// <param name="rarity">Rarity of the Item</param>
        /// <param name="effects">Effects from the Ingredients that make the Potion</param>
        public Potion(String name, int price, Rarity rarity, params AlchymicEffect[] effects) : base(name, price, rarity, effects)
        {
            this.name = GenerateName();
            this.price = price;
            this.rarity = rarity;
            this.effects.Clear();
            this.effects = Brew(effects);
        }

        /// <summary>
        /// Takes in the required parameters and makes a Potion
        /// </summary>
        /// <param name="name">Name of the Potion</param>
        /// <param name="price">Base Price of the Potion</param>
        /// <param name="rarity">Rarity of the Item</param>
        /// <param name="effects">Effects from the Ingredients that make the Potion</param>
        public Potion(String name, int price, Rarity rarity, List<AlchymicEffect> effects) : base(name, price, rarity, effects)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
            this.effects = Brew(effects);
        }
        #endregion
        #region Functions
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
                if(appearedOnce.Contains(effect))
                {
                    if(!appearMoreThanOnce.Contains(effect))
                        appearMoreThanOnce.Add(effect);
                }
                else
                {
                    appearedOnce.Add(effect);
                }
            }

            return appearMoreThanOnce;
        }

        private String GenerateName()
        {
            String name = "";

            name += ConvertRarityToString();

            return name;
        }

        public String ConvertRarityToString()
        {
            return "";
        }
        #endregion
    }
}
