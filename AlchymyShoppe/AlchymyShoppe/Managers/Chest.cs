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
            p.setPlayerBook(loadBook(sr));
            return p;
        }
        private Inventory loadInventory(StreamReader sr)
        {
            string pattern = "(.*?),(.*?),(.*?),(.*?),(.*)\n";
            List<string> temp = new List<string>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                temp.Add(line);
            }
            Regex r = new Regex(pattern);
            Match m;
            List<Ingredient> loadedIngredients = new List<Ingredient>();
            foreach (string line in temp)
            {
                m = r.Match(line);
                loadedIngredients.Add(
                new Ingredient(m.Groups[0].ToString(),
                    m.Groups[1].ToString(),
                    Int32.Parse(m.Groups[2].ToString()),
                    getRarity(m.Groups[3].ToString()),
                    (AlchymicEffect)Convert.ToInt64(m.Groups[4].Value)));
            }
            return new Inventory(loadedIngredients.Cast<Item>().ToList());
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
            
            List<Ingredient> ingredients = new List<Ingredient>();
            Regex regex = new Regex("(.*?), (.*?), (.*?), (.*?), (.*)\\n");

            string[] lines = File.ReadAllLines("C:\\Users\\Laxdyn\\AlchemyLab\\alchemy-planner\\AlchymyShoppe\\AlchymyShoppe\\ingredients.txt");
            foreach (string line in lines)
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    string name = match.Groups[1].Value,
                        imagePath = match.Groups[2].Value;
                    int price = int.Parse(match.Groups[3].Value);
                    Rarity rarity = getRarity(match.Groups[4].Value);
                    AlchymicEffect effects = (AlchymicEffect)long.Parse(match.Groups[5].Value);
                    Ingredient ingredient = new Ingredient(name, imagePath, price, rarity, effects);
                }
            }

            return ingredients;
        }
        private List<string> serializeRecipeBook(RecipeBook currentBook)
        {
            throw new NotImplementedException();
        }
        private List<string> serializeInventory(Inventory currentInventory)
        {
            List<string> temp = new List<string>();

            throw new NotImplementedException();
        }
    }
}