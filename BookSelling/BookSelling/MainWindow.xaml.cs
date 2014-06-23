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
        private static int heights = 25;
        private static int widths = 75;
        private DispatcherTimer Timer;



        public MainWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Remembered==true)
            {
                LoginView.Visibility = Visibility.Collapsed;
                loadTimer();
                widths = 75;
                heights = 25;
                Timer.Start();
                LoggedAs.Content = "Logged as: " + Properties.Settings.Default.UserName;
            }
            // testing connection with database
            //    lst.ItemsSource = DatabaseConnectionFile.getDataTable("Users").DefaultView;
        }

        public void loadTimer()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(HeightTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void HeightTimer_Tick(object sender, EventArgs e)
        {


            CommandManager.InvalidateRequerySuggested();
            Application.Current.MainWindow.Height += 8;
            if (heights <= 0)
            {
                Timer.Stop();
                Timer.Tick -= new EventHandler(HeightTimer_Tick);
                Timer.Tick += new EventHandler(WidthTimer_Tick);
                Timer.Start();
            }
            heights -= 1;
        }

        private void WidthTimer_Tick(object sender, EventArgs e)
        {


            CommandManager.InvalidateRequerySuggested();
            Application.Current.MainWindow.Width += 8;
            if (widths <= 0)
            {
                Timer.Stop();
                Timer.Tick -= new EventHandler(WidthTimer_Tick);
                BookPresentation.Visibility = Visibility.Visible;
            }
            widths -= 1;
        }

        private void MinimumWidthTimer_Tick(object sender, EventArgs e)
        {


            CommandManager.InvalidateRequerySuggested();
            Application.Current.MainWindow.Width -= 8;
            if (widths <= 0)
            {
                Timer.Stop();
                Timer.Tick -= new EventHandler(MinimumWidthTimer_Tick);
                LoginView.Visibility = Visibility.Visible;
            }
            widths -= 1;
        }

        private void MininumHeightTimer_Tick(object sender, EventArgs e)
        {


            CommandManager.InvalidateRequerySuggested();
            Application.Current.MainWindow.Height -= 8;
            if (heights <= 0)
            {
                Timer.Stop();
                Timer.Tick -= new EventHandler(MininumHeightTimer_Tick);
                Timer.Tick += new EventHandler(MinimumWidthTimer_Tick);
                Timer.Start();
            }
            heights -= 1;
        }




        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            if (checkRequiredFields())
            {
                LoginView.Visibility = Visibility.Collapsed;
                loadTimer();
                widths = 75;
                heights = 25;
                Timer.Start();
                LoggedAs.Content = "Logged as: " + UsernameTxt.Text;
                Properties.Settings.Default.Remembered =(bool) RememberChk.IsChecked;
                Properties.Settings.Default.UserName = UsernameTxt.Text;
                Properties.Settings.Default.Save();
            }

        }

        private bool checkRequiredFields()
        {
            bool t = true;

            if (UsernameTxt.Text == "")
            {
                usernameValidator.Visibility = Visibility.Visible;
                t = false;
            }
            if (PasswordTxt.Password == "")
            {
                passswordValidator.Visibility = Visibility.Visible;
                t = false;
            }

            if (UsernameTxt.Text != "")
            {
                usernameValidator.Visibility = Visibility.Hidden;
            }
            if (PasswordTxt.Password != "")
            {
                passswordValidator.Visibility = Visibility.Hidden;
            }
            return t;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            l.Foreground = Brushes.Red;
            this.Cursor = Cursors.Hand;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            l.Foreground = Brushes.DarkRed;
            this.Cursor = Cursors.Arrow;
        }

        private void LogOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            widths = 75;
            heights = 25;

            BookPresentation.Visibility = Visibility.Collapsed;

            Timer.Tick += new EventHandler(MininumHeightTimer_Tick);
            Timer.Start();
            if (!(bool)RememberChk.IsChecked)
            {
                clearLoginFields();
            }
            Properties.Settings.Default.Remembered = false;
            Properties.Settings.Default.UserName = null;
            Properties.Settings.Default.Save();

        }

        private void clearLoginFields()
        {
            UsernameTxt.Text = "";
            PasswordTxt.Password = "";
            UserSelection.SelectedIndex = 0;
        }




    }
}
