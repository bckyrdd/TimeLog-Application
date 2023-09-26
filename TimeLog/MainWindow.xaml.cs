using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginBtnClick(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-PINUHAPH;Initial Catalog = TimeLogdb;User ID=sa;Password=testpassword";
            SqlConnection conn;

            string username = usernameBox.Text;
            string password = passwordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password");
                return;
            }

            using (conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string querySelect = "SELECT [password] FROM [dbo].[superUser] WHERE [username] = @username";
                    SqlCommand cmd = new SqlCommand(querySelect, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string hashedPasswordFromDb = reader["password"].ToString();

                        if (BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDb))
                        {
                            MessageBox.Show("Login Successful");
                            Window2 newWindow = new Window2();
                            this.Close();
                            newWindow.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }

                    conn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
}
