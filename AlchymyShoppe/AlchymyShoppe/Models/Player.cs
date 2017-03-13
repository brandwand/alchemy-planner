using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
   public class Player : INotifyPropertyChanged
    {

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        private RecipeBook book;
        private List<Order> orders;
        private Inventory inventory = new Inventory();
        private string name;
        private int gold = 10;

        public int Gold
        {
            get { return gold; }
            set
            {
                gold = value;
                OnPropertyChanged("Ingredient1");
            }
        }


        public Player(string name, int gold)
        {
            this.name = name;
            this.gold = gold;
            inventory = new Inventory("Inventory");
            book = new RecipeBook();
        }

        public Inventory getInventory()
        {
            return inventory;
        }
        public void setInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }
        public int getGold()
        {
            return this.gold;
        }
        public void setGold(int gold)
        {
            this.gold = gold;
        }
        public RecipeBook getPlayerBook()
        {
            return book;
        }
        public void setPlayerBook(RecipeBook book)
        {
            this.book = book;
        }
        public String getName()
        {
            return this.name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public List<Order> getOrders()
        {
            return this.orders;
        }
        public void setOrders(List<Order> orders)
        {
            this.orders = orders;
        }

        public void addItemToInventory(Item item)
        {
            inventory.addItemToInventory(item);
        }
    }
}