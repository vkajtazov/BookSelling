﻿using Microsoft.Win32;
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
                Debug.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }
        }
    }
}
