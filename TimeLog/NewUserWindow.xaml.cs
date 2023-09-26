using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class NewUserWindow : Window
    {
        public NewUserWindow()
        {
            InitializeComponent();
        }

        private void createButtonClick(object sender, RoutedEventArgs e)
        {
           
            string employeeID = empID.Text;
            string completeName = fullName.Text;
            string username = user.Text;
            string password = pass.Password;
            string confirmPassword = confirmPass.Password;

            string connectionString = @"Data Source=LAPTOP-PINUHAPH;Initial Catalog = TimeLogdb;User ID=sa;Password=testpassword"; 
            SqlConnection conn;

            if (string.IsNullOrEmpty(employeeID))
            {
                MessageBox.Show("Please enter your Employee ID");
                return;
            }

            if (string.IsNullOrEmpty(completeName))
            {
                MessageBox.Show("Please enter your Complete Name");
                return;
            }

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 11);

            using (conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryInsert = "INSERT INTO [dbo].[user] ([employeeID], [completeName], [username], [password]) VALUES (@employeeID, @completeName, @username, @hashedPassword)";
                    SqlCommand cmd = new SqlCommand(queryInsert, conn);

                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@completeName", completeName);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Successfully");

                    Window2 newWindow = new Window2();
                    this.Close();
                    newWindow.Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}