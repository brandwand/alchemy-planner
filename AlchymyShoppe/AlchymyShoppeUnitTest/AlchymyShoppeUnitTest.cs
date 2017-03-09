using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlchymyShoppeUnitTest
{
    [TestClass]
    public class AlchymyShoppeUnitTest
    {
        AlchymyShoppe.Models.AlchymyShoppe alchShoppe = new AlchymyShoppe.Models.AlchymyShoppe();
        AlchymyShoppe.Models.Rarity rarity = new AlchymyShoppe.Models.Rarity();
        AlchymyShoppe.Models.AlchymicEffect effect = new AlchymyShoppe.Models.AlchymicEffect();
        List<AlchymyShoppe.Models.Ingredient> items = new List<AlchymyShoppe.Models.Ingredient>();
       

        [TestMethod]
        public void addGoldToPlayerTest()
        {
            AlchymyShoppe.Models.Ingredient ingredient = new AlchymyShoppe.Models.Ingredient("in", "", 10, rarity, effect);
            items.Add(ingredient);
            AlchymyShoppe.Models.Player player = new AlchymyShoppe.Models.Player("Bill", 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX","",200, rarity, items, effect);
            alchShoppe.addPlayerGold(player, potion);
            Assert.AreEqual(656, player.Gold, "Failed To Add");  
        }
        [TestMethod]
        public void takeAwayGoldFromCustomerTest()
        {
            AlchymyShoppe.Models.Ingredient ingredient = new AlchymyShoppe.Models.Ingredient("in", "", 10, rarity, effect);
            items.Add(ingredient);
            AlchymyShoppe.Models.Potion potion1 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, items,effect);
            AlchymyShoppe.Models.Potion potion2 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity,items, effect);
            AlchymyShoppe.Models.Order order = new AlchymyShoppe.Models.Order("PotionX", "", 200, rarity, potion1);
            AlchymyShoppe.Models.Order order2 = new AlchymyShoppe.Models.Order("PotionT", "", 200, rarity, potion1);
            List<AlchymyShoppe.Models.Order> orders = new List<AlchymyShoppe.Models.Order>();
            orders.Add(order);
            orders.Add(order2);
            AlchymyShoppe.Models.Customer customer = new AlchymyShoppe.Models.Customer(orders, 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity,items, effect);
            alchShoppe.takeAwayCustomerGold(customer, potion);
            Assert.AreEqual(256, customer.gold, "Failed to take gold");


        }

        [TestMethod]
        public void addToSellTest()
        {
            AlchymyShoppe.Models.Player player = new AlchymyShoppe.Models.Player("Bill", 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, items, effect);
            AlchymyShoppe.Models.Inventory inventory = new AlchymyShoppe.Models.Inventory();
            player.setInventory(inventory);

            player.addItemToInventory(potion);

            AlchymyShoppe.Models.Potion potion2 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity,items, effect);
            player.addItemToInventory(potion2);
            alchShoppe.addToSell(player, potion);
            Assert.IsFalse(player.getInventory().getItems().Contains(potion), "Item not removed from player inventory");
            Assert.IsTrue(player.getInventory().getItems().Contains(potion2), "Does not have potion2");
        }
    }
}
