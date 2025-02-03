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

namespace EsemkaEsportApp
{
    /// <summary>
    /// Interaction logic for TransferPlayerForm.xaml
    /// </summary>
    public partial class TransferPlayerForm : Window
    {
        public TransferPlayerForm()
        {
            InitializeComponent();
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainAdmin = new ScheduleForm();
            mainAdmin.Show();
            this.Close();
        }

        public void Left_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("left button click");
        }

        public void Right_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("right button click");
        }
    }
}
