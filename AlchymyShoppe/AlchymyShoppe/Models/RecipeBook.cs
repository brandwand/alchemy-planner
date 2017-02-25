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
           // this.ingredients = Chest.getDefaultIngredients();
            this.recipes = new Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>>();
        }

        public RecipeBook(List<Ingredient> allIngredients, List<Dictionary<Ingredient, Boolean>> knownIngredients)
        {
            this.ingredients = allIngredients;
            this.recipes = buildRecipeBook(allIngredients);
            setKnownIngredients(knownIngredients);
        }

        private void setKnownIngredients(List<Dictionary<Ingredient, bool>> knownIngredientsList)
        {
            foreach(Dictionary<Ingredient, Boolean> recipeKnowledge in knownIngredientsList)
            {
       //         recipeKnowledge
            }
        }

        public Dictionary<AlchymicEffect, Dictionary<Ingredient, Boolean>> buildRecipeBook(List<Ingredient> allIngredients)
        {
            List<Recipe> recipes = new List<Recipe>();
            List<AlchymicEffect> originalEffects = new List<AlchymicEffect>();
            List<Ingredient> withThisEffect = new List<Ingredient>();

            var allEffectLists = allIngredients.Select((i) =>
            {
                return i.effects;
            });

            foreach(List<AlchymicEffect> ael in allEffectLists)
            {
                foreach(AlchymicEffect ae in ael)
                {
                    if (!originalEffects.Contains(ae))
                    {
                        originalEffects.Add(ae);
                    }
                }
            }
            foreach(AlchymicEffect ae in originalEffects)
            {
                var ingredientWithEffect = from ingredient in allIngredients where ingredient.effects.Contains(ae) select ingredient;
                withThisEffect.AddRange(ingredientWithEffect);

                recipes.Add(new Recipe(ae, withThisEffect));
            }

            return recipes;
        }

        public void addRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public List<Boolean[]> buildEmptyDatabase()
        {
            List<Boolean[]> recipeKnowledge = new List<Boolean[]>();
            foreach(Recipe recipe in recipes)
            {
                Boolean[] know = new Boolean[recipe.getIngredients().Count];
                for(int i = 0; i < know.Length; i++){
                    know[i] = false;
                }
                recipeKnowledge.Add(know);
            }
            return recipeKnowledge;
        }
    }
}