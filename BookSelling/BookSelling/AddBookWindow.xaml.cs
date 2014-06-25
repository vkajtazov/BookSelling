using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace BookSelling
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }
        private void uploadFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.FileName = "Image";
            fd.DefaultExt = ".jpg";
            fd.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            Nullable<bool> result = fd.ShowDialog();

            if (result==true)
            {
                string fileName = fd.FileName;
                //File.Copy(fileName, newPathToFile);
            }
        }
    }
}
