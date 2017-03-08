using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlchymyShoppe.Models;
using System.Collections.Generic;

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

            Ingredient ingredient1 = new Ingredient("Flaming Tail", "beast.png", 700, Rarity.Uncommon, (AlchymicEffect)8448); //0010000100000000
            Ingredient ingredient2 = new Ingredient("Koro Tentacle", "fish.png", 3500, Rarity.Godlike, (AlchymicEffect)12560);//0011000100010000
            Ingredient ingredient3 = new Ingredient("Twisted Root", "plant.png", 200, Rarity.Inferior, (AlchymicEffect)30);   //0000000000011110
            List<Ingredient> ingredients = new List<Ingredient>();

            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);

            AlchymyShoppe.Models.Potion potion = new Potion("PotionX","",200, rarity, ingredients, effect);
            alchShoppe.addPlayerGold(player, potion);
            Assert.IsTrue(player.Gold == 256, "Failed To Add");  
        }
    }
}
