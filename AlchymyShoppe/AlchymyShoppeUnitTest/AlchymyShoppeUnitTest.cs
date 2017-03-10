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



    }
}
