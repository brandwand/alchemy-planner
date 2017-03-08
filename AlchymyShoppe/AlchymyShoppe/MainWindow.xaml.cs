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

        private List<string> s1 = new List<string>();
        private List<string> s2 = new List<string>();

        public ListBox dragSource = null;
        public Models.Inventory inv1 { get; set; } = new Models.Inventory();
        public Models.Inventory inv2 { get; set; } = new Models.Inventory();

        public List<string> S1 { get{ return s1; }
            set
            {
                s1 = value;
                OnPropertyChanged("S1");
            } }
        public List<string> S2 { get { return s2; }
            set
            {
                s2 = value;
                OnPropertyChanged("S2");
            } }

        public MainWindow()
        {
            InitializeComponent();
            btnGold.DataContext = Models.WorldController.player;
            imgBackground.Source = AlchymyShoppe.Controls.ImageUtil.BitmapToImageSource(ImageResoures.hubScreenBackground);

            //inv1.addItemToInventory(new Models.Ingredient("Ex: Dragon Heart", "Path", 5000, Models.Rarity.Godlike, Models.AlchymicEffect.RegenerateHealth | Models.AlchymicEffect.Nightvision));
            //inv1.addItemToInventory(new Models.Ingredient("Ex: Tunfra Cotton", "Path", 10, Models.Rarity.Common, Models.AlchymicEffect.RestoreHealth | Models.AlchymicEffect.RestoreMana));
            //inv1.addItemToInventory(new Models.Ingredient("Ex: Vampire Teeth", "Path", 750, Models.Rarity.Rare, Models.AlchymicEffect.DamageHealth | Models.AlchymicEffect.Nightvision));
            //listBox.ItemsSource = inv1.getItems();
            //listBox_Copy.ItemsSource = inv2.getItems();

            s1.Add("Hi 1");
            s1.Add("Hi 2");
            s1.Add("Hi 3");
            s1.Add("Hi 4");
            s1.Add("Hi 5");
            listBox.ItemsSource = S1;
            listBox_Copy.ItemsSource = S2;
        }

        private void btnAlchymyTable_Click(object sender, RoutedEventArgs e)
        {
            AlchymyTableScreen.Update();
            AlchymyTableScreen.Visibility = Visibility.Visible;
        }

        private void listBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null) DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
        }

        public static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
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
    }
}
