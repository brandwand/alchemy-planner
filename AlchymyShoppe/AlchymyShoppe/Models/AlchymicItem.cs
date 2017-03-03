using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    public abstract class AlchymicItem : Item
    {
        public List<AlchymicEffect> effects = new List<AlchymicEffect>();

        public AlchymicItem(string name, string imagePath, int price, Rarity rarity, params AlchymicEffect[] effects) : base(name, imagePath, price, rarity)
        {
            this.effects.Clear();
            foreach (AlchymicEffect effect in effects)
            {
                this.effects.Add(effect);
            }
        }

        public AlchymicItem(string name, string imagePath, int price, Rarity rarity, List<AlchymicEffect> effects) : base(name, imagePath, price, rarity)
        {
            this.effects = effects;
        }
        /// <summary>
        /// Adds an AlchymicEffect to effects, the Item's AlchymicEffects List
        /// </summary>
        /// <param name="effect">AlchymicEffect to be add</param>
        public void AddEffect(AlchymicEffect effect)
        {
            if (!this.effects.Contains(effect))
                this.effects.Add(effect);
        }

        /// <summary>
        /// Adds an array of AlchymicEffect to effects, the Item's AlchymicEffects List, Doesn't allow duplicate AlchymicEffects
        /// </summary>
        /// <param name="effects">AlchymicEffects to be added</param>
        public void AddEffects(params AlchymicEffect[] effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                if (!this.effects.Contains(effect))
                    this.effects.Add(effect);
            }
        }

        /// <summary>
        /// Adds a List of AlchymicEffect to effects, the Item's AlchymicEffects List, Doesn't allow duplicate AlchymicEffects
        /// </summary>
        /// <param name="effects">AlchymicEffects to be added</param>
        public void AddEffects(List<AlchymicEffect> effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                if (!this.effects.Contains(effect))
                    this.effects.Add(effect);
            }
        }

        /// <summary>
        /// Removes an AlchymicEffect from effects, the Item's AlchymicEffects List
        /// </summary>
        /// <param name="effect">AlchymicEffect to be removed</param>
        public bool RemoveEffect(AlchymicEffect effect)
        {
            return effects.Remove(effect);
        }

        /// <summary>
        /// Removes an array of AlchymicEffects from effects, the Item's AlchymicEffects List
        /// </summary>
        /// <param name="effects">AlchymicEffects to be removed</param>
        public void RemoveEffects(params AlchymicEffect[] effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                this.effects.Remove(effect);
            }
        }

        /// <summary>
        /// Removes a List of AlchymicEffects from effects, the Item's AlchymicEffects List
        /// </summary>
        /// <param name="effects">AlchymicEffects to be removed</param>
        public void RemoveEffects(List<AlchymicEffect> effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                this.effects.Remove(effect);
            }
        }
    }
}