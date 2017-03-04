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
            imgBackground.Source = ImageUtil.BitmapToImageSource(ImageResoures.alchymyTableScreenBackground);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        public void Update()
        {
            //playerInventoryDisplay. WorldController.Player.Inventory.items
        }
    }
}
