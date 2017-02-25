using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    class Chest
    {
        //Hard coded names used for all files in the save folders
        public bool loadGame(string folderLocation)
        {

        }
        public bool saveGame(string folderLocation, Player currentPlayer)
        {
            if (File.Exists(folderLocation))
            {
                if(savePlayer(folderLocation, currentPlayer) && saveInventory(folderLocation, currentPlayer.getInventory()))
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Save folder " + folderLocation + " does not exist.");
            }
            return false;
        }

        private bool saveInventory(string folderLocation, Player currentPlayer)
        {

            throw new NotImplementedException();
        }

        private bool savePlayer(string folderLocation, Player currentPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
