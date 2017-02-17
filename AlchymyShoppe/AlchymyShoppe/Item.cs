using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
   
    abstract class  Item
    {
        public String name { get; set; }
        public int price { get; set; }
        private ItemRaritys rarity { get; set; }
        public List<AlchymicEffect> effects = new List<AlchymicEffect>();


        public Item(String name, int price, String rarity, params AlchymicEffect[] effects)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
            this.effects.Clear();
            foreach (AlchymicEffect effect in effects)
            {
                this.effects.Add(effect);
            }
        }

        public Item(String name, int price, String rarity, List<AlchymicEffect> effects)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
            this.effects = effects;
        }

        public void AddEffect(AlchymicEffect effect)
        {
            if (!this.effects.Contains(effect))
                this.effects.Add(effect);
        }

        public void AddEffects(params AlchymicEffect[] effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                if(!this.effects.Contains(effect))
                    this.effects.Add(effect);
            }
        }

        public void AddEffects(List<AlchymicEffect> effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                if (!this.effects.Contains(effect))
                    this.effects.Add(effect);
            }
        }

        public void RemoveEffect(AlchymicEffect effect)
        {
            effects.Remove(effect);
        }

        public void RemoveEffects(params AlchymicEffect[] effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                this.effects.Remove(effect);
            }
        }

        public void RemoveEffects(List<AlchymicEffect> effects)
        {
            foreach (AlchymicEffect effect in effects)
            {
                this.effects.Remove(effect);
            }
        }


    }
}
