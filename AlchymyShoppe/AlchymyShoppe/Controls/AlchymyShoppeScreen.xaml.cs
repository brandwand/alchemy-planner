﻿using System;
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
    /// Interaction logic for AlchymyShoppeScreen.xaml
    /// </summary>
    public partial class AlchymyShoppeScreen : UserControl
    {
        public AlchymyShoppeScreen()
        {
            InitializeComponent();
            imgBackground.Source = ImageUtil.BitmapToImageSource(Resoures.alchymyTableScreenBackground);
        }

        private void btnHallway_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
