using AlchymyShoppe.Models;
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
        private static string currentDirectory = Environment.CurrentDirectory;
        private string playerFile = "Player.txt";
        private string inventoryFile = "Inventory.txt";
        private string recipeBookFile = "RecipeBook.txt";
        private string saveDataLocation = System.IO.Path.Combine(currentDirectory, "SaveData");
        public Player loadGame(string folderLocation)
        {
            if (Directory.Exists(folderLocation))
            {
                return loadPlayer(folderLocation);
            }
            else
            {
                //Default if something goes wrong reading information.
                return new Player("Player1",250);
            }
        }

        private Player loadPlayer(string folderLocation)
        {
            string file = System.IO.Path.Combine(folderLocation, playerFile);
            StreamReader sr = new StreamReader(file);
            string rawData = sr.ReadToEnd();
            string playerName = "";
            string gold = "";
            deserializePlayer(rawData, out playerName, out gold);
            Player p = new Player(playerName, Int32.Parse(gold));
            p.setInventory(loadInventory());
            p.setPlayerBook(loadBook());
            return p;
        }

        private Inventory loadInventory()
        {
            throw new NotImplementedException();
        }

        private RecipeBook loadBook()
        {
            throw new NotImplementedException();
        }

        private void deserializePlayer(string rawData, out string playerName, out string gold)
        {
            throw new NotImplementedException();
        }

        public void saveGame(string folderLocation, Player currentPlayer)
        {
            if (Directory.Exists(folderLocation))
            {
                savePlayer(folderLocation, currentPlayer);
                saveInventory(folderLocation, currentPlayer.getInventory());
                saveRecipeBook(folderLocation, currentPlayer.getPlayerBook());
            }
            else
            {
                string path = System.IO.Path.Combine(saveDataLocation, folderLocation);
                System.IO.Directory.CreateDirectory(path);
                string inventoryPath = System.IO.Path.Combine(path, inventoryFile);
                string playerPath = System.IO.Path.Combine(path, playerFile);
                string recipeBookPath = System.IO.Path.Combine(path, recipeBookFile);
                System.IO.FileStream fs = System.IO.File.Create(inventoryPath);
                fs = System.IO.File.Create(playerPath);
                fs = System.IO.File.Create(recipeBookPath);
                saveGame(folderLocation, currentPlayer);
            }
        }
        private void savePlayer(string folderLocation, Player currentPlayer)
        {
            string[] playerContents = serializePlayer(currentPlayer);
            string file = folderLocation + "/" + inventoryFile;
            StreamWriter writer = new StreamWriter(file);
            foreach (string line in playerContents)
            {
                writer.WriteLine(line);
            }
        }
        private void saveRecipeBook(string folderLocation, RecipeBook currentBook)
        {
            string[] bookContents = serializeRecipeBook(currentBook);
            string file = folderLocation + "/" + recipeBookFile;
            StreamWriter writer = new StreamWriter(file);
            foreach (string line in bookContents)
            {
                writer.WriteLine(line);
            }
        }
        private void saveInventory(string folderLocation, Inventory currentInventory)
        {
            string[] inventoryContents = serializeInventory(currentInventory);
            string file = folderLocation + "/" + inventoryFile;
            StreamWriter writer = new StreamWriter(file);
            foreach(string line in inventoryContents){
                writer.WriteLine(line);
            }
        }
        private string[] serializePlayer(Player currentPlayer)
        {
            throw new NotImplementedException();
        }
        private string[] serializeRecipeBook(RecipeBook currentBook)
        {
            throw new NotImplementedException();
        }
        private string[] serializeInventory(Inventory currentInventory)
        {
            throw new NotImplementedException();
        }
    }
}