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
namespace AlchymyShoppe.Controls
{
    /// <summary>
    /// Interaction logic for InventoryDisplay.xaml
    /// </summary>
    public partial class InventoryDisplay : UserControl
    {
        public Models.Inventory InventorySource { get; set; } = new Models.Inventory();

        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
        }


        public InventoryDisplay()
        {
            InitializeComponent();
            InventorySource = Models.WorldController.player.getInventory();
            tbInventoryName.Text = InventorySource.Name;

            InventorySource.addItemToInventory(new Models.Ingredient("Ex: Dragon Heart", "Path", 5000, Models.Rarity.Godlike, Models.AlchymicEffect.RegenerateHealth | Models.AlchymicEffect.Nightvision));
            InventorySource.addItemToInventory(new Models.Ingredient("Ex: Tunfra Cotton", "Path", 10, Models.Rarity.Common, Models.AlchymicEffect.RestoreHealth | Models.AlchymicEffect.RestoreMana));
            InventorySource.addItemToInventory(new Models.Ingredient("Ex: Vampire Teeth", "Path", 750, Models.Rarity.Rare, Models.AlchymicEffect.DamageHealth | Models.AlchymicEffect.Nightvision));

            lbInventory.ItemsSource = InventorySource.getItems();
        }
    }
}
