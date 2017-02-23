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
        

        public Recipe(AlchymicEffect effect, List<Ingredient> ingredients)
        {
            this.effect = effect;
            this.ingredients = ingredients;
            
            
        }
        
        public void addIngredient(Ingredient ingredient)
        {
            if (ingredient.effects.Contains(this.effect))
            {
                ingredients.Add(ingredient);
            }
            else
            {
                Console.WriteLine("Ingredient does not have this effect.");
            }
        }

        public List<Ingredient> getIngredients()
        {
            return ingredients;
        }

    }
}
