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
    /// Логика взаимодействия для Doma.xaml
    /// </summary>
    public partial class Doma : UserControl
    {
        public Doma()
        {
            InitializeComponent();
        }
        //internal MainWindow mainWindow;

        public MainWindow mainWindow;
        public Floor floor1;

        private void Home_btn_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection($@"Data Source = 10.10.10.26, 1433; Initial Catalog = DataBase; User ID = sa; Password = Rustam/634;"))
            {
                
                connection.Open();
                SqlCommand command = new SqlCommand($@"SELECT distinct [Этаж (floor)*] FROM [DataBase].[dbo].[Flats] Order by [Этаж (floor)*] asc", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Floor floor = new Floor();
                        floor.etag.Content = reader[0];
                        mainWindow.scroll_output_floot.Children.Add(floor);
                    }
                }
            }


            using (SqlConnection connection = new SqlConnection($@"Data Source = 10.10.10.26, 1433; Initial Catalog = DataBase; User ID = sa; Password = Rustam/634;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"select * from [DataBase].[dbo].[Flats] where Flats.[ID объекта *] = {home_l.Content} ", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FlatCard flatCard = new FlatCard();
                        flatCard.nomer.Content = reader[2];
                        flatCard.floor.Content = reader[9];
                        floor1.floot.Children.Add(flatCard);
                    }
                }
            }
        }
    }
}



