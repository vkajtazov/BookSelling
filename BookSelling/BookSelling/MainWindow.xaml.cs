using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace BookSelling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string connectionString = BookSelling.Properties.Settings.Default.connectionString;

        public MainWindow()
        {
            InitializeComponent();


            // testing connection with database
            lst.ItemsSource = DatabaseConnectionFile.getDataTable("Users").DefaultView;
        }
    }
}
