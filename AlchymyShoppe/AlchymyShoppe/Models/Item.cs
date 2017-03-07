using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
   /// <summary>
   /// Abstract class that holds the data relevant to an Item
   /// </summary>
    public abstract class Item
    {
        public String name { get; set; }
        public String imagePath { get; set; }
        public int price { get; set; }
        public Rarity rarity {  get; set; }


        /// <summary>
        /// Creates an Item using the data it takes in
        /// </summary>
        /// <param name="name">Name of the Item</param>
        /// <param name="imagePath">Path to Sprite image</param>
        /// <param name="price">Price of the Item</param>
        /// <param name="rarity">Rarity of the Item</param>
        public Item(String name, String imagePath, int price, Rarity rarity)
        {
            this.name = name;
            this.imagePath = imagePath;
            this.price = price;
            this.rarity = rarity;
        }
    }
}
