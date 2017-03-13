using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlchymyShoppe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlchymyShoppe.Models;

namespace AlchymyShoppe.Tests
{
    [TestClass()]
    public class AlchymyTableTests
    {
        [TestMethod()]
        public void craftPotionTest()
        {
            Player player = new Player("", 500);
            Ingredient ingredient1 = new Ingredient("Flaming Tail", "beast.png", 700, Rarity.Uncommon, (AlchymicEffect)8448); //0010000100000000
            Ingredient ingredient2 = new Ingredient("Koro Tentacle", "fish.png", 3500, Rarity.Godlike, (AlchymicEffect)12560);//0011000100010000
            Ingredient ingredient3 = new Ingredient("Twisted Root", "plant.png", 200, Rarity.Inferior, (AlchymicEffect)30);   //0000000000011110
            List<Ingredient> ingredients = new List<Ingredient>();
            AlchymicEffect effects = 0;

            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);
            
            Potion potion = new Potion("", "potion.png", ((ingredient1.price + ingredient2.price + ingredient3.price) * (int)Rarity.Rubbish), Rarity.Rubbish, ingredients, effects);

            AlchymyTable table = new AlchymyTable(player, ingredient1, ingredient2, ingredient3, potion);

            table.craftPotion();
            //i1    0010000100000000
            //i2    0011000100010000
            //i3    0000000000011110
            //result0010000100010000
            Assert.AreEqual((AlchymicEffect.Sleep|AlchymicEffect.Waterbreathing | AlchymicEffect.Speed), table.Potion.effects);
        }
        [TestMethod]
        public void TestRaritiesTransfer()
        {
            Player player = new Player("", 500);
            Ingredient ingredient1 = new Ingredient("Flaming Tail", "beast.png", 700, Rarity.Uncommon, (AlchymicEffect)8448); //0010000100000000
            Ingredient ingredient2 = new Ingredient("Koro Tentacle", "fish.png", 3500, Rarity.Godlike, (AlchymicEffect)12560);//0011000100010000
            Ingredient ingredient3 = new Ingredient("Twisted Root", "plant.png", 200, Rarity.Inferior, (AlchymicEffect)30);   //0000000000011110
            List<Ingredient> ingredients = new List<Ingredient>();
            AlchymicEffect effects = 0;

            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);

            Potion potion = new Potion("", "potion.png", (ingredient1.price + ingredient2.price + ingredient3.price), Rarity.Godlike, ingredients, effects);

            AlchymyTable table = new AlchymyTable(player, ingredient1, ingredient2, ingredient3, potion);

