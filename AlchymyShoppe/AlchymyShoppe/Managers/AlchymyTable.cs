﻿using AlchymyShoppe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    public class AlchymyTable : INotifyPropertyChanged
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
        private List<Ingredient> ingredients;
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

        public AlchymyTable(Player player, Ingredient ingredient1, Ingredient ingredient2, Ingredient ingredient3, Potion potion)
        {
            this.player = player;
            this.ingredient1 = ingredient1;
            this.ingredient2 = ingredient2;
            this.ingredient3 = ingredient3;
            this.craftedPotion = potion;

            this.ingredients = new List<Ingredient>();
            this.ingredients.Add(ingredient1);
            this.ingredients.Add(ingredient2);
            this.ingredients.Add(ingredient3);
        }

        public AlchymyTable(Player player)
        {
            this.player = player;
            this.craftedPotion = new Potion(null);

            this.ingredients = new List<Ingredient>();
        }

        public bool SetIngredient(Ingredient ingredient, int index)
        {
            bool tf = false;

            if(index == 0)
            {
                Ingredient1 = ingredient;
                ingredients.Insert(index, ingredient);
                tf = true;
            } else if(index == 1)
            {
                Ingredient2 = ingredient;
                ingredients.Insert(index, ingredient);
                tf = true;
            }
            else if(index == 2)
            {
                Ingredient3 = ingredient;
                ingredients.Insert(index, ingredient);
                tf = true;
            }

            return tf;
        }

        public void SetIngredients(Ingredient ingredient1, Ingredient ingedient2, Ingredient ingredient3)
        {
            this.Ingredient1 = ingredient1;
            this.Ingredient2 = ingredient2;
            this.Ingredient3 = ingredient3;

            ingredients.Add(Ingredient1);
            ingredients.Add(Ingredient2);
            ingredients.Add(Ingredient3);
        }

        public void craftPotion()
        {
            craftedPotion.effects = Brew();
            craftedPotion.rarity = craftedPotion.GenerateRarity();
            craftedPotion.price = craftedPotion.GeneratePrice();
            craftedPotion.name = craftedPotion.GenerateName();
        }

        public Potion craftPotion(Ingredient ingredient1, Ingredient ingredient2, Ingredient ingredient3)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);
            Potion potion = Brew(ingredients);
            potion.GenerateRarity();
            potion.GeneratePrice();
            potion.GenerateName();
            return potion;
        }

        private Potion Brew(List<Ingredient> ingredients)
        {
            List<AlchymicEffect> effects = new List<AlchymicEffect>();

            foreach(Ingredient ingredient in ingredients)
            {
                effects.Add(ingredient.effects);
            }

            // List of effects that appear in the list more than once 
            // we're going to keep these
            AlchymicEffect appearedMoreThanOnce = new AlchymicEffect();

            // List that will save whether that ingredient has appeared yet
            AlchymicEffect appearedOnce = 0;

            foreach (AlchymicEffect effect in effects)
            {
                if ((appearedOnce & effect) > 0)
                {
                    appearedMoreThanOnce = appearedMoreThanOnce | (appearedOnce & effect);
                }
                appearedOnce = appearedOnce | effect;

            }

            Potion potion = new Potion(ingredients);
            potion.effects = appearedMoreThanOnce;

            return potion;
        }

        public AlchymicEffect Brew()
        {
            List<AlchymicEffect> effects = new List<AlchymicEffect>();
            effects.Add(ingredient1.effects);
            effects.Add(ingredient2.effects);
            effects.Add(ingredient3.effects);

            
            craftedPotion.components = ingredients;

            // List of effects that appear in the list more than once 
            // we're going to keep these
            AlchymicEffect appearedMoreThanOnce = new AlchymicEffect();

            // List that will save whether that ingredient has appeared yet
            AlchymicEffect appearedOnce = 0;
                           

            foreach (AlchymicEffect effect in effects)
            {
                if((appearedOnce & effect) > 0)
                {
                    appearedMoreThanOnce = appearedMoreThanOnce|(appearedOnce & effect);
                } 
                appearedOnce = appearedOnce | effect;
                
            }

            return appearedMoreThanOnce;
        }
    }
}