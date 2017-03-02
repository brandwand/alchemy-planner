using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AlchymyShoppe
{
    class RecipeBook
    {
        Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> recipes;


        public RecipeBook()
        {
            this.recipes = new Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>>();
        }

        public RecipeBook(List<Ingredient> allIngredients)
        {
            this.recipes = buildEmptyRecipeBook(allIngredients);
        }
        public RecipeBook(List<Ingredient> allIngredients, Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> knownRecipes)
        {
            this.recipes = buildEmptyRecipeBook(allIngredients);
            copyRelevantRecipes(knownRecipes);
        }

        

        public Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> buildEmptyRecipeBook(List<Ingredient> allIngredients)
        {
            Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> recipes = new Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>>();
            List<AlchymicEffect> originalEffects = new List<AlchymicEffect>();
            Dictionary<Ingredient, Boolean> knownIngredients = new Dictionary<Ingredient, Boolean>();


            var allAlchymicEffectLists = allIngredients.Select((i) =>
            {
                return i.effects;
            });

            foreach (List<AlchymicEffect> alchymicEffectList in allAlchymicEffectLists)
            {
                foreach (AlchymicEffect alchymicEffect in alchymicEffectList)
                {
                    if (!originalEffects.Contains(alchymicEffect))
                    {
                        originalEffects.Add(alchymicEffect);
                    }
                }
            }
            foreach (AlchymicEffect alchymicEffect in originalEffects)
            {
                knownIngredients.Clear();
                var ingredientsWithEffect = from ingredient in allIngredients where ingredient.effects.Contains(alchymicEffect) select ingredient;

                foreach (Ingredient ingredient in ingredientsWithEffect)
                {
                    knownIngredients.Add(ingredient, false);
                }

                recipes.Add(alchymicEffect, knownIngredients);
            }

            return recipes;
        }

        private void copyRelevantRecipes(Dictionary<AlchymicEffect, Dictionary<Ingredient, bool>> knownRecipes)
        {
            foreach(KeyValuePair<AlchymicEffect, Dictionary<Ingredient, bool>> effect in this.recipes)
            {
                if (knownRecipes.ContainsKey(effect.Key))
                {
                    foreach(KeyValuePair<Ingredient, bool> ingredient in effect.Value)
                    {
                        if (knownRecipes[effect.Key].ContainsKey(ingredient.Key))
                        {
                            this.recipes[effect.Key][ingredient.Key] = knownRecipes[effect.Key][ingredient.Key];
                        }
                    }
                }
            }
        }
        
        public void serializeRecipeBook()
        {
            foreach(KeyValuePair<AlchymicEffect, Dictionary<Ingredient, bool>> effect in this.recipes)
            {

            }
        }
    }
}