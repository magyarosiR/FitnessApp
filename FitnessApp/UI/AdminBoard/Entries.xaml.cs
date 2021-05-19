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
    /// Interaction logic for Entries.xaml
    /// </summary>
    public partial class Entries : Window
    {
        public Entries()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Belepesek", connection);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();

            dtGrid.DataContext = dTable;
        }
    }
}
