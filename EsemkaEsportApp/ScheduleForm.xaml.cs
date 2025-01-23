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
    /// Interaction logic for ScheduleForm.xaml
    /// </summary>
    public partial class ScheduleForm : Window
    {
        public ScheduleForm()
        {
            InitializeComponent();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked!", "Test", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
