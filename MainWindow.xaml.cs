using BillManagerWPF.Properties;
using BillManagerWPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
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
        Bill updateBill;
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

        private void appDataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dependencyObject = (DependencyObject)e.OriginalSource;

            while((dependencyObject!=null) && !(dependencyObject is DataGridCell) && !(dependencyObject is DataGridColumnHeader))
            {
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            if(dependencyObject == null)
            {
                return;
            }

            if(dependencyObject is DataGridCell)
            {
                while((dependencyObject!=null) && !(dependencyObject is DataGridRow))
                {
                    dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
                }

                DataGridRow dataGridRow = dependencyObject as DataGridRow;
                dataGridRow.ContextMenu = contextMenu;
            }
        }
        private void appDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contextMenu = new ContextMenu();

            foreach(Bill item in appDataGrid.SelectedItems)
            {
                updateBill = new Bill
                {
                    Id = item.Id,
                    April = item.April,
                    August = item.August,
                    BillName = item.BillName,
                    BillsYear = item.BillsYear,
                    December = item.December,
                    February = item.February,
                    January = item.January,
                    July = item.July,
                    June = item.June,
                    March = item.March,
                    May = item.May,
                    November = item.November,
                    October = item.October,
                    September = item.September
                };
            }

            textId = new TextBlock();
            textId.Text = updateBill.Id.ToString();
            contextMenu.Items.Add(textId);

            nameTextBox = new TextBox();
            nameTextBox.Text = updateBill.BillName.ToString();
            contextMenu.Items.Add("Nazwa");

            januaryTextBox = new TextBox();
            januaryTextBox.Text = updateBill.January.ToString();
            contextMenu.Items.Add("Styczeń");
            contextMenu.Items.Add(januaryTextBox);

            februaryTextBox = new TextBox();
            februaryTextBox.Text = updateBill.February.ToString();
            contextMenu.Items.Add("Luty");
            contextMenu.Items.Add(februaryTextBox);

            marchTextBox = new TextBox();
            marchTextBox.Text = updateBill.March.ToString();
            contextMenu.Items.Add("Marzec");
            contextMenu.Items.Add(marchTextBox);

            aprilTextBox = new TextBox();
            aprilTextBox.Text = updateBill.April.ToString();
            contextMenu.Items.Add("Kwiecień");
            contextMenu.Items.Add(aprilTextBox);

            mayTextBox = new TextBox();
            mayTextBox.Text = updateBill.May.ToString();
            contextMenu.Items.Add("Maj");
            contextMenu.Items.Add(mayTextBox);

            juneTextBox = new TextBox();
            juneTextBox.Text = updateBill.June.ToString();
            contextMenu.Items.Add("Czerwiec");
            contextMenu.Items.Add(juneTextBox);

            julyTextBox = new TextBox();
            julyTextBox.Text = updateBill.July.ToString();
            contextMenu.Items.Add("Lipiec");
            contextMenu.Items.Add(julyTextBox);

            augustTextBox = new TextBox();
            augustTextBox.Text = updateBill.August.ToString();
            contextMenu.Items.Add("Sierpień");
            contextMenu.Items.Add(augustTextBox);

            septemberTextBox = new TextBox();
            septemberTextBox.Text = updateBill.September.ToString();
            contextMenu.Items.Add("Wrzesień");
            contextMenu.Items.Add(septemberTextBox);

            octoberTextBox = new TextBox();
            octoberTextBox.Text = updateBill.October.ToString();
            contextMenu.Items.Add("Październik");
            contextMenu.Items.Add(octoberTextBox);

            novemberTextBox = new TextBox();
            novemberTextBox.Text = updateBill.November.ToString();
            contextMenu.Items.Add("Listopad");
            contextMenu.Items.Add(novemberTextBox);

            decemberTextBox = new TextBox();
            decemberTextBox.Text = updateBill.December.ToString();
            contextMenu.Items.Add("Grudzień");
            contextMenu.Items.Add(decemberTextBox);

            Button buttonSave = new Button();
            buttonSave.Content = "Zapisz";
            contextMenu.Items.Add(buttonSave);
            buttonSave.Click += new RoutedEventHandler(buttonSave_Click);
        }

        void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Bill bill = new Bill();

            foreach(Bill item in billsList)
            {
                if(item.Id == Convert.ToInt32(textId.Text))
                {
                    item.April = Double.Parse(aprilTextBox.Text == "" ? "-" : aprilTextBox.Text);
                    item.August = Double.Parse(augustTextBox.Text == "" ? "-" : augustTextBox.Text);
                    item.BillName = nameTextBox.Text;
                    item.December = Double.Parse(decemberTextBox.Text == "" ? "-" : decemberTextBox.Text);
                    item.February = Double.Parse(februaryTextBox.Text == "" ? "-" : februaryTextBox.Text);
                    item.January = Double.Parse(januaryTextBox.Text == "" ? "-" : januaryTextBox.Text);
                    item.July = Double.Parse(julyTextBox.Text == "" ? "-" : julyTextBox.Text);
                    item.June = Double.Parse(juneTextBox.Text == "" ? "-" : juneTextBox.Text);
                    item.March = Double.Parse(marchTextBox.Text == "" ? "-" : marchTextBox.Text);
                    item.May = Double.Parse(mayTextBox.Text == "" ? "-" : mayTextBox.Text);
                    item.November = Double.Parse(novemberTextBox.Text == "" ? "-" : novemberTextBox.Text);
                    item.October = Double.Parse(octoberTextBox.Text == "" ? "-" : octoberTextBox.Text);
                    item.September = Double.Parse(septemberTextBox.Text == "" ? "-" : septemberTextBox.Text);

                    billsService.Edit(item);
                }
            }

            appDataGrid.SelectionChanged -= new SelectionChangedEventHandler(appDataGrid_SelectionChanged);
            appDataGrid.ItemsSource = null;
            appDataGrid.ItemsSource = billsList;
            appDataGrid.SelectedIndex = -1;

            contextMenu.IsOpen = false;
            appDataGrid.SelectionChanged += new SelectionChangedEventHandler(appDataGrid_SelectionChanged);
        }
    }
}
