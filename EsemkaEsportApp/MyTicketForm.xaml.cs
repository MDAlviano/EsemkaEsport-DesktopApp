using System;
using System.Collections.Generic;
using System.Data;
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
            LoadScheduleDetailData();
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
            string query = @"SELECT TOP (1000) [id]
      ,[schedule_id]
      ,[user_id]
      ,[total_ticket]
      ,[created_at]
      ,[updated_at]
      ,[deleted_at]
  FROM [EsemkaEsport].[dbo].[schedule_detail]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        scheduleDetailDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
        }

        //private void LoadScheduleDetailData()
        //{
        //    try
        //    {
        //        List<ScheduleDataDetail> scheduleDatas = new List<ScheduleDataDetail>();

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            string query = @"";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        scheduleDatas.Add(new ScheduleDataDetail
        //                        {

        //                        });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}");
        //    }
        //}
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
