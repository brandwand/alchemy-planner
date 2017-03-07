using AlchymyShoppe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            p.setInventory(loadInventory(sr));
            //not able to implement yet
//            p.setPlayerBook(loadBook(sr));
            return p;
        }
        private Inventory loadInventory(StreamReader sr)
        {
            string pattern = "(.*?),(.*?),(.*?),(.*?),(.*?),(.*)\n";
            List<string> temp = new List<string>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                temp.Add(line);
            }
            Regex r = new Regex(pattern);
            Match m;
            List<Ingredient> loadedIngredients = new List<Ingredient>();
            List<Potion> loadedPotions = new List<Potion>();
            List<MundaneItem> loadedRegularItems = new List<MundaneItem>();
            foreach (string line in temp)
            {
                m = r.Match(line);
                //Group[0] is resderved for the entire match;
                string determinItem = m.Groups[1].ToString();
                if (determinItem.Equals("0"))
                {
                    loadedIngredients.Add(
                    new Ingredient(m.Groups[2].ToString(),
                    m.Groups[3].ToString(),
                    Int32.Parse(m.Groups[4].ToString()),
                    getRarity(m.Groups[5].ToString()),
                    (AlchymicEffect)Convert.ToInt64(m.Groups[6].Value)));
                }
                else if (determinItem.Equals("1"))
                {
                    loadedPotions.Add(new Potion(m.Groups[2].ToString(),
                    m.Groups[3].ToString(),
                    Int32.Parse(m.Groups[4].ToString()),
                    getRarity(m.Groups[5].ToString()),
                    (AlchymicEffect)Convert.ToInt64(m.Groups[6].Value)));
                }
                else
                {
                    //Not doing mundaneItems yet
                }
            }
            return new Inventory(loadedIngredients, loadedPotions, loadedRegularItems);
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
        private RecipeBook loadBook(StreamReader sr)
        {
            throw new NotImplementedException();
        }
        private void deserializePlayer(string rawData, out string playerName, out string gold)
        {
            String pattern = "(.*?),(.*?)";
            Regex r = new Regex(pattern);
            Match m;
            m = r.Match(rawData);
            playerName = m.Groups[1].ToString();
            gold = m.Groups[2].ToString();
        }
        public void saveGame(string folderLocation, Player currentPlayer)
        {
            if (Directory.Exists(folderLocation))
            {
                savePlayer(folderLocation, currentPlayer);
                saveInventory(folderLocation, currentPlayer.getInventory());
//                saveRecipeBook(folderLocation, currentPlayer.getPlayerBook());
            }
            else
            {
                string path = System.IO.Path.Combine(saveDataLocation, folderLocation);
                System.IO.Directory.CreateDirectory(path);
                string inventoryPath = System.IO.Path.Combine(path, inventoryFile);
                string playerPath = System.IO.Path.Combine(path, playerFile);
//                string recipeBookPath = System.IO.Path.Combine(path, recipeBookFile);
                System.IO.FileStream fs = System.IO.File.Create(inventoryPath);
                fs = System.IO.File.Create(playerPath);
//                fs = System.IO.File.Create(recipeBookPath);
                saveGame(folderLocation, currentPlayer);
            }
        }
        private void savePlayer(string folderLocation, Player currentPlayer)
        {
            List<string> playerContents = serializePlayer(currentPlayer);
            string file = folderLocation + "/" + inventoryFile;
            StreamWriter writer = new StreamWriter(file);
            foreach (string line in playerContents)
            {
                writer.WriteLine(line);
            }
        }
        private void saveRecipeBook(string folderLocation, RecipeBook currentBook)
        {
            List<string> bookContents = serializeRecipeBook(currentBook);
            string file = folderLocation + "/" + recipeBookFile;
            StreamWriter writer = new StreamWriter(file);
            foreach (string line in bookContents)
            {
                writer.WriteLine(line);
            }
        }
        private void saveInventory(string folderLocation, Inventory currentInventory)
        {
            List<string> inventoryContents = serializeInventory(currentInventory);
            string file = folderLocation + "/" + inventoryFile;
            StreamWriter writer = new StreamWriter(file);
            foreach(string line in inventoryContents){
                writer.WriteLine(line);
            }
        }
        private List<string> serializePlayer(Player currentPlayer)
        {
            string name = currentPlayer.getName();
            string gold = currentPlayer.getGold().ToString();
            List<string> temp = new List<string>();
            temp.Add(name);
            temp.Add(gold);
            return temp;
        }
        private List<string> serializeRecipeBook(RecipeBook currentBook)
        {
            throw new NotImplementedException();
        }
        private List<string> serializeInventory(Inventory currentInventory)
        {
            List<string> temp = new List<string>();
            List<Item> playersInventory = currentInventory.getItems();
            for(int i = 0; i < playersInventory.Count; i++)
            {

            }
            throw new NotImplementedException();
        }
    }
}