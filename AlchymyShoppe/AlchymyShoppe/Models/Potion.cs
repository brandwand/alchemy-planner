using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    /// <summary>
    /// Item to be used as an end result of a combination of Ingredients
    /// </summary>
    public class Potion : AlchymicItem
    {
        public List<Ingredient> components;

        #region Constructors
        /// <summary>
        /// Makes a Potion
        /// </summary>
        /// <param name="name">Name of the Potion</param>
        /// <param name="price">Base Price of the Potion</param>
        /// <param name="rarity">Rarity of the Item</param>
        /// <param name="components">Ingredients used to make the Potion</param>
        /// <param name="effects">Effects from the Ingredients that make the Potion</param>
        
        public Potion(String name, String imagePath, int price, Rarity rarity, List<Ingredient> components, AlchymicEffect effects) : base(name, imagePath, price, rarity, effects)
        {
            if(name == null || name == "")
            {
                this.name = GenerateName();
            }
            else
            {
                this.name = name;
            }
            this.components = components;
            this.imagePath = imagePath;
            this.price = price;
            this.rarity = rarity;
            this.effects = effects;
        }

        /// <summary>
        /// Makes a Potion
        /// </summary>
        /// <param name="name">Name of the Potion</param>
        /// <param name="price">Base Price of the Potion</param>
        /// <param name="rarity">Rarity of the Item</param>
        /// <param name="components">Ingredients used to make the Potion</param>
        /// <param name="effects">Effects from the Ingredients that make the Potion</param>

        public Potion(List<Ingredient> components) : base("", "", 0, Rarity.Common, AlchymicEffect.None)
        {
            if (name == null || name == "")
            {
                this.name = GenerateName();
            }
            else
            {
                this.name = name;
            }
            this.components = components;
            this.price = price;
            this.rarity = rarity;
            this.effects = effects;
            this.imagePath = imagePath;
        }
        /*
        /// <summary>
        /// Makes a Potion
        /// </summary>
        /// <param name="name">Name of the Potion</param>
        /// <param name="price">Base Price of the Potion</param>
        /// <param name="rarity">Rarity of the Item</param>
        /// <param name="effects">Effects from the Ingredients that make the Potion</param>
        
        public Potion(String name, String imagePath, int price, Rarity rarity, AlchymicEffect effects) : base(name, imagePath, price, rarity, effects)
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
        public String GenerateName()
        {
            String name = "";

            name += rarity.ToString();
            name += " Potion of ";
            name += ConvertEffectsToString();

            return name;
        }

        public int GeneratePrice()
        {
            int newPrice = 0;
            foreach(Ingredient ing in components)
            {
                newPrice += ing.price;
            }
            newPrice = newPrice * (int)GenerateRarity();
            return newPrice;
        }

        public Rarity GenerateRarity()
        {
            Rarity highestRarity = Rarity.Rubbish;
            foreach(Ingredient ingredient in this.components)
            {
                if(ingredient.rarity > highestRarity)
                {
                    highestRarity = ingredient.rarity;
                }
            }
            return highestRarity;
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