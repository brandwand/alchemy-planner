using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    //I'M USING A LOT OF FILLER CODE FOR NOW JUST TO GET THE BASIC CONCEPT DOWN
    class TravelingMerchant
    {
        private List<Order> orders;
        public string name = "Larry The Merchant";
        private int gold { get; set; }
        private Inventory inventory;
        private List<string> ingredients;
         
        public TravelingMerchant()
        {
                     
        }

        public Inventory getInventory()
        {
            return inventory;
        }

        public void setInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }


        //This method randomizes 5 - 15 ingredients.
        //It picks 5 - 15 random ingredients for the traveling merchants inventory.
        public List<Ingredient> makeInventory()
        {
            Random rand = new Random();
            int randomAmount = rand.Next(5, 15);
            for(int i = 0; i < randomAmount; i++)
            {
                int randomSelection = rand.Next(WorldController.allIngredients.Count);
                WorldController.allIngredients.ElementAt(randomSelection);
            }
            return WorldController.allIngredients;
        }
    
        //This method will display the result of the makeInventory method.
        //It will display this on the screen.
        public Inventory displayInventory()
        {
            return inventory;
        }  
    }
}
