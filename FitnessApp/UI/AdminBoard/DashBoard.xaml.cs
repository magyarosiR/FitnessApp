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
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    { 
        string valueFromLogPage;
        string valueFromLogPage2;
        string name;

        public DashBoard()
        {
            InitializeComponent();
        }

        public DashBoard(string val) : this()
        {
            valueFromLogPage = val;
            valueFromLogPage2 = val;
            this.Loaded += new RoutedEventHandler(Page2_Loaded);

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT nev FROM Kliensek WHERE vonalkod = ?valueFromLogPage", connection);
            cmd.Parameters.AddWithValue("?valueFromLogPage", valueFromLogPage);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();


            if (dTable.Rows.Count > 0)
            {
                DataRow row = dTable.Rows[0];

                name = row["nev"].ToString();
         
            }
        }
        void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            welcomeLabel.Text = name + "'s admin page.";
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClient objAddClient = new AddClient();
            objAddClient.Show();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DeleteClient objDeleteClient = new DeleteClient();
            objDeleteClient.Show();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchClient objSearchClient = new SearchClient();
            objSearchClient.Show();
        }

        private void listButton_Click(object sender, RoutedEventArgs e)
        {
            ListClients objListClient = new ListClients();
            objListClient.Show();
        }

        private void listTicketsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsTickets objListTickets = new ClientsTickets();
            objListTickets.Show();
        }

        private void ticketsButton_Click(object sender, RoutedEventArgs e)
        {
            Tickets objTickets = new Tickets();
            objTickets.Show();
        }

        private void entryListButton_Click(object sender, RoutedEventArgs e)
        {
            Entries objEntries = new Entries();
            objEntries.Show();
        }

        private void sendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            SendEmail objEmail = new SendEmail(valueFromLogPage);
            objEmail.Show();
        }
    }
}
