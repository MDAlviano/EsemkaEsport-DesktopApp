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

namespace EsemkaEsportApp
{
    /// <summary>
    /// Interaction logic for CreateAccountForm.xaml
    /// </summary>
    public partial class CreateAccountForm : Window
    {

        private readonly string connectionString = @"Server=ALVIN\ALVINTORIALSQL;Database=EsemkaEsport;Trusted_Connection=True";

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void ToLoginForm_Click(object sender, RoutedEventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // validate inputs
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();
            string retypePassword = tbRetypePassword.Text.Trim();
            DateTime? birthdate = dpBirthdate.SelectedDate;
            bool? isMale = rbMale.IsChecked;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(retypePassword))
            {
                MessageBox.Show("Please fill all fields!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != retypePassword)
            {
                MessageBox.Show("Password isn't match!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!birthdate.HasValue)
            {
                MessageBox.Show("Please select a birthdate!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!isMale.HasValue)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool gender = isMale.Value;

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO [user] (username, password, birthdate, gender, role) VALUES (@username, @password, @birthdate, @gender, @role)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@birthdate", birthdate);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@role", 1);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Account created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ClearForm();

                var loginForm = new LoginForm();
                loginForm.Show();
                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ClearForm()
        {
            tbUsername.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbRetypePassword.Text = string.Empty;
            dpBirthdate.SelectedDate = null;
            rbMale.IsChecked = null;
            rbFemale.IsChecked = null;
        }

    }
}
