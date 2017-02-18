using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    /// <summary>
    /// Item to be used as an end result of a combination of Ingredients
    /// </summary>
    class Potion : Item
    {
        #region Constructors
        /// <summary>
        /// Makes a Potion
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
            this.effects = new List<AlchymicEffect>(effects);
        }

        /// <summary>
        /// Makes a Potion
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
            this.effects = effects;
        }
        #endregion
        #region Functions

    

        /// <summary>
        /// Generates a proper Potion name ex. "Legendary Potion of Healing, Invisibilty and Paralysis"
        /// </summary>
        /// <returns></returns>
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
