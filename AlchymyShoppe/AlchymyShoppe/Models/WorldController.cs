using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    public static class WorldController
    {
        public static Player player;
        private static double numOfHoursPast;
        public static double numOfHoursLeft;
        public static List<Ingredient> allIngredients;
        public static AlchymyTable table;

        static WorldController()
        {
            allIngredients = Chest.getMasterList();
            Initialize();
        }

        public static void Initialize()
        {
            player = new Player("Default", 10);
            numOfHoursLeft = 16;
            numOfHoursPast = 0;
            table = new AlchymyTable(player);
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
