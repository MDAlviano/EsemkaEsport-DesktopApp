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
    /// Interaction logic for CreateAccountForm.xaml
    /// </summary>
    public partial class CreateAccountForm : Window
    {
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
    }
}
