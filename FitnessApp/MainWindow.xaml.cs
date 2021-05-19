using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FitnessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string barCode;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            barCode = barcodeBox.Text;
            bool match = false;

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT vonalkod FROM Kliensek", connection);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();
            var firstCharOfString = StringInfo.GetNextTextElement(barCode, 0);

            List<string> list = new List<string>();
            for (var i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                list.Add(row["vonalkod"].ToString());
                if(list[i] == barCode)
                {
                    match = true;
                }                
            }

            if (Regex.IsMatch(barCode, "\\A[0-9]{10}\\z"))
            {
                if(match == true) {
                    if (firstCharOfString == "1")
                    {
                        DashBoard objDashBoard = new DashBoard(barCode);
                        objDashBoard.Show();
                    }
                    else if (firstCharOfString == "0")
                    {
                        UserBoard objUserBoard = new UserBoard(barCode);
                        objUserBoard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid bar code!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid bar code\nPlease try again!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid length or format!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}