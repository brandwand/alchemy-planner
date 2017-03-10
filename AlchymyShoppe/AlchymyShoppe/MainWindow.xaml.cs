using AlchymyShoppe.Models;
using System;
using System.Collections;
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
using AlchymyShoppe;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AlchymyShoppe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region PropertyChangedEvent

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

        private ObservableCollection<string> s1 = new ObservableCollection<string>();
        private ObservableCollection<string> s2 = new ObservableCollection<string>();
        private ObservableCollection<string> s3 = new ObservableCollection<string>();

        public ListBox dragSource = null;
        //public Models.Inventory inv1 { get; set; } = new Models.Inventory();
        public Models.Inventory inv2 { get; set; } = new Models.Inventory();

        public ObservableCollection<string> S1 { get{ return s1; }
            set
            {
                s1 = value;
                OnPropertyChanged("S1");
            } }
        public ObservableCollection<string> S2 { get { return s2; }
            set
            {
                s2 = value;
                OnPropertyChanged("S2");
            } }
        public ObservableCollection<string> S3
        {
            get { return s3; }
            set
            {
                s3 = value;
                OnPropertyChanged("S3");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            btnGold.DataContext = Models.WorldController.player;
            imgBackground.Source = AlchymyShoppe.Controls.ImageUtil.BitmapToImageSource(Resoures.hubScreenBackground);
        }

        private void btnAlchymyTable_Click(object sender, RoutedEventArgs e)
        {
            AlchymyTableScreen.Update();
            AlchymyTableScreen.Visibility = Visibility.Visible;
        }

        private void listBox_Drop(object sender, DragEventArgs e)
        {
            //ListBox parent = (ListBox)sender;
            //object data = (Controls.InventoryItem)e.Data.GetData(typeof(Controls.InventoryItem));
            //Controls.InventoryItem item = (Controls.InventoryItem)data;
            //string nam = item.ItemName;
            //Models.Ingredient ing = new Models.Ingredient(((Controls.InventoryItem)data).ItemName, null, ((Controls.InventoryItem)data).ItemPrice, ((Controls.InventoryItem)data).ItemRarity, Models.AlchymicEffect.None);
            //((IList)dragSource.ItemsSource).Remove(ing);
            //List<Models.Item> inv = (List< Models.Item>)parent.ItemsSource;
            //inv.Add(ing);
            //parent.ItemsSource = inv;
            //inv1.setitems(inv);

            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(string));
            ((IList)dragSource.ItemsSource).Remove(data);
            //List<string> s3 = (List<string>)parent.ItemsSource;
            //s3.Add((string)data);
            //parent.ItemsSource = s3;
            //S2.Add((string)data);
            parent.Items.Add("asdf");            
        }

        private void listBox_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ListDropped(object sender, DragEventArgs e)
        {
            // Grab the current and the source list views, and their data
            var listBox = (ListBox)e.Source;
            var collection = listBox.ItemsSource as ObservableCollection<Item>;
            var data = e.Data.GetData("Item") as Item;
            var source = e.Data.GetData("DragSource") as ListBox;

            // If unable to grab the data or source, or if the source is the same as the drop target, return (Don't do anything)
            if (source == null || data == null || listBox == source)
                return;

            // This is a different list box, so add the incoming data to the targets list and say that the data was moved
            //Ingredient ing = new Ingredient(data.name, data.imagePath, data.price, data.rarity, ((Ingredient)data).effects);
            //collection.Add(ing);
            collection.Add(data);
            e.Effects = DragDropEffects.Move;
            //listBox.Items.Refresh();
            //listBox_Copy.Items.Refresh();
        }

        private void Test1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Grab the source list box and pull the item source from it. Check that it contains data, return if not
            var listBox = (ListBox)sender;
            var collection = listBox.ItemsSource as ObservableCollection<Item>;
            if(collection != null)
            {
                if (collection.Count == 0)
                {
                    return;
                }

                // Grab the ListViewItem that we're pulling the data from. Ensure it has contents
                var item = ItemsControl.ContainerFromElement(listBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null && (item.Content as Item) != null)
                {
                    // Add the listview item's contents to a data object and start a drag/drop event
                    Item itemContent = item.Content as Item;
                    var data = new DataObject();
                    data.SetData("Item", itemContent);
                    data.SetData("DragSource", listBox);
                    var effect = DragDrop.DoDragDrop(listBox, data, DragDropEffects.All);

                    // If the drop target said that we moved the item, remove it from the source list
                    if (effect == DragDropEffects.Move)
                    {
                        collection.Remove(itemContent);

                    }

                }
            }
        }

        private void btnTravelingMerchant_Click(object sender, RoutedEventArgs e)
        {
            //TravelingMerchantScreen.Update();
            TravelingMerchantScreen.Visibility = Visibility.Visible;
        }
    }
}
