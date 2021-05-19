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

namespace FitnessApp.UI.AdminBoard
{
    /// <summary>
    /// Interaction logic for DeleteTicket.xaml
    /// </summary>
    public partial class DeleteTicket : Window
    {
        string name;
        public DeleteTicket()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            name = nameBox.Text;

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("DELETE FROM BerletTipusok WHERE megnevezes = ?name", connection);
            //MySqlCommand cmd = new MySqlCommand("UPDATE Kliensek SET is_deleted = 'IGEN' WHERE vonalkod = ?barCode", connection);
            cmd.Parameters.AddWithValue("?name", name);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                DataTable dTable = new DataTable();
                dTable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex.Message);
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Ticket has been deleted!");
            }
        }
    }
}
