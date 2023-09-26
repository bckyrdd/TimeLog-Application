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
using System.Windows.Forms;



namespace TimeLog
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public DateTime LoginTime { get; set; }
        public int LoginID { get; set; }
        public Window2()
        {
            InitializeComponent();
          
            if (UserSession.IsLoggedIn)
            {
                logoutBtn.Visibility = Visibility.Visible;
                loginBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                logoutBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new NewUserWindow();
            this.Close();
            newUserWindow.Show();
        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginUserWindow loginUserWindow = new LoginUserWindow();
            this.Close();
            loginUserWindow.Show();
        }

        private DataTable dataTable;
        private void LoadData()
        {
            string connectionString = @"Data Source=LAPTOP-PINUHAPH;Initial Catalog = TimeLogdb;User ID=sa;Password=testpassword";
            SqlConnection conn;

            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string querySelect = "SELECT * FROM [dbo].[timeTable]";
                SqlCommand cmd = new SqlCommand(querySelect, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                timeGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void gridLoad(object sender, RoutedEventArgs e)
        {
            timeGrid.IsReadOnly = true;
            LoadData();
        }
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-PINUHAPH;Initial Catalog = TimeLogdb;User ID=sa;Password=testpassword";
            SqlConnection conn;

            DateTime logoutClicked = DateTime.Now;

                using (conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        TimeSpan duration = logoutClicked - LoginTime;
                        string formattedDuration = string.Format("{0:D2}:{1:D2}:{2:D2}", duration.Hours, duration.Minutes, duration.Seconds);

                        string queryUpdate = "UPDATE [dbo].[timeTable] SET [logoutTime] = @logoutClicked, [renderedTime] = @duration WHERE ID = @loggedInUserID";
                        SqlCommand updateCmd = new SqlCommand(queryUpdate, conn);

                        updateCmd.Parameters.AddWithValue("@loggedInUserID", LoginID);
                        updateCmd.Parameters.AddWithValue("@logoutClicked", logoutClicked);
                        updateCmd.Parameters.AddWithValue("@duration", formattedDuration);

                        SqlDataReader reader = updateCmd.ExecuteReader();
                        conn.Close();

                        loginBtn.Visibility = Visibility.Visible;
                        logoutBtn.Visibility = Visibility.Collapsed;

                        System.Windows.MessageBox.Show("Successfully");
                        LoadData();
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.MessageBox.Show("Error: " + ex.Message);
                    }
                }
        }
    }
}