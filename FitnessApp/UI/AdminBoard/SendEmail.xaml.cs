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
    /// Interaction logic for SendEmail.xaml
    /// </summary>
    public partial class SendEmail : Window
    {
        string valueFromLogPage;
        string email;
        public SendEmail()
        {
            InitializeComponent();
        }

        public SendEmail(string val) : this()
        {
            valueFromLogPage = val;
            //this.Loaded += new RoutedEventHandler(sendButton_Click);

            string connectionString = "SERVER=localhost;DATABASE=fitness;UID=root;PASSWORD=pw;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT email FROM Kliensek WHERE vonalkod = ?valueFromLogPage", connection);
            cmd.Parameters.AddWithValue("?valueFromLogPage", valueFromLogPage);
            connection.Open();
            DataTable dTable = new DataTable();
            dTable.Load(cmd.ExecuteReader());
            connection.Close();

            if (dTable.Rows.Count > 0)
            {
                DataRow row = dTable.Rows[0];
                email = row["email"].ToString();
            }
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(email, "pw");
                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage("donotreply@domain.com", nameBox.Text, subjectBox.Text, msgBox.Text);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;
                client.Send(mm);

                MessageBox.Show("Successfully Message Sent!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Message not sent because of:" + ex.ToString());
            }
        }

    }
}
