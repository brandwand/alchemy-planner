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
using AlchymyShoppe.Models;
using System.Collections.ObjectModel;

namespace AlchymyShoppe.Controls
{
    /// <summary>
    /// Interaction logic for AlchymyTableScreen.xaml
    /// </summary>
    public partial class AlchymyTableScreen : UserControl
    {
        Player p = new Player("Bob", 10);
        ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();

        public AlchymyTableScreen()
        {
            InitializeComponent();
            //btnGold.DataContext = Models.WorldController.player;
            imgBackground.Source = ImageUtil.BitmapToImageSource(Resoures.alchymyTableScreenBackground);
            //idInventory.InventorySource = Models.WorldController.player.getInventory();
            //pbxPotion.imgPotion.Source = ImageUtil.BitmapToImageSource(Resoures.potion);
            pbxPotion.imgPotion.Stretch = Stretch.UniformToFill;
            pbxPotion.imgPotionBackground.Source = ImageUtil.BitmapToImageSource(Resoures.emptyBoxFiller_600x800);
            pbxPotion.imgPotionBackground.Stretch = Stretch.UniformToFill;
            foreach (Ingredient ing in WorldController.allIngredients)
            {
                ingredients.Add(ing);
            }
            lbInventory.ItemsSource = ingredients;
            ingB1.CraftingIngredient = null;
            ingB2.CraftingIngredient = null;
            ingB3.CraftingIngredient = null;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        public void Update()
        {
            //playerInventoryDisplay.WorldController.Player.Inventory.items;
        }

        private void lbInventory_Drop(object sender, DragEventArgs e)
        {
            // Grab the current and the source list views, and their data
            var listBox = (ListBox)e.Source;
            var collection = lbInventory.ItemsSource as ObservableCollection<Item>;
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

        private void lbInventory_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void lbInventory_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox inv = (ListBox)sender;
            var collection = lbInventory.ItemsSource as ObservableCollection<Ingredient>;
            if (collection != null)
            {
                if (collection.Count == 0)
                {
                    return;
                }

                // Grab the ListViewItem that we're pulling the data from. Ensure it has contents
                var item = ItemsControl.ContainerFromElement(lbInventory, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null && (item.Content as Item) != null)
                {
                    // Add the listview item's contents to a data object and start a drag/drop event
                    Item itemContent = item.Content as Item;
                    Ingredient ing = itemContent as Ingredient;
                    var data = new DataObject();
                    data.SetData("Item", itemContent);
                    data.SetData("DragSource", lbInventory);
                    data.SetData("Ingredient", ing);
                    var effect = DragDrop.DoDragDrop(lbInventory, data, DragDropEffects.All);

                    // If the drop target said that we moved the item, remove it from the source list
                    if (effect == DragDropEffects.Move)
                    {
                        //collection.Remove(itemContent);

                    }

                }
            }
        }

        private void ingB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PotionIngredientBox ingB = (PotionIngredientBox)sender;
            if (ingB.CraftingIngredient != null)
            {
                ingB.CraftingIngredient = null;
            }
        }

        private void ingB_Drop(object sender, DragEventArgs e)
        {
            // Grab the current and the source list views, and their data
            var listBox = (ListBox)e.Source;
            var collection = listBox.ItemsSource as ObservableCollection<Ingredient>;
            var data = e.Data.GetData("Item") as Ingredient;
            var source = e.Data.GetData("DragSource") as ListBox;
            var ingredient = e.Data.GetData("Ingredient") as Ingredient;

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

        private void Viewbox_Drop(object sender, DragEventArgs e)
        {
            int i = 10;
        }

        private void InventoryItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InventoryItem invI = (InventoryItem)sender;
            Ingredient ingA = new Ingredient("Null", "", 10, Rarity.Common, AlchymicEffect.None);
            for (int j = 0; j < ingredients.Count; ++j)
            {
                if (ingredients[j].name == invI.tblName.Text)
                {
                    ingA = ingredients[j];
                }
            }
            if (ingA.name != "Null")
            {
                if (ingB1.CraftingIngredient == null)
                {
                    ingB1.CraftingIngredient = ingA;
                }
                else if (ingB2.CraftingIngredient == null)
                {
                    ingB2.CraftingIngredient = ingA;
                }
                else if (ingB3.CraftingIngredient == null)
                {
                    ingB3.CraftingIngredient = ingA;
                }
            }
        }

        private void btnCraft_Click(object sender, RoutedEventArgs e)
        {
            if (ingB1.CraftingIngredient != null  && ingB2.CraftingIngredient != null && ingB3.CraftingIngredient != null)
                pbxPotion.imgPotion.Source = ImageUtil.BitmapToImageSource(Resoures.potion);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ingB1.CraftingIngredient = null;
            ingB2.CraftingIngredient = null;
            ingB3.CraftingIngredient = null;
            pbxPotion.imgPotion.Source = null;
        }
    }
}