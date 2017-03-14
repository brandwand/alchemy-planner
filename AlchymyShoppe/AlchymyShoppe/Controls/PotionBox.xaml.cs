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
    /// Interaction logic for PotionBox.xaml
    /// </summary>
    public partial class PotionBox : UserControl
    {
        private Models.Potion craftedPotion;

        public Models.Potion CraftedPotion
        {
            get
            {
                return craftedPotion;
            }
            set
            {
                craftedPotion = value;
                LoadImage();
            }
        }

        private void LoadImage()
        {
            if(craftedPotion != null)
            {
                LoadPotionImage();
            }
            else
            {
                UnloadPotionImage();
            }
        }

        private void UnloadPotionImage()
        {
            imgPotion.Source = null;
        }

        private void LoadPotionImage()
        {
            imgPotion.Source = ImageUtil.BitmapToImageSource(Resoures.potion);
        }

        public PotionBox()
        {
            InitializeComponent();
            imgPotionBackground.Source = ImageUtil.BitmapToImageSource(Resoures.emptyBoxFiller);
        }
    }
}
