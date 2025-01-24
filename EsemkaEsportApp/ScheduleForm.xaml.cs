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
    /// Interaction logic for ScheduleForm.xaml
    /// </summary>
    public partial class ScheduleForm : Window
    {

        private readonly string connectionString = @"Server=ALVIN\ALVINTORIALSQL;Database=EsemkaEsport;Trusted_Connection=True;";

        public class ScheduleData   
        {
            public string Match { get; set; }
            public string Time { get; set; }
            public int ScheduleId { get; set; }
        }

        public ScheduleForm()
        {
            InitializeComponent();
        }

        private void LoadScheduleData()
        {
            try
            {
                List<ScheduleData> schedules = new List<ScheduleData>();

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT s.id, ht.name + ' vs ' + at.name AS Match, FORMAT(s.time, 'dddd, dd MMMM yyyy (HH:mm)') AS FormattedName FROM [schedule] s JOIN [team] ht ON s.home_team_id = ht.id JOIN [team] at ON s.away_team_id = at.id WHERE s.deleted_at IS NULL AND s.time > GETDATE() ORDER BY s.time";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                schedules.Add(new ScheduleData
                                {
                                    ScheduleId = reader.GetInt32(0),
                                    Match = reader.GetString(1),
                                    Time = reader.GetString(2)
                                });
                            }
                        }
                    }
                }
                
                adminScheduleDataGrid.ItemsSource = schedules;
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateNewSchedule_Click(object sender, RoutedEventArgs e)
        {
            var addSchedule = new AddScheduleForm();
            addSchedule.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
