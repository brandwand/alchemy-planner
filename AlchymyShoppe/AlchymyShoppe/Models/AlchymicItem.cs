using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    public abstract class AlchymicItem : Item
    {
        public AlchymicEffect effects { get; set; }



        public AlchymicItem(string name, String imagePath, int price, Rarity rarity, AlchymicEffect effects) : base(name, imagePath, price, rarity)
        {
            this.effects = effects;
        }
        
        /// <summary>
        /// Adds an AlchymicEffect to effects, the Item's AlchymicEffects List
        /// </summary>
        /// <param name="effect">AlchymicEffect to be add</param>
        public void AddEffect(AlchymicEffect effect)
        {
            if ((this.effects & effect) != effect)
            {
                this.effects = this.effects ^ effect;
            }
                
        }

        /// <summary>
        /// Adds an array of AlchymicEffect to effects, the Item's AlchymicEffects List, Doesn't allow duplicate AlchymicEffects
        /// </summary>
        /// <param name="effects">AlchymicEffects to be added</param>
        public void AddEffects(params AlchymicEffect[] effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                
                if ((this.effects & effect) != effect)
                {
                    this.effects = this.effects ^ effect;
                }
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
                if ((this.effects & effect) != effect)
                {
                    this.effects = this.effects ^ effect;
                }
            }
        }

        /// <summary>
        /// Removes an AlchymicEffect from effects, the Item's AlchymicEffects List
        /// </summary>
        /// <param name="effect">AlchymicEffect to be removed</param>
        public void RemoveEffect(AlchymicEffect effect)
        {
            this.effects = this.effects & (~effect);
        }

        /// <summary>
        /// Removes an array of AlchymicEffects from effects, the Item's AlchymicEffects List
        /// </summary>
        /// <param name="effects">AlchymicEffects to be removed</param>
        public void RemoveEffects(params AlchymicEffect[] effects)
        {
            foreach (AlchymicEffect effect in effects)
            { 
                this.effects = this.effects & (~effect);
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
                this.effects = this.effects & (~effect);
            }
        }

        public int countEffects()
        {
            long effectValue = (long)this.effects;
            int count = 0;

            while (effectValue > 0)
            {
                effectValue &= (effectValue - 1);
                count++;
            }
            return count;
        }
    }
}