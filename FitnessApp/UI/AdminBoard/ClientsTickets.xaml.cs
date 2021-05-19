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
    /// Interaction logic for ClientsTickets.xaml
    /// </summary>
    public partial class ClientsTickets : Window
    {
        public ClientsTickets()
        {
            InitializeComponent();
        }

        private void listTicketsButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM KliensBerletei", connection);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();

            dtGrid.DataContext = dTable;
        }

        private void deleteClientTicketsButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteClientsTicket objDeleteClientsTicket = new DeleteClientsTicket();
            objDeleteClientsTicket.Show();
        }

        private void refreshClientsButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM KliensBerletei", connection);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();

            dtGrid.DataContext = dTable;
        }
    }
}
