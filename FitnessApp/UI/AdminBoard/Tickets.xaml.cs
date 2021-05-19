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
    /// Interaction logic for Tickets.xaml
    /// </summary>
    public partial class Tickets : Window
    {

        public Tickets()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM BerletTipusok", connection);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();

            dtGrid.DataContext = dTable;
        }

        private void addTicketButton_Click(object sender, RoutedEventArgs e)
        {
            AddTicket objAddTicket = new AddTicket();
            objAddTicket.Show();
        }

        private void deleteTicketButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteTicket objDeleteTicket = new DeleteTicket();
            objDeleteTicket.Show();
        }

        private void refreshTicketsButton_Click(object sender, RoutedEventArgs e)
        {

                string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM BerletTipusok", connection);
                connection.Open();
                DataTable dTable = new DataTable();
                dTable.Load(cmd.ExecuteReader());
                connection.Close();

                dtGrid.DataContext = dTable;
            }
    }
}
