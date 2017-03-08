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
        [TestMethod]
        public void addGoldToPlayerTest()
        {
            AlchymyShoppe.Models.Player player = new AlchymyShoppe.Models.Player("Bill", 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX","",200, rarity, effect);
            alchShoppe.addPlayerGold(player, potion);
            Assert.AreEqual(656, player.Gold, "Failed To Add");  
        }
        [TestMethod]
        public void takeAwayGoldFromCustomerTest()
        {
            AlchymyShoppe.Models.Potion potion1 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, effect);
            AlchymyShoppe.Models.Potion potion2 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, effect);
            AlchymyShoppe.Models.Order order = new AlchymyShoppe.Models.Order("PotionX", "", 200, rarity, potion1);
            AlchymyShoppe.Models.Order order2 = new AlchymyShoppe.Models.Order("PotionT", "", 200, rarity, potion1);
            List<AlchymyShoppe.Models.Order> items = new List<AlchymyShoppe.Models.Order>();
            items.Add(order);
            items.Add(order2);
            AlchymyShoppe.Models.Customer customer = new AlchymyShoppe.Models.Customer(items, 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, effect);
            alchShoppe.takeAwayCustomerGold(customer, potion);
            Assert.AreEqual(256, customer.gold, "Failed to take gold");


        }

        [TestMethod]
        public void addToSellTest()
        {
            AlchymyShoppe.Models.Player player = new AlchymyShoppe.Models.Player("Bill", 456);
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, effect);
            AlchymyShoppe.Models.Inventory inventory = new AlchymyShoppe.Models.Inventory();
            player.setInventory(inventory);

            player.addItemToInventory(potion);

            AlchymyShoppe.Models.Potion potion2 = new AlchymyShoppe.Models.Potion("PotionX", "", 200, rarity, effect);
            player.addItemToInventory(potion2);
            alchShoppe.addToSell(player, potion);
            Assert.IsFalse(player.getInventory().getItems().Contains(potion), "Item not removed from player inventory");
            Assert.IsTrue(player.getInventory().getItems().Contains(potion2), "Does not have potion2");
        }
    }
}
