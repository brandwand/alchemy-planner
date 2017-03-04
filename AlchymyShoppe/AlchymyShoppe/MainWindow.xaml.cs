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

namespace AlchymyShoppe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string HubScreenBackgroundPath = "Images/Backgrounds/hubScreenBackground.jpg";

        public MainWindow()
        {
            InitializeComponent();
            imgBackground.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), System.IO.Directory.GetCurrentDirectory() + HubScreenBackgroundPath));
        }

        private void btnAlchymyTable_Click(object sender, RoutedEventArgs e)
        {
            AlchymyTableScreen.Update();
            AlchymyTableScreen.Visibility = Visibility.Visible;
        }
    }
}
