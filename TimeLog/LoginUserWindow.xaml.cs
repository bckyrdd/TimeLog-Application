using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace TimeLog
{
    /// <summary>
    /// Interaction logic for LoginUserWindow.xaml
    /// </summary>
    public partial class LoginUserWindow : Window
    {
        public LoginUserWindow()
        {
            InitializeComponent();
        }

        int loggedInUserID = -1;
        private void createButtonClick(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-PINUHAPH;Initial Catalog = TimeLogdb;User ID=sa;Password=testpassword";
            SqlConnection conn;
            string username = user.Text;
            string password = pass.Password;
            DateTime loginClicked = DateTime.Now;

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
                    string querySelect = "SELECT [password] FROM [dbo].[user] WHERE [username] = @username";
                    SqlCommand selectCmd = new SqlCommand(querySelect, conn);
                    selectCmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = selectCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string hashedPasswordFromDb = reader["password"].ToString();
                        reader.Close();

                        if (BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDb))
                        {   
                            UserSession.IsLoggedIn = true;

                            string queryInsert = "INSERT INTO [dbo].[timeTable] ([loginTime]) OUTPUT INSERTED.ID VALUES (@loginClicked)";
                            SqlCommand insertCmd = new SqlCommand(queryInsert, conn);
                            insertCmd.Parameters.AddWithValue("@loginClicked", loginClicked);
                            int insertedID = (int)insertCmd.ExecuteScalar();

                            MessageBox.Show("Login Successful");
                            Window2 newWindow = new Window2();
                            newWindow.LoginTime = loginClicked;
                            newWindow.LoginID = insertedID;
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
