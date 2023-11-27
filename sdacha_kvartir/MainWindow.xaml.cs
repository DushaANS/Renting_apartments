using System;
using System.Collections.Generic;
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

namespace sdacha_kvartir
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = TextBox.Text.Trim();
            string pass = passBox.Password.Trim();

            string login_user = "user";
            string pass_user = "0";

            string login_admin = "admin";
            string pass_admin = "0";

            if (login.Length < 1)
            {
                TextBox.ToolTip = "это поле введено не корректно!";
                TextBox.Background = (SolidColorBrush) new BrushConverter().ConvertFromString("#F08080");
            }
            else if (pass.Length < 1)
            {
                passBox.ToolTip = "это поле введено не корректно!";
                passBox.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#F08080");
            }
            else
            {
                TextBox.ToolTip = "";
                TextBox.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                if (login == login_user && pass == pass_user)
                {
                    user();
                }
                else if (login == login_admin && pass == pass_admin)
                {
                    admin();
                }
            }
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        public void admin()
        {
            Disappearance();
            //user user = new user();
            //user.Show();
            //this.Hide();
        }
        public void user()
        {
            //user user = new user();
            //user.Show();
            //this.Hide();
        }
        public void meneger()
        {
            //user user = new user();
            //user.Show();
            //this.Hide();
        }

        public void ScrollEnter()
        {
            
            scroll_output.Children.Clear();
            using (SqlConnection connection = new SqlConnection($@"Data Source = 10.10.10.26, 1433; Initial Catalog = DataBase; User ID = sa; Password = Rustam/634; "))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"select * from [DataBase].[dbo].[Developer]", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Output output = new Output();
                        output.INN.Content = reader[0];
                        output.developer.Content = reader[1];
                        output.mainWindow = this;
                        scroll_output.Children.Add(output);
                    }
                }
            }
        }
        
        public void Disappearance()
        {
            menu.Visibility = Visibility.Visible;
            entry_menu.Visibility = Visibility.Hidden;
            ScrollEnter();
            scroll_view1.Visibility = Visibility.Visible;

        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        { 
            nazad.Visibility = Visibility.Collapsed;
            scroll_view1.Visibility = Visibility.Visible;
            scroll_view2.Visibility = Visibility.Hidden;
        }

        private void exit2_click(object sender, RoutedEventArgs e)
        {
            entry_menu.Visibility= Visibility.Visible;
            menu.Visibility= Visibility.Hidden;
            scroll_view1.Visibility = Visibility.Hidden;
            scroll_view2.Visibility = Visibility.Hidden;
        }
    }
}
  
