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

            lbInventory.ItemsSource = WorldController.player.getInventory().getIngredients();
            ingB1.CraftingIngredient = null;
            ingB2.CraftingIngredient = null;
            ingB3.CraftingIngredient = null;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Clear();
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
            ((ObservableCollection<Item>)source.ItemsSource).Remove(data);
            e.Effects = DragDropEffects.Move;
            //listBox.Items.Refresh();
            //listBox_Copy.Items.Refresh();
        }

        private void lbInventory_MouseEnter(object sender, MouseEventArgs e)
        {
            //ToolTip tooltip = new ToolTip();
            //InventoryItem item = (InventoryItem)sender;
            //tooltip.Content = item.Ingredient.effects.ToString();
            //ToolTip = tooltip;
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
                        collection.Remove(ing);

                    }

                }
            }
        }

        private void ingB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PotionIngredientBox ingB = (PotionIngredientBox)sender;
            if (ingB.CraftingIngredient != null)
            {
                WorldController.player.getInventory().addIngredientToInventory(ingB.CraftingIngredient);
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
            //((ObservableCollection<Ingredient>)source.ItemsSource).Remove(data);
            e.Effects = DragDropEffects.Move;
            //listBox.Items.Refresh();
            //listBox_Copy.Items.Refresh();

        }

        private void btnCraft_Click(object sender, RoutedEventArgs e)
        {
            if (ingB1.CraftingIngredient != null  && ingB2.CraftingIngredient != null && ingB3.CraftingIngredient != null)
            {
                pbxPotion.CraftedPotion = WorldController.table.craftPotion(ingB1.CraftingIngredient, ingB2.CraftingIngredient, ingB3.CraftingIngredient);
                pbxPotion.imgPotion.Source = ImageUtil.BitmapToImageSource(Resoures.potion);
                pbxPotion.imgPotion.Stretch = Stretch.UniformToFill;
                ingB1.CraftingIngredient = null;
                ingB2.CraftingIngredient = null;
                ingB3.CraftingIngredient = null;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            if(ingB1.CraftingIngredient != null)
            {
                WorldController.player.getInventory().addIngredientToInventory(ingB1.CraftingIngredient);
                ingB1.CraftingIngredient = null;
            }
            if (ingB2.CraftingIngredient != null)
            {
                WorldController.player.getInventory().addIngredientToInventory(ingB2.CraftingIngredient);
                ingB2.CraftingIngredient = null;
            }
            if (ingB3.CraftingIngredient != null)
            {
                WorldController.player.getInventory().addIngredientToInventory(ingB3.CraftingIngredient);
                ingB3.CraftingIngredient = null;
            }
            if (pbxPotion.CraftedPotion != null)
            {
                WorldController.player.getInventory().addItemToInventory(pbxPotion.CraftedPotion);
                pbxPotion.CraftedPotion = null;
            }
        }

        private void lbInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient selectedIngedient = (Ingredient)lbInventory.SelectedItem;  
            
            if(selectedIngedient != ingB1.CraftingIngredient 
                && selectedIngedient != ingB2.CraftingIngredient
                && selectedIngedient != ingB3.CraftingIngredient)
            {
                if (ingB1.CraftingIngredient == null)
                {
                    ingB1.CraftingIngredient = selectedIngedient;
                    WorldController.player.getInventory().removeIngredientFromInventory(selectedIngedient);
                }
                else if (ingB2.CraftingIngredient == null)
                {
                    ingB2.CraftingIngredient = selectedIngedient;
                    WorldController.player.getInventory().removeIngredientFromInventory(selectedIngedient);
                }
                else if (ingB3.CraftingIngredient == null)
                {
                    ingB3.CraftingIngredient = selectedIngedient;
                    WorldController.player.getInventory().removeIngredientFromInventory(selectedIngedient);
                }
            }
        }

        private void InventoryItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //ToolTip tooltip = new ToolTip();
            //InventoryItem item = (InventoryItem)sender;
            //tooltip.Content = item.Ingredient.effects.ToString();
            //ToolTip = tooltip;
        }

        private void TooltipUpdate(object sender, ToolTipEventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            InventoryItem item = (InventoryItem)sender;
            tooltip.Content = item.Ingredient.effects.ToString();
            ToolTip = tooltip;
        }

        private void InventoryItem_MouseEnter_1(object sender, MouseEventArgs e)
        {
            InventoryItem invI = (InventoryItem)sender;
            ToolTip tooltip = new ToolTip { Content = ConvertEffectsToString(invI.Ingredient.effects) };
            invI.ToolTip = tooltip;
        }

        private String ConvertEffectsToString(AlchymicEffect effects)
        {
            Array allEffects = Enum.GetValues(typeof(AlchymicEffect));

            String effectsString = "";
            int addedCount = 0,
                goalCount = this.countEffects(effects);



            foreach (AlchymicEffect effect in allEffects)
            {
                if ((effects & effect) == effect)
                {

                    if (goalCount == 1)
                    {
                        return effect.ToString();
                    }
                    else
                    {
                        if (addedCount == 0)
                        {
                            effectsString = effect.ToString();
                        }
                        else if (addedCount == goalCount - 1)
                        {
                            if (goalCount >= 3)
                            {
                                effectsString += ", and " + effect.ToString();
                            }
                            else
                            {
                                effectsString += " and " + effect.ToString();
                            }
                        }
                        else
                        {
                            effectsString += ", " + effect.ToString();
                        }

                        addedCount++;
                    }
                }

            }

            return effectsString;
        }

        public int countEffects(AlchymicEffect effects)
        {
            long effectValue = (long)effects;
            int count = 0;

            while (effectValue > 0)
            {
                effectValue &= (effectValue - 1);
                count++;
            }
            return count;
        }

        private void ingB_MouseEnter(object sender, MouseEventArgs e)
        {
            PotionIngredientBox ingB = (PotionIngredientBox)sender;
            if(ingB.CraftingIngredient != null)
            {
                ToolTip tooltip = new ToolTip { Content = ConvertEffectsToString(ingB.CraftingIngredient.effects) };
                ingB.ToolTip = tooltip;
            }
        }

        private void pbxPotion_MouseEnter(object sender, MouseEventArgs e)
        {
            PotionBox pbx = (PotionBox)sender;
            if (pbx.CraftedPotion != null)
            {
                ToolTip tooltip = new ToolTip { Content = ConvertEffectsToString(pbx.CraftedPotion.effects) };
                pbx.ToolTip = tooltip;
            }
        }
    }
}