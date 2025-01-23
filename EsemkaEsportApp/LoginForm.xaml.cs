using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;

namespace EsemkaEsportApp
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {

        private readonly string connectionString = @"Server=ALVIN\ALVINTORIALSQL;Database=EsemkaEsport;Trusted_Connection=True;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ToCreateAccountForm_Click(object sender, EventArgs e)
        {
            var createAccountForm = new CreateAccountForm();
            createAccountForm.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (AuthenticateUser(username, password))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string roleQuery = "SELECT role FROM [user] WHERE username=@username";

                        using (SqlCommand command = new SqlCommand(roleQuery, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);

                            int userRole = Convert.ToInt32(command.ExecuteScalar());

                            switch(userRole)
                            {
                                case 0:
                                    var scheduleForm = new ScheduleForm();
                                    scheduleForm.Show();
                                    this.Close();
                                    break;
                                case 1:
                                    var mainWindow = new MainWindow();
                                    mainWindow.Show();
                                    this.Close();
                                    break;
                                default:
                                    MessageBox.Show("Akun tidak tersedia!", "Authtentication Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Username atau password salah.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
             
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM [user] WHERE username=@username AND password=@password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int result = (int)command.ExecuteScalar();
                        isAuthenticated = result > 0;
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return isAuthenticated;
        }

    }
}
