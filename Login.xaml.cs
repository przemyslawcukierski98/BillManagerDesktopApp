using BillManagerWPF.Properties;
using BillManagerWPF.Services.Interfaces;
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
using Unity;

namespace BillManagerWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly MainWindow mainWindow;
        private readonly IUsersService usersService;

        public Login()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public Login(MainWindow mainWindow, IUsersService usersService)
        {
            this.usersService = usersService;
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new Users()
            {
                Username = loginRegisterInput.Text.Replace(Environment.NewLine, "").Replace("\n", ""),
                Password = passwordRegisterInput.Text.Replace(Environment.NewLine, "").Replace("\n", "")
            };

            var result = usersService.Register(user);

            if(result == true)
            {
                Settings.Default.Username = user.Username;
                mainWindow.Show();
                Close();
            }
            else
            {
                // TODO
            }

            mainWindow.Show();
            Close();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new Users()
            {
                Username = loginLoginInput.Text.Replace(Environment.NewLine, "").Replace("\n", ""),
                Password = passwordLoginInput.Text.Replace(Environment.NewLine, "").Replace("\n", ""),
            };

            var result = usersService.Login(user);

            if(result == true)
            {
                Settings.Default.Username = user.Username;
                mainWindow.Show();
                Close();
            }
            else
            {
                // TODO
            }
        }
    }
}
