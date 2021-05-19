using FitnessApp.UI.AdminBoard;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    /// Interaction logic for ListClients.xaml
    /// </summary>
    public partial class ListClients : Window
    {
        public ListClients()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Kliensek", connection);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            //using (MySqlDataReader reader = cmd.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        string check;
            //        check = reader["is_deleted"].ToString();

            //        if (check == "NEM")
            //        {
            //            dTable.Load(reader);
            //        }
            //    }
            //}
            connection.Close();

            dtGrid.DataContext = dTable;
            //UPDATE Kliensek SET

        }

        private void addClientButton_Click(object sender, RoutedEventArgs e)
        {
            AddClient objAddClient = new AddClient();
            objAddClient.Show();

        }

        private void deleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteClient objDeleteClient = new DeleteClient();
            objDeleteClient.Show();
        }

        private void refreshClientsButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Kliensek", connection);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();

            dtGrid.DataContext = dTable;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.SelectAllCells();
            dtGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dtGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dtGrid.UnselectAllCells();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"E:\FitnessApp.xls");
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();

            MessageBox.Show("Exporting DataGrid data to Excel file created.xls");
        }

        private void save2Button_Click(object sender, RoutedEventArgs e)
        {
            Update objUpdate = new Update();
            objUpdate.Show();
        }
    }
}
