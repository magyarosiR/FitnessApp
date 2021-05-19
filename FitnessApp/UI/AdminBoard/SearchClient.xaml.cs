using FitnessApp.UI.AdminBoard;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace FitnessApp
{
    /// <summary>
    /// Interaction logic for SearchClient.xaml
    /// </summary>
    public partial class SearchClient : Window
    {
        string barCode;

        public SearchClient()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            barCode = barcodeBox.Text;

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM Kliensek WHERE vonalkod = ?barCode", connection);
            cmd1.Parameters.AddWithValue("?barCode", barCode);
            connection.Open();
            DataTable dTable1 = new DataTable();
            dTable1.Load(cmd1.ExecuteReader());
            connection.Close();

            dataGrid.DataContext = dTable1;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            Update objUpdate = new Update();
            objUpdate.Show();
        }
    }
}
