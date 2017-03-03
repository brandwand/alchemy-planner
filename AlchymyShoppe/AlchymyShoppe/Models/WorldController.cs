using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    class WorldController
    {

        private static Player player;
        private double numOfHoursPast;
        private double numOfHoursLeft;
        public static List<Ingredient> allIngredients;
        
        public static void timeChange(double amountOfTime)
        {
            WorldController wc = new WorldController();
            wc.numOfHoursLeft -= amountOfTime;
            wc.numOfHoursPast += amountOfTime;
        }

        public void loadSaveFile()
        {

        }


    }
}