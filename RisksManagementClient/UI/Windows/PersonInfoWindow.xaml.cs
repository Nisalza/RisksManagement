using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RisksManagementClient.ServiceRisksManagement;
using RisksManagementClient.UI.Views;

namespace RisksManagementClient.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public PersonInfoWindow(AppUser currentUser, string name)
        {
            InitializeComponent();
            Title = name;
            PersonInfoView view = new PersonInfoView
            {
                DataContext = this,
                UserName = {Text = currentUser.Name},
                UserPhone = {Text = currentUser.Phone},
                UserEmail = {Text = currentUser.Email},
                UserTelegram = {Text = currentUser.Telegram}
            };
            MainGrid.Children.Add(view);
        }
    }
}
