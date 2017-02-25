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

        //We will need to change all strings to ingredients.
        //This is a temporary method that adds to the ingredients list so that I can test
        //all methods dealing with the inventory.
        public void addToList()
        {
            for(int i = 0; i < 50; i++)
            {
                ingredients.Add("hello " + i);
            }
        }


        //This method randomizes 5 - 15 ingredients.
        //It picks 5 - 15 random ingredients for the traveling merchants inventory.
        public List<string> makeInventory()
        {
            Random rand = new Random();
            int randomAmount = rand.Next(5, 15);
            for(int i = 0; i < randomAmount; i++)
            {
                int randomSelection = rand.Next(ingredients.Count);
                ingredients.ElementAt(randomSelection);
            }
            return ingredients;
        }
    
        //This method will display the result of the makeInventory method.
        //It will display this on the screen.
        public Inventory displayInventory()
        {
            return inventory;
        }  
    }
}
