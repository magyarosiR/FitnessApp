using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Interaction logic for UserBoard.xaml
    /// </summary>
    public partial class UserBoard : Window
    {
        string valueFromLogPage;
        string valueFromLogPage2;
        string name;
        string telefon;
        string email;
        string expired;
        string expired2;

        public UserBoard()
        {
            InitializeComponent();           
        }

        public UserBoard(string val) : this()
        {
            valueFromLogPage = val;
            valueFromLogPage2 = val;
            this.Loaded += new RoutedEventHandler(Page2_Loaded);

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT nev, telefon, email FROM Kliensek WHERE vonalkod = ?valueFromLogPage", connection);
            cmd.Parameters.AddWithValue("?valueFromLogPage", valueFromLogPage);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();


            if (dTable.Rows.Count > 0)
            {
                DataRow row = dTable.Rows[0];

                name = row["nev"].ToString();
                telefon = row["telefon"].ToString();
                email = row["email"].ToString();
            }
                
            MySqlCommand cmd2 = new MySqlCommand("SELECT bt.hanynapigervenyes, bt.hanybelepeservenyes FROM BerletTipusok bt, Belepesek b, Kliensek k WHERE bt.berlet_id = b.berlet_id and b.kliens_id = k.kliens_id and k.vonalkod=?valueFromLogPage2;", connection);
            cmd2.Parameters.AddWithValue("?valueFromLogPage2", valueFromLogPage2);
            connection.Open();
            DataTable dTable2 = new DataTable();
            dTable2.Load(cmd2.ExecuteReader());
            connection.Close();
            
            if (dTable2.Rows.Count > 0)
            {
                DataRow row = dTable2.Rows[0];

                expired = row["hanynapigervenyes"].ToString();
                expired2 = row["hanybelepeservenyes"].ToString();
   
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
   
            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=1998;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd3 = new MySqlCommand("UPDATE BerletTipusok bt, Belepesek b, Kliensek k SET bt.hanybelepeservenyes = bt.hanybelepeservenyes - 1 WHERE  bt.berlet_id = b.berlet_id and b.kliens_id = k.kliens_id and k.vonalkod=?valueFromLogPage2;", connection);
            cmd3.Parameters.AddWithValue("?valueFromLogPage2", valueFromLogPage2);
            connection.Open();
            DataTable dTable3 = new DataTable();
            dTable3.Load(cmd3.ExecuteReader());
            connection.Close();

            if (dTable3.Rows.Count > 0)
            {
                DataRow row = dTable3.Rows[0];

                expired2 = row["hanybelepeservenyes"].ToString();

            }

            MessageBox.Show("Are you in!", "Welcome!", MessageBoxButton.OK, MessageBoxImage.Information);
            entryButton.IsEnabled = false;

            //Application.Current.Shutdown();

           }
        void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            welcomeLabel.Text = "Welcome, " + name + "!";
            telefonLabel.Text = "Telefon: 0" + telefon;
            emailLabel.Text = "E-mail: " + email;
            expiredLabel.Text = "Expired: " + expired;

            int value = Int32.Parse(expired2);
            if (value > 1)
            {
                expired2Label.Text = "Remaining: " + expired2;
            }
            else
            {
                expired2Label.Text = "EXPIRED!";
            }

            warningLabel.Visibility = Visibility.Hidden;

            if (value == 1)
            {
                warningLabel.Text = "You have 1 day remaining!";
                warningLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
