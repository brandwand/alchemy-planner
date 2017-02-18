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
        /// Takes in an array of AlchymicEffects and crafts them into a Potion
        /// </summary>
        /// <param name="effects"></param>
        /// <returns></returns>
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

            if (rarity == Rarity.Rubbish)        { rarityString = "Rubbish"; }
            else if (rarity == Rarity.Inferior)  { rarityString = "Inferior"; }
            else if (rarity == Rarity.Common)    { rarityString = "Common"; }
            else if (rarity == Rarity.Uncommon)  { rarityString = "Uncommon"; }
            else if (rarity == Rarity.Rare)      { rarityString = "Rare"; }
            else if (rarity == Rarity.Epic)      { rarityString = "Epic"; }
            else if (rarity == Rarity.Legendary) { rarityString = "Legendary"; }
            else if (rarity == Rarity.Godlike)   { rarityString = "Godlike"; }

            return rarityString;
        }

        private string ConvertEffectsToString()
        {
            String effectsString = "";
            int effectCount = 0;

            foreach(AlchymicEffect effect in effects)
            {
                if (effectCount != 0)
                {
                    if(effectCount == effects.Count - 1)
                    {
                        effectsString += " and ";
                    }
                    else
                    {
                        effectsString += ", ";
                    }
                }

                if (effect == AlchymicEffect.RestoreHealth)     { effectsString += "Healing"; }
                else if (effect == AlchymicEffect.RestoreMana)  { effectsString += "Mana Restoration"; }
                else if (effect == AlchymicEffect.Regenerate)   { effectsString += "Regeneration"; }
                else if (effect == AlchymicEffect.Speed)        { effectsString += "Speed"; }
                else if (effect == AlchymicEffect.Strength)     { effectsString += "Strength"; }
                else if (effect == AlchymicEffect.Charisma)     { effectsString += "Charsima"; }
                else if (effect == AlchymicEffect.Damage)       { effectsString += "Damage"; }
                else if (effect == AlchymicEffect.Paralysis)    { effectsString += "Paralysis"; }
                else if (effect == AlchymicEffect.Insivibility) { effectsString += "Invisibility"; }
                else if (effect == AlchymicEffect.Nightvision)  { effectsString += "Nightvision"; }
                else if (effect == AlchymicEffect.None)         { effectsString += "Mundanity"; }

            }

            return effectsString;
        }
        
        #endregion
    }
}
