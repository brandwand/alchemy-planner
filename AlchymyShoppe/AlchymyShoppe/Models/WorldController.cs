using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    public static class WorldController
    {
        public static Player player = new Player("bill", 455);
        private static double numOfHoursPast = 0;
        public static double numOfHoursLeft = 0;
        public static List<Ingredient> allIngredients = new List<Ingredient>();

        static WorldController()
        {
            allIngredients = Chest.getMasterList();
        }

        public static void timeChange(double amountOfTime)
        {
            numOfHoursLeft -= amountOfTime;
            numOfHoursPast += amountOfTime;
        }

        public static void loadSaveFile()
        {

        }
    }
}
