using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        string name;
        string phone;
        string mail;
        string number;
        string address;
        string barcode;
        string notes;
        public Update()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            //string insertQuery = "UPDATE Kliensek SET email = '" + email.Text + "', is_deleted = '" + torolve_kliens.Text + "',photo = '" + kep.Text + "',szemelyi_szam = '" + szemelyi.Text + "',cim = '" + cim.Text + "',vonalkod = '" + vonalkod.Text + "',megjegyzesek = '" + megjegyzes.Text + "' WHERE nev = '" + nev.Text + "'";
            ////MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            //this.AUD(insertQuery, 1);
            //this.resetAll();

            name = nameBox.Text;
            phone = phoneBox.Text;
            mail = mailBox.Text;
            number = numberBox.Text;
            address = adressBox.Text;
            barcode = barcodeBox.Text;
            notes = notesBox.Text;

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("UPDATE Kliensek SET nev = ?name, telefon = ?phone, email = ?mail, is_deleted = 'NEM', photo = ' ', inserted_date = '2021-05-15', szemelyi = ?number, cim = ?address, megjegyzesek = ?notes WHERE vonalkod = ?barcode", connection);
            cmd.Parameters.AddWithValue("?name", name);
            cmd.Parameters.AddWithValue("?phone", phone);
            cmd.Parameters.AddWithValue("?mail", mail);
            cmd.Parameters.AddWithValue("?number", number);
            cmd.Parameters.AddWithValue("?address", address);
            cmd.Parameters.AddWithValue("?barcode", barcode);
            cmd.Parameters.AddWithValue("?notes", notes);
            //cmd.Parameters.AddWithValue("?date", dateString2.ToString());
            connection.Open();
            DataTable dTable3 = new DataTable();

            dTable3.Load(cmd.ExecuteReader());
            connection.Close();
            MessageBox.Show("The client has been updated.");
        }

        private void barCodeValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void numberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void emailValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
