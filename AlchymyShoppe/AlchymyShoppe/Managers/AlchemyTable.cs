using AlchymyShoppe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class AlchemyTable : INotifyPropertyChanged
    {

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        Player player;
        private Ingredient ingredient1;
        private Ingredient ingredient2;
        private Ingredient ingredient3;
        private Potion craftedPotion;

        public Ingredient Ingredient1
        {
            get { return ingredient1; }
            set
            {
                ingredient1 = value;
                OnPropertyChanged("Ingredient1");
            }
        }
        public Ingredient Ingredient2
        {
            get { return ingredient2; }
            set
            {
                ingredient2 = value;
                OnPropertyChanged("Ingredient2");
            }
        }
        public Ingredient Ingredient3
        {
            get { return ingredient3; }
            set
            {
                ingredient3 = value;
                OnPropertyChanged("Ingredient3");
            }
        }
        public Potion Potion
        {
            get { return craftedPotion; }
            set
            {
                craftedPotion = value;
                OnPropertyChanged("CraftedPotion");
            }
        }

        public AlchemyTable(Player player, Ingredient ingredient1, Ingredient ingredient2, Ingredient ingredient3, Potion potion)
        {
            this.player = player;
            this.ingredient1 = ingredient1;
            this.ingredient2 = ingredient2;
            this.ingredient3 = ingredient3;
            this.craftedPotion = potion;
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
            List<AlchymicEffect> effectsList = new List<AlchymicEffect>();
            foreach (Ingredient ingredient in ingredients)
            {
                foreach (AlchymicEffect effect in ingredient.effects)
                {
                    effectsList.Add(effect);

                }
            }
            return effectsList;
        }

    }
}