using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
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
using System.Windows.Shapes;

namespace FitnessApp.UI.AdminBoard
{
    /// <summary>
    /// Interaction logic for AddTicket.xaml
    /// </summary>
    public partial class AddTicket : Window
    {
        string name;
        string price;
        string hanynapigervenyes;
        string hanybelepeservenyes;
        string torolve;
        string teremID;
        string hanyoratol;
        string hanyoraig;
        string napontahanyszor;
        public AddTicket()
        {
            InitializeComponent();
        }

        private void addTicketButton_Click(object sender, RoutedEventArgs e)
        {
            name = nameBox.Text;
            price = priceBox.Text;

            //hanynapigervenyes = hanynapigervenyesBox.Text;

            if ((bool)radiobutton1.IsChecked)
            {
                hanynapigervenyes = "30";
            }
            else if ((bool)radiobutton2.IsChecked)
            {
                hanynapigervenyes = "365";
            }

            //hanybelepeservenyes = hanybelepservenyesBox.Text;

            if ((bool)rb1.IsChecked)
            {
                hanybelepeservenyes = "10";
            }
            else if ((bool)rb2.IsChecked)
            {
                hanybelepeservenyes = "20";
            }
            else if ((bool)rb3.IsChecked)
            {
                hanybelepeservenyes = "30";
            }
            else if ((bool)rb4.IsChecked)
            {
                hanybelepeservenyes = "365";
            }
            else if ((bool)rb5.IsChecked)
            {
                hanybelepeservenyes = "730";
            }

            //Torolve

            if ((bool)rdb1.IsChecked)
            {
                torolve = "NEM";
            }else if ((bool)rdb2.IsChecked)
            {
                torolve = "IGEN";
            }

            teremID = teremIdBox.Text;
            hanyoratol = hanyoratolBox.Text;
            hanyoraig = hanyoraigBox.Text;
            napontahanyszor = napontahanyszorBox.Text;
            //var dateString2 = DateTime.Now.ToString("yyyy-mm-dd");

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO BerletTipusok (megnevezes,ar,hanynapigervenyes,hanybelepeservenyes,torolve,terem_id,hanyoratol,hanyoraig,napontahanyszorhasznalhato) " +
                "VALUES (?name, ?price, ?hanynapigervenyes, ?hanybelepeservenyes, ?torolve, ?teremID, ?hanyoratol, ?hanyoraig, ?napontahanyszorhasznalhato);", connection);
            cmd.Parameters.AddWithValue("?name", name);
            cmd.Parameters.AddWithValue("?price", price);
            cmd.Parameters.AddWithValue("?hanynapigervenyes", hanynapigervenyes);
            cmd.Parameters.AddWithValue("?hanybelepeservenyes", hanybelepeservenyes);
            cmd.Parameters.AddWithValue("?torolve", torolve);
            cmd.Parameters.AddWithValue("?teremID", teremID);
            cmd.Parameters.AddWithValue("?hanyoratol", hanyoratol);
            cmd.Parameters.AddWithValue("?hanyoraig", hanyoraig);
            cmd.Parameters.AddWithValue("?napontahanyszorhasznalhato", napontahanyszor);
            //cmd.Parameters.AddWithValue("?date", dateString2.ToString());

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                DataTable dTable4 = new DataTable();
                dTable4.Load(cmd.ExecuteReader());
                MessageBox.Show("The new ticket has been added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! The fields are empty!");
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Please fill all fields of data!");
            }
        }

        private void teremIDValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void numberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
