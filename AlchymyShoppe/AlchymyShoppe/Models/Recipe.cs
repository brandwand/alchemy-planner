using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Recipe
    {
        AlchymicEffect effect;
        private List<Ingredient> ingredients;
        Dictionary<Ingredient, Boolean> knownIngredients;
        

        public Recipe(AlchymicEffect effect, List<Ingredient> ingredients)
        {
            this.effect = effect;
            this.ingredients = ingredients;
            foreach(Ingredient ingredient in ingredients)
            {
                knownIngredients.Add(ingredient, false);
            }
        }

        public void discoverIngredient(Ingredient ingredient)
        {
            knownIngredients[ingredient] = true;
        }
        

        public List<Ingredient> getIngredients()
        {
            return ingredients;
        }
    }
}
