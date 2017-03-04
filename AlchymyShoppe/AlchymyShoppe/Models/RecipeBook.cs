using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    public class RecipeBook
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
            List<AlchymicEffect> allAlchymicEffectLists = new List<AlchymicEffect>();
            Dictionary<Ingredient, Boolean> knownIngredients = new Dictionary<Ingredient, Boolean>();
            

            foreach (AlchymicEffect alchymicEffect in Enum.GetValues(typeof(AlchymicEffect)))
            {
                knownIngredients.Clear();
                List<Ingredient> ingredientsWithEffect = (List<Ingredient>)from ingredient in allIngredients where ((ingredient.effects & alchymicEffect) == alchymicEffect) select ingredient;

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