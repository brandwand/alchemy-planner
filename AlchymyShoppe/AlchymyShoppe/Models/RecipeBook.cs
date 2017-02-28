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
        public List<Ingredient> ingredients;
        Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> recipes;


        public RecipeBook()
        {
            // this.ingredients = Chest.Load(hardcoded text file link);
            this.recipes = new Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>>();
        }

        public RecipeBook(List<Ingredient> allIngredients)
        {
            this.ingredients = allIngredients;
            this.recipes = buildEmptyRecipeBook(allIngredients);
        }
        public RecipeBook(List<Ingredient> allIngredients, Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> knownRecipes)
        {
            this.ingredients = allIngredients;
            this.recipes = knownRecipes;
        }

        public Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> buildEmptyRecipeBook(List<Ingredient> allIngredients)
        {
            Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> recipes = new Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>>();
            List<AlchymicEffect> originalEffects = new List<AlchymicEffect>();
            List<Ingredient> withThisEffect = new List<Ingredient>();
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
                withThisEffect.Clear();
                knownIngredients.Clear();
                var ingredientWithEffect = from ingredient in allIngredients where ingredient.effects.Contains(alchymicEffect) select ingredient;
                withThisEffect.AddRange(ingredientWithEffect);

                foreach (Ingredient ingredient in withThisEffect)
                {
                    knownIngredients.Add(ingredient, false);
                }

                recipes.Add(alchymicEffect, knownIngredients);
            }

            return recipes;
        }
        
    }
}