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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

using System.Data;

namespace EsemkaEsportApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly string connectionString = @"Server=ALVIN\ALVINTORIALSQL;Database=EsemkaEsport;Trusted_Connection=True;";

        public class ScheduleData
        {
            public string Match { get; set; }
            public string Time { get; set; }
            public int ScheduleId { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            string query = @"SELECT TOP (1000) [id]
      ,[home_team_id]
      ,[away_team_id]
      ,[time]
      ,[created_at]
      ,[updated_at]
      ,[deleted_at]
  FROM [EsemkaEsport].[dbo].[schedule]";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        scheduleDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
        }

  //      private void LoadScheduleData()
  //      {
  //          try
  //          {
  //              List<ScheduleData> schedules = new List<ScheduleData>();

  //              using (SqlConnection connection = new SqlConnection(connectionString))
  //              {
  //                  connection.Open();

  //                  string query = @"SELECT TOP (1000) [id]
  //    ,[home_team_id]
  //    ,[away_team_id]
  //    ,[time]
  //    ,[created_at]
  //    ,[updated_at]
  //    ,[deleted_at]
  //FROM [EsemkaEsport].[dbo].[schedule]";

  //                  using (SqlCommand command = new SqlCommand(query,connection))
  //                  {
  //                      using (SqlDataReader reader = command.ExecuteReader())
  //                      {
  //                          while (reader.Read())
  //                          {
  //                              schedules.Add(new ScheduleData
  //                              {
  //                                  ScheduleId = reader.GetInt32(0),
  //                                  Match = reader.GetString(1),
  //                                  Time = reader.GetString(2)
  //                              });
  //                          }
  //                      }
  //                  }
  //              }

  //              Console.WriteLine(schedules);

  //              scheduleDataGrid.ItemsSource = schedules;
  //          } catch (Exception ex)
  //          {
  //              MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
  //          }
  //      }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked!", "Test", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MyTickets_Click(object sender, RoutedEventArgs e)
        {
            var myTicketsForm = new MyTicketForm();
            myTicketsForm.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
