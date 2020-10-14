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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace BillManagerWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IInfoService infoService;
        private readonly IBillsService billsService;
        private readonly IUsersService usersService;
        List<Bill> billsList = new List<Bill>();

        [InjectionConstructor]
        public MainWindow(IInfoService infoService, IBillsService billsService, IUsersService usersService)
        {
            this.infoService = infoService;
            this.billsService = billsService;
            this.usersService = usersService;
            InitializeComponent();
            appDataGrid.Visibility = Visibility.Hidden;
            welcomeLabel.Visibility = Visibility.Visible;
            addInfoButton.Visibility = Visibility.Hidden;
            addBill.Visibility = Visibility.Hidden;
            welcomeLabel.FontSize = 20;
            welcomeLabel.FontWeight = FontWeights.Bold;
            welcomeLabel.Content = "Witam w aplikacji Bill Manager, wybierz opcję z menu";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            welcomeLabel.Visibility = Visibility.Visible;
            appDataGrid.Visibility = Visibility.Hidden;
            addInfoButton.Visibility = Visibility.Hidden;
            addBill.Visibility = Visibility.Hidden;
            welcomeLabel.Content = "Witam w aplikacji Bill Manager, wybierz opcję z menu";
        }

        private void billsButton_Click(object sender, RoutedEventArgs e)
        {
            appDataGrid.Visibility = Visibility.Visible;
            addBill.Visibility = Visibility.Visible;
            welcomeLabel.Visibility = Visibility.Hidden;
            addInfoButton.Visibility = Visibility.Hidden;
            billsList = billsService.GetBillsForUser(Settings.Default.Username).ToList();
            appDataGrid.ItemsSource = billsList; 
        }

        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            welcomeLabel.Visibility = Visibility.Visible;
            appDataGrid.Visibility = Visibility.Hidden;
            addInfoButton.Visibility = Visibility.Visible;
            welcomeLabel.Content = infoService.GetInformationStringByUser(Settings.Default.Username);
        }
        private void appDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
