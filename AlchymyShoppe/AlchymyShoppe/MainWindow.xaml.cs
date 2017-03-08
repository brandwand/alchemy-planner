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
        public Models.Inventory inv1 { get; set; } = new Models.Inventory();
        public Models.Inventory inv2 { get; set; } = new Models.Inventory();

        public MainWindow()
        {
            InitializeComponent();
            btnGold.DataContext = Models.WorldController.player;
            imgBackground.Source = AlchymyShoppe.Controls.ImageUtil.BitmapToImageSource(ImageResoures.hubScreenBackground);

            inv1.addItemToInventory(new Models.Ingredient("Ex: Dragon Heart", "Path", 5000, Models.Rarity.Godlike, Models.AlchymicEffect.RegenerateHealth | Models.AlchymicEffect.Nightvision));
            inv1.addItemToInventory(new Models.Ingredient("Ex: Tunfra Cotton", "Path", 10, Models.Rarity.Common, Models.AlchymicEffect.RestoreHealth | Models.AlchymicEffect.RestoreMana));
            inv1.addItemToInventory(new Models.Ingredient("Ex: Vampire Teeth", "Path", 750, Models.Rarity.Rare, Models.AlchymicEffect.DamageHealth | Models.AlchymicEffect.Nightvision));
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
            List<Models.Item> inv = (List<Models.Item>)parent.ItemsSource;
            //InventoryItem item = new Ingredient(((Ingredient)data).name, (data).imagePath, ((Item)data).price, ((Item)data).rarity);
            //inv.Add((Item)data);
            parent.ItemsSource = inv;
        }
    }
}