            table.craftPotion();
            //i1    0010000100000000
            //i2    0011000100010000
            //i3    0000000000011110
            //result0010000100010000
            Assert.AreEqual(Rarity.Godlike, table.Potion.rarity);
        }
        [TestMethod()]
        public void addGoldTest()
        {
            AlchymyShoppe.Models.AlchymyShoppe alchShoppe = new AlchymyShoppe.Models.AlchymyShoppe();
        
            AlchymyShoppe.Models.Player player = new AlchymyShoppe.Models.Player("Bill", 456);
            AlchymyShoppe.Models.Rarity rarity = new AlchymyShoppe.Models.Rarity();
            AlchymyShoppe.Models.AlchymicEffect effect = new AlchymyShoppe.Models.AlchymicEffect();

            Ingredient ingredient1 = new Ingredient("Flaming Tail", "beast.png", 700, Rarity.Uncommon, (AlchymicEffect)8448); //0010000100000000
            Ingredient ingredient2 = new Ingredient("Koro Tentacle", "fish.png", 3500, Rarity.Godlike, (AlchymicEffect)12560);//0011000100010000
            Ingredient ingredient3 = new Ingredient("Twisted Root", "plant.png", 200, Rarity.Inferior, (AlchymicEffect)30);   //0000000000011110
            List<Ingredient> ingredients = new List<Ingredient>();

            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);

            AlchymyShoppe.Models.Potion potion = new Potion("PotionX", "", 200, rarity, ingredients, effect);
            alchShoppe.addPlayerGold(player, potion);
            Assert.IsTrue(player.Gold == 656, "Failed To Add");
        }

        [TestMethod()]
        public void priceTest()
        {
            Player player = new Player("", 500);
            Ingredient ingredient1 = new Ingredient("Flaming Tail", "beast.png", 700, Rarity.Uncommon, (AlchymicEffect)8448); //0010000100000000
            Ingredient ingredient2 = new Ingredient("Koro Tentacle", "fish.png", 3500, Rarity.Godlike, (AlchymicEffect)12560);//0011000100010000
            Ingredient ingredient3 = new Ingredient("Twisted Root", "plant.png", 200, Rarity.Inferior, (AlchymicEffect)30);   //0000000000011110
            List<Ingredient> ingredients = new List<Ingredient>();
            AlchymicEffect effects = 0;

            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);

            Potion potion = new Potion("", "potion.png", ((ingredient1.price + ingredient2.price + ingredient3.price) * (int)Rarity.Rubbish), Rarity.Rubbish, ingredients, effects);

            AlchymyTable table = new AlchymyTable(player, ingredient1, ingredient2, ingredient3, potion);

            table.craftPotion();
            //i1    0010000100000000
            //i2    0011000100010000
            //i3    0000000000011110
            //result0010000100010000
            Assert.AreEqual((4400*7), table.Potion.price);
        }

        [TestMethod]
        public void takeAwayGoldFromCustomerTest()
        {
            AlchymyShoppe.Models.AlchymyShoppe alchShoppe = new AlchymyShoppe.Models.AlchymyShoppe();

            List<AlchymyShoppe.Models.Ingredient> items = new List<AlchymyShoppe.Models.Ingredient>();
            AlchymyShoppe.Models.Rarity rarity = new AlchymyShoppe.Models.Rarity();
            AlchymyShoppe.Models.AlchymicEffect effect = new AlchymyShoppe.Models.AlchymicEffect();
            AlchymyShoppe.Models.Ingredient ingredient = new AlchymyShoppe.Models.Ingredient("in", "", 10, rarity, effect);
            items.Add(ingredient);
            AlchymyShoppe.Models.Potion potion1 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, items, effect);
            AlchymyShoppe.Models.Potion potion2 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, items, effect);
            AlchymyShoppe.Models.Order order = new AlchymyShoppe.Models.Order("PotionX", "", 200, rarity, potion1);
            AlchymyShoppe.Models.Order order2 = new AlchymyShoppe.Models.Order("PotionT", "", 200, rarity, potion1);
            List<AlchymyShoppe.Models.Order> orders = new List<AlchymyShoppe.Models.Order>();
            orders.Add(order);
            orders.Add(order2);
            AlchymyShoppe.Models.Customer customer = new AlchymyShoppe.Models.Customer(orders, 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, items, effect);
            alchShoppe.takeAwayCustomerGold(customer, potion);
            Assert.AreEqual(256, customer.gold, "Failed to take gold");


        }

        [TestMethod]
        public void addToSellTest()
        {
            AlchymyShoppe.Models.AlchymyShoppe alchShoppe = new AlchymyShoppe.Models.AlchymyShoppe();
            List<AlchymyShoppe.Models.Ingredient> items = new List<AlchymyShoppe.Models.Ingredient>();
            AlchymyShoppe.Models.Rarity rarity = new AlchymyShoppe.Models.Rarity();
            AlchymyShoppe.Models.AlchymicEffect effect = new AlchymyShoppe.Models.AlchymicEffect();
            AlchymyShoppe.Models.Player player = new AlchymyShoppe.Models.Player("Bill", 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, items, effect);
            AlchymyShoppe.Models.Inventory inventory = new AlchymyShoppe.Models.Inventory();
            player.setInventory(inventory);

            player.addItemToInventory(potion);

            AlchymyShoppe.Models.Potion potion2 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, items, effect);
            player.addItemToInventory(potion2);
            alchShoppe.addToSell(player, potion);
            Assert.IsFalse(player.getInventory().getItems().Contains(potion), "Item not removed from player inventory");
            Assert.IsTrue(player.getInventory().getItems().Contains(potion2), "Does not have potion2");
        }

        //[TestMethod()]
        //public void ingredientLoadTest()
        //{
        //    Chest chest = new Chest();
        //    Ingredient koro = new Ingredient("Koro Tentacle", "fish.png", 3500, Rarity.Godlike, (AlchymicEffect)12432);
        //   // List<Ingredient> allIngredients = chest.loadIngredientList();
        //    IEnumerable<Ingredient> ingredientsWithName = from ingredient in allIngredients where ((ingredient.name.Equals("Koro Tentacle"))) select ingredient;

        //        Assert.AreEqual(true, ingredientsWithName.Count() >= 1);
        //}
    }

}