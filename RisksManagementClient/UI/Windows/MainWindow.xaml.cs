using System;
using System.Windows;
using RisksManagementClient.ServiceRisksManagement;
using RisksManagementClient.ViewModels;

namespace RisksManagementClient.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            ServiceClient client = SingletonClient.GetInstance().Client;
            client?.Disconnect();
        }
    }
}
