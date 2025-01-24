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
    /// Interaction logic for MyTicketForm.xaml
    /// </summary>
    public partial class MyTicketForm : Window
    {

        private readonly string connectionString = @"Server=ALVIN\ALVINTORIALSQL;Database=EsemkaEsport;Trusted_Connection=True;";

        public MyTicketForm()
        {
            InitializeComponent();
        }

        public class ScheduleDataDetail
        {
            public string ScheduleId { get; set; }
            public string UserId { get; set; }
            public string TotalTicket { get; set; }
            public string ScheduleDetailId { get; set; }
        }

        private void LoadScheduleDetailData()
        {
            try
            {
                List<ScheduleDataDetail> scheduleDatas = new List<ScheduleDataDetail>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scheduleDatas.Add(new ScheduleDataDetail
                                {

                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
