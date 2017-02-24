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
        List<Recipe> recipes;
        List<Boolean[]> knownEffects;

        public RecipeBook()
        {
            this.recipes = new List<Recipe>();
            this.knownEffects = markAllEffectsUnknown();
        }

        public RecipeBook(List<Ingredient> allIngredients)
        {
            this.recipes = buildRecipeBook(allIngredients);
            this.knownEffects = markAllEffectsUnknown();
        }
        public RecipeBook(List<Ingredient> allIngredients, List<Boolean[]> knownEffects)
        {
            this.recipes = buildRecipeBook(allIngredients);
            this.knownEffects = knownEffects;
        }

        public List<Recipe> buildRecipeBook(List<Ingredient> allIngredients)
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

        public List<Boolean[]> markAllEffectsUnknown()
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