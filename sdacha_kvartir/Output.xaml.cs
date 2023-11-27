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
    /// Логика взаимодействия для Output.xaml
    /// </summary>
    public partial class Output : UserControl
    {
        internal MainWindow mainWindow;

        public Output()
        {
            InitializeComponent();
        }

        private void see_flats_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.nazad.Visibility = Visibility.Visible;

            mainWindow.scroll_view1.Visibility = Visibility.Hidden;
            mainWindow.scroll_view2.Visibility = Visibility.Visible;
            mainWindow.scroll_output_flats.Children.Clear();

            using (SqlConnection connection = new SqlConnection($@"Data Source = 10.10.10.26, 1433; Initial Catalog = DataBase; User ID = sa; Password = Rustam/634;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"select * from [DataBase].[dbo].[Home] where [Home].[INN_застройщика] = {INN.Content} ", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Doma homes = new Doma();
                        homes.home_l.Content = reader[0];
                        mainWindow.scroll_output_flats.Children.Add(homes);
                    }
                }
            }
        }
    }
}
