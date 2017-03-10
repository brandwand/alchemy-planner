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
    /// Interaction logic for AlchymyTableScreen.xaml
    /// </summary>
    public partial class AlchymyTableScreen : UserControl
    {
        public AlchymyTableScreen()
        {
            InitializeComponent();
            //btnGold.DataContext = Models.WorldController.player;
            imgBackground.Source = ImageUtil.BitmapToImageSource(Resoures.alchymyTableScreenBackground);
//            idInventory.InventorySource = Models.WorldController.player.getInventory();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        public void Update()
        {
            //playerInventoryDisplay. WorldController.Player.Inventory.items
        }

        private void lbInventory_Drop(object sender, DragEventArgs e)
        {

        }

        private void lbInventory_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void lbInventory_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ingB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ingB_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
