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
using System.Windows.Threading;

namespace BookSelling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string connectionString = BookSelling.Properties.Settings.Default.connectionString;
        private string[] MenuList;
        private static int Height = 50;
        private static int Width = 150;
        private DispatcherTimer HeightTimer;
        private DispatcherTimer WidthTimer;

        public MainWindow()
        {
            InitializeComponent();
            loadHeightTimer();
            loadWidthTimer();
            // testing connection with database
        //    lst.ItemsSource = DatabaseConnectionFile.getDataTable("Users").DefaultView;
        }

        public void loadHeightTimer() {
            HeightTimer = new DispatcherTimer();
            HeightTimer.Tick += new EventHandler(HeightTimer_Tick);
            HeightTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        public void loadWidthTimer()
        {
            WidthTimer = new DispatcherTimer();
            WidthTimer.Tick += new EventHandler(WidthTimer_Tick);
            WidthTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void HeightTimer_Tick(object sender, EventArgs e)
        {       

                
             CommandManager.InvalidateRequerySuggested();
             Application.Current.MainWindow.Height += 2;
             if (Height <= 0) {
                 HeightTimer.Stop();
                 WidthTimer.Start();
             }
             Height -= 1;
        }

        private void WidthTimer_Tick(object sender, EventArgs e)
        {


            CommandManager.InvalidateRequerySuggested();
            Application.Current.MainWindow.Width += 2;
            if (Width <= 0)
            {
                WidthTimer.Stop();
                BookPresentation.Visibility = Visibility.Visible;
            }
            Width -= 1;
        }




        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            if (checkRequiredFields()) {
                LoginView.Visibility = Visibility.Collapsed;
                HeightTimer.Start();
                LoggedAs.Content = "Logged as: " + UsernameTxt.Text;
            }

        }

        private bool checkRequiredFields() {
            bool t = true;

            if (UsernameTxt.Text == "")
            {
                usernameValidator.Visibility = Visibility.Visible;
                t = false;
            }
            if (PasswordTxt.Text == "")
            {
                passswordValidator.Visibility = Visibility.Visible;
                t = false;
            }

            if (UsernameTxt.Text != "")
            {
                usernameValidator.Visibility = Visibility.Hidden;
            }
            if (PasswordTxt.Text != "")
            {
                passswordValidator.Visibility = Visibility.Hidden;
            }
            return t;
        }



    }
}
