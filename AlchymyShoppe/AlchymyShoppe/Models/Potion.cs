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
    class Potion : AlchymicItem
    {
        #region Constructors
        /// <summary>
        /// Makes a Potion
        /// </summary>
        /// <param name="name">Name of the Potion</param>
        /// <param name="price">Base Price of the Potion</param>
        /// <param name="rarity">Rarity of the Item</param>
        /// <param name="effects">Effects from the Ingredients that make the Potion</param>
        public Potion(String name, String imagePath, int price, Rarity rarity, AlchymicEffect effects) : base(name, imagePath, price, rarity, effects)
        {
            if(name == null || name == "")
            {
                this.name = GenerateName();
            }
            else
            {
                this.name = name;
            }
            
            this.imagePath = imagePath;
            this.price = price;
            this.rarity = rarity;
            this.effects = effects;
        }
        /*
        /// <summary>
        /// Makes a Potion
        /// </summary>
        /// <param name="name">Name of the Potion</param>
        /// <param name="price">Base Price of the Potion</param>
        /// <param name="rarity">Rarity of the Item</param>
        /// <param name="effects">Effects from the Ingredients that make the Potion</param>
<<<<<<< HEAD
        public Potion(String name, String imagePath, int price, Rarity rarity, AlchymicEffect effects) : base(name, imagePath, price, rarity, effects)
=======
        public Potion(String name, String imagePath, int price, Rarity rarity, List<AlchymicEffect> effects) : base(name, imagePath, price, rarity, effects)
>>>>>>> fbff74ece2bd82081840c651f0c35ff40a23f241
        {
            this.name = GenerateName();
            this.imagePath = imagePath;
            this.price = price;
            this.rarity = rarity;
            this.effects = effects;
        }
        */
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
            name += " Potion of ";
            name += ConvertEffectsToString();

            return name;
        }

        private String ConvertRarityToString()
        {
            String rarityString = "";

            if (rarity == Rarity.Rubbish) { rarityString = "Rubbish"; }
            else if (rarity == Rarity.Inferior) { rarityString = "Inferior"; }
            else if (rarity == Rarity.Common) { rarityString = "Common"; }
            else if (rarity == Rarity.Uncommon) { rarityString = "Uncommon"; }
            else if (rarity == Rarity.Rare) { rarityString = "Rare"; }
            else if (rarity == Rarity.Legendary) { rarityString = "Legendary"; }
            else if (rarity == Rarity.Godlike) { rarityString = "Godlike"; }

            return rarityString;
        }

        private String ConvertEffectsToString()
        {
            Array allEffects = Enum.GetValues(typeof(AlchymicEffect));

            String effectsString = "";
            int addedCount = 0,
                goalCount = this.countEffects();


            foreach (AlchymicEffect effect in allEffects)
            {
                if ((this.effects & effect) == effect)
                {
                    if (goalCount == 1)
                    {
                        return effect.ToString();
                    }
                    else
                    {
                        if(addedCount == 0)
                        {
                            effectsString = effect.ToString();
                        }
                        else if (addedCount == goalCount - 1)
                        {
                            if(goalCount >= 3)
                            {
                                effectsString += ", and " + effect.ToString();
                            }
                            else
                            {
                                effectsString += " and " + effect.ToString();
                            }
                        }
                        else
                        {
                            effectsString += ", " + effect.ToString();
                        }
                        addedCount++;
                    }
                }
            }

            return effectsString;
        }


        #endregion
    }
}