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
    /// Interaction logic for TeamForm.xaml
    /// </summary>
    public partial class TeamForm : Window
    {

        private readonly string connectionString = @"Server=ALVIN\ALVINTORIALSQL;Database=EsemkaEsport;Trusted_Connection=True;";

        public TeamForm()
        {
            InitializeComponent();
            LoadTeamData();
        }

        private void LoadTeamData()
        {
            string query = @"SELECT TOP (1000) [id]
      ,[team_name]
      ,[company_name]
      ,[created_at]
      ,[updated_at]
      ,[deleted_at]
  FROM [EsemkaEsport].[dbo].[team]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        teamDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainAdmin = new ScheduleForm();
            mainAdmin.Show();
            this.Close();
        }
    }
}
