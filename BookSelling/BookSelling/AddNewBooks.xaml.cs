using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for AddNewBooks.xaml
    /// </summary>
    public partial class AddNewBooks : Window
    {
        private string fileName;
        public AddNewBooks()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                // Open document 
                fileName = ofd.FileName;
                Debug.WriteLine(fileName);
                string file = System.IO.Path.GetFileName(fileName);
                string destFile = AppDomain.CurrentDomain.BaseDirectory;
                destFile = destFile.Substring(0, destFile.LastIndexOf("\\"));
                destFile = destFile.Substring(0, destFile.LastIndexOf("\\"));
                destFile = destFile.Substring(0, destFile.LastIndexOf("\\"));
                destFile = destFile + "\\Resources\\" + file;
                File.Copy(fileName, destFile,true);
                fileName = destFile;
                //File.Copy(fileName,destFile);
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DatabaseConnectionFile.insertBook(tbTitle.Text, tbAuthor.Text,cbGenre.SelectedValue.ToString(),
                    tbPrice.Text, tbProm.Text, tbCount.Text, fileName);
                DialogResult = true;
            }
            catch (Exception)
            {

                throw;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
