using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace AlchymyShoppe.Controls
{
    /// <summary>
    /// Interaction logic for InventoryItem.xaml
    /// </summary>
    public partial class InventoryItem : UserControl
    {
        #region PropertyChangedEvent

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}

        #endregion

        //private string itemName = "";
        //private int itemPrice = 0;
        //private Models.Rarity itemRarity;

        //#region PropertyChangedProperties



        public string ItemName
        {
            get { return (string)this.GetValue(ItemNameProperty); }
            set
            {
                this.SetValue(ItemNameProperty, value);
                tblName.Text = ItemName;
                //itemName = value;
                //OnPropertyChanged("ItemName");
            }
        }
        public int ItemPrice
        {
            get { return (int)this.GetValue(ItemPriceProperty); }
            set
            {
                this.SetValue(ItemPriceProperty, value);
                tblPrice.Text = ItemPrice.ToString();
                //itemPrice = value;
                //OnPropertyChanged("ItemPrice");
            }
        }
        public Models.Rarity ItemRarity
        {
            get { return (Models.Rarity)this.GetValue(ItemRarityProperty); }
            set
            {
                this.SetValue(ItemRarityProperty, value);
                tblRarity.Text = ItemRarity.ToString();
                //itemRarity = value;
                //OnPropertyChanged("ItemRarity");
            }
        }

        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register(
            "ItemName", typeof(string), typeof(InventoryItem), new PropertyMetadata("Default"));

        public static readonly DependencyProperty ItemPriceProperty = DependencyProperty.Register(
           "ItemPrice", typeof(int), typeof(InventoryItem), new PropertyMetadata(0));

        public static readonly DependencyProperty ItemRarityProperty = DependencyProperty.Register(
            "ItemRarity", typeof(Models.Rarity), typeof(InventoryItem), new PropertyMetadata(default(Models.Rarity)));

        //#endregion

        public InventoryItem()
        {
            InitializeComponent();
        }
    }
}
