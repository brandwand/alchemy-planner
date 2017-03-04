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
        public Inventory InventorySource { get; set; } = new Inventory();

        public InventoryDisplay()
        {
            InitializeComponent();
            InventorySource = Models.WorldController.player.getInventory();
            tbInventoryName.Text = InventorySource.Name;

            InventorySource.addItemToInventory(new Ingredient("Ex: Dragon Heart", "Path", 5000, Rarity.Godlike, AlchymicEffect.RegenerateHealth | AlchymicEffect.Nightvision));
            InventorySource.addItemToInventory(new Ingredient("Ex: Tunfra Cotton", "Path", 10, Rarity.Common, AlchymicEffect.RestoreHealth | AlchymicEffect.RestoreMana));
            InventorySource.addItemToInventory(new Ingredient("Ex: Vampire Teeth", "Path", 750, Rarity.Rare, AlchymicEffect.DamageHealth | AlchymicEffect.Nightvision));

            lbInventory.ItemsSource = InventorySource.getItems();
        }
    }
}
