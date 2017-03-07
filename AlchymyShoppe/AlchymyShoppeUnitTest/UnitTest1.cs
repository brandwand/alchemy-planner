using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AlchymyShoppeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        AlchymyShoppe.Models.AlchymyShoppe alchShoppe = new AlchymyShoppe.Models.AlchymyShoppe();
        public void addGoldTest()
        {
            AlchymyShoppe.Models.Player player = new AlchymyShoppe.Models.Player("Bill", 456);
            AlchymyShoppe.Models.Rarity rarity = new AlchymyShoppe.Models.Rarity();
            AlchymyShoppe.Models.AlchymicEffect effect = new AlchymyShoppe.Models.AlchymicEffect();
            AlchymyShoppe.Models.Potion potion = new AlchymyShoppe.Models.Potion("PotionX","",200, rarity, effect);
            alchShoppe.addPlayerGold(player, potion);
            Assert.IsTrue(player.Gold == 256, "Failed To Add");  
        }
    }
}
