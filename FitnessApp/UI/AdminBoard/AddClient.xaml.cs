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

namespace FitnessApp
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        string name;
        string phone;
        string mail;
        string number;
        string address;
        string barcode;
        string notes;

        string kliensId;
        string berletId;
        string vasarlasiDatum;
        string vonalKod;
        string eddigiBelepesszam;
        string eladasiAr;
        string ervenyes;
        string elsohasznalatiDatum;
        string teremId;

        public AddClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name = nameBox.Text;
            phone = phoneBox.Text;
            mail = mailBox.Text;
            number = numberBox.Text;
            address = adressBox.Text;
            barcode = barcodeBox.Text;
            notes = notesBox.Text;
            berletId = ticketTypeBox.Text;
            //var dateString2 = DateTime.Now.ToString("yyyy-mm-dd");

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO Kliensek (nev,telefon,email,is_deleted,photo,inserted_date,szemelyi,cim,vonalkod,megjegyzesek) " +
                "VALUES (?name, ?phone, ?mail, 'NEM', ' ', CURDATE(), ?number, ?address, ?barcode, ?notes);", connection);
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

            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO KliensBerletei (kliens_id, berlet_id, vasarlasi_datum, vonalkod, eddigibelepesszam, eladasiar, ervenyes, elsohasznalati_datum, terem_id) " +
            "VALUES (6, ?berletId, CURDATE(), ?barcode, 10, 125, 'IGEN', '2021-05-17', 1);", connection);
            cmd1.Parameters.AddWithValue("?berletId", berletId);
            cmd1.Parameters.AddWithValue("?barcode", barcode);

            connection.Open();
            DataTable dTable4 = new DataTable();
            dTable4.Load(cmd1.ExecuteReader());
            connection.Close();
            MessageBox.Show("The new client has been added.");

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
