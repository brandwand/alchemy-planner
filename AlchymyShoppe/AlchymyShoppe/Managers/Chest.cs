using AlchymyShoppe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    public class Chest
    {
        //Hard coded names used for all files in the save folders
        private static string currentDirectory = Environment.CurrentDirectory;
        private string playerFile = "Player.txt";
        private string inventoryFile = "Inventory.txt";
        private string recipeBookFile = "RecipeBook.txt";
        private string saveDataLocation = System.IO.Path.Combine(currentDirectory, "SaveData");
        IFormatter formatter = new BinaryFormatter();
        public Player loadGame(string folderLocation)
        {
            if (Directory.Exists(folderLocation))
            {
                return loadPlayer(folderLocation);
            }
            else
            {
                //Default if something goes wrong reading information.
                return new Player("Player1", 250);
            }
        }
        private Player loadPlayer(string folderLocation)
        {
            string file = System.IO.Path.Combine(folderLocation, playerFile);
            Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            Player p = (Player)formatter.Deserialize(stream);
            stream.Close();
            p.setInventory(loadInventory(folderLocation));
            p.setPlayerBook(loadBook(folderLocation));
            return p;
        }
        private Inventory loadInventory(String folderLocation)
        {
            string file = System.IO.Path.Combine(folderLocation, inventoryFile);
            Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            Inventory p = (Inventory)formatter.Deserialize(stream);
            stream.Close();
            return p;
        }
        private Rarity getRarity(string rarity)
        {
            Rarity temp;
            switch (rarity)
            {
                case "None":
                    temp = Rarity.None;
                    break;
                case "Rubbish":
                    temp = Rarity.Rubbish;
                    break;
                case "Inferior":
                    temp = Rarity.Inferior;
                    break;
                case "Common":
                    temp = Rarity.Common;
                    break;
                case "Uncommon":
                    temp = Rarity.Uncommon;
                    break;
                case "Rare":
                    temp = Rarity.Rare;
                    break;
                case "Legendary":
                    temp = Rarity.Legendary;
                    break;
                case "Godlike":
                    temp = Rarity.Godlike;
                    break;
                default:
                    temp = Rarity.None;
                    break;
            }
            return temp;
        }
        private RecipeBook loadBook(String folderLocation)
        {
            string file = System.IO.Path.Combine(folderLocation, recipeBookFile);
            Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            RecipeBook p = (RecipeBook)formatter.Deserialize(stream);
            stream.Close();
            return p;
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
            string file = folderLocation + "/" + inventoryFile;
            StreamWriter writer = new StreamWriter(file);
            Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, currentPlayer);
        }
        private void saveRecipeBook(string folderLocation, RecipeBook currentBook)
        {
            string file = folderLocation + "/" + inventoryFile;
            StreamWriter writer = new StreamWriter(file);
            Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, currentBook);
        }
        private void saveInventory(string folderLocation, Inventory currentInventory)
        {
            string file = folderLocation + "/" + inventoryFile;
            StreamWriter writer = new StreamWriter(file);
            Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, currentInventory);
        }
        public List<Ingredient> getMasterList()
        {
            string pattern = "(.*?),(.*?),(.*?),(.*?),(.*)\n";
            List<string> temp = new List<string>();
            StreamReader sr = new StreamReader(fileResources.ingredients);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                temp.Add(line);
            }
            Regex r = new Regex(pattern);
            Match m;
            List<Ingredient> masterList = new List<Ingredient>();
            foreach (string line in temp)
            {
                m = r.Match(line);
                //Group[0] is resderved for the entire match;
                masterList.Add(
                new Ingredient(m.Groups[1].ToString(),
                m.Groups[2].ToString(),
                Int32.Parse(m.Groups[3].ToString()),
                getRarity(m.Groups[4].ToString()),
                (AlchymicEffect)Convert.ToInt64(m.Groups[5].Value)));
            }
            return masterList;
        }
    }
}