using BillManagerWPF.Properties;
using BillManagerWPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        ContextMenu contextMenu = null;
        TextBox januaryTextBox, februaryTextBox, marchTextBox, aprilTextBox, mayTextBox,
                juneTextBox, julyTextBox, augustTextBox, septemberTextBox, octoberTextBox, novemberTextBox, decemberTextBox, nameTextBox;
        TextBlock textId;

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
            contextMenu = new ContextMenu();

            var bill = new Bill();
            textId = new TextBlock();
            textId.Text = bill.Id.ToString();
            contextMenu.Items.Add(textId);

            nameTextBox = new TextBox();
            nameTextBox.Text = "Nazwa";
            contextMenu.Items.Add("Nazwa");
            contextMenu.Items.Add(nameTextBox);

            januaryTextBox = new TextBox();
            januaryTextBox.Text = "000";
            contextMenu.Items.Add("Styczeń");
            contextMenu.Items.Add(januaryTextBox);

            februaryTextBox = new TextBox();
            februaryTextBox.Text = "000";
            contextMenu.Items.Add("Luty");
            contextMenu.Items.Add(februaryTextBox);

            marchTextBox = new TextBox();
            marchTextBox.Text = "000";
            contextMenu.Items.Add("Marzec");
            contextMenu.Items.Add(marchTextBox);

            aprilTextBox = new TextBox();
            aprilTextBox.Text = "000";
            contextMenu.Items.Add("Kwiecień");
            contextMenu.Items.Add(aprilTextBox);

            mayTextBox = new TextBox();
            mayTextBox.Text = "000";
            contextMenu.Items.Add("Maj");
            contextMenu.Items.Add(mayTextBox);

            juneTextBox = new TextBox();
            juneTextBox.Text = "000";
            contextMenu.Items.Add("Czerwiec");
            contextMenu.Items.Add(juneTextBox);

            julyTextBox = new TextBox();
            julyTextBox.Text = "000";
            contextMenu.Items.Add("Lipiec");
            contextMenu.Items.Add(julyTextBox);

            augustTextBox = new TextBox();
            augustTextBox.Text = "000";
            contextMenu.Items.Add("Sierpień");
            contextMenu.Items.Add(augustTextBox);

            septemberTextBox = new TextBox();
            septemberTextBox.Text = "000";
            contextMenu.Items.Add("Wrzesień");
            contextMenu.Items.Add(septemberTextBox);

            octoberTextBox = new TextBox();
            octoberTextBox.Text = "000";
            contextMenu.Items.Add("Październik");
            contextMenu.Items.Add(octoberTextBox);

            novemberTextBox = new TextBox();
            novemberTextBox.Text = "000";
            contextMenu.Items.Add("Listopad");
            contextMenu.Items.Add(novemberTextBox);

            decemberTextBox = new TextBox();
            decemberTextBox.Text = "000";
            contextMenu.Items.Add("Grudzień");
            contextMenu.Items.Add(decemberTextBox);

            Button buttonSaveNewBill = new Button();
            buttonSaveNewBill.Content = "Zapisz";
            contextMenu.Items.Add(buttonSaveNewBill);
            contextMenu.IsOpen = true;
            buttonSaveNewBill.Click += new RoutedEventHandler(buttonSaveNewBill_Click);
        }

        void buttonSaveNewBill_Click(object sender, RoutedEventArgs e)
        {
            var april = Double.Parse(aprilTextBox.Text);

            Bill bill = new Bill()
            {
                April = Double.Parse(aprilTextBox.Text),
                August = Double.Parse(augustTextBox.Text),
                BillName = nameTextBox.Text,
                December = Double.Parse(decemberTextBox.Text),
                February = Double.Parse(februaryTextBox.Text),
                January = Double.Parse(januaryTextBox.Text),
                July = Double.Parse(julyTextBox.Text),
                June = Double.Parse(juneTextBox.Text),
                March = Double.Parse(marchTextBox.Text),
                May = Double.Parse(mayTextBox.Text),
                November = Double.Parse(novemberTextBox.Text),
                October = Double.Parse(octoberTextBox.Text),
                September = Double.Parse(septemberTextBox.Text),
                UserId = usersService.GetUserIdByName(Settings.Default.Username)
            };
            billsService.Add(bill);
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
