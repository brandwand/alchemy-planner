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

namespace AlchymyShoppe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ListBox dragSource = null;
        public Inventory inv1 { get; set; } = new Inventory();
        public Inventory inv2 { get; set; } = new Inventory();

        public MainWindow()
        {
            InitializeComponent();
            btnGold.DataContext = Models.WorldController.player;
            imgBackground.Source = AlchymyShoppe.Controls.ImageUtil.BitmapToImageSource(ImageResoures.hubScreenBackground);

            inv1.addItemToInventory(new Ingredient("Ex: Dragon Heart", "Path", 5000, Rarity.Godlike, AlchymicEffect.RegenerateHealth | AlchymicEffect.Nightvision));
            inv1.addItemToInventory(new Ingredient("Ex: Tunfra Cotton", "Path", 10, Rarity.Common, AlchymicEffect.RestoreHealth | AlchymicEffect.RestoreMana));
            inv1.addItemToInventory(new Ingredient("Ex: Vampire Teeth", "Path", 750, Rarity.Rare, AlchymicEffect.DamageHealth | AlchymicEffect.Nightvision));
            listBox.ItemsSource = inv1.getItems();
            listBox_Copy.ItemsSource = inv2.getItems();
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
            ListBox parent = (ListBox)sender;
            Controls.InventoryItem data = (Controls.InventoryItem)e.Data.GetData(typeof(Controls.InventoryItem));
            ((IList)dragSource.ItemsSource).Remove(data);
            List<Item> inv = (List<Item>)parent.ItemsSource;
            //InventoryItem item = new Ingredient(((Ingredient)data).name, (data).imagePath, ((Item)data).price, ((Item)data).rarity);
            //inv.Add((Item)data);
            parent.ItemsSource = inv;
        }
    }
}
