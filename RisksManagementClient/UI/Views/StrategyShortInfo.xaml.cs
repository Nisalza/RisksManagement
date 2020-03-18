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
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для StrategyShortInfo.xaml
    /// </summary>
    public partial class StrategyShortInfo : UserControl
    {
        private readonly Strategy _strategy;

        public StrategyShortInfo(Strategy strategy)
        {
            InitializeComponent();
            _strategy = strategy;
        }

        private void StrategyFullInfo_OnLoaded(object sender, RoutedEventArgs e)
        {
            StrategyDescription.Text = _strategy.Description;
            StrategyType.Text = _strategy.StrategyType.Name;
        }
    }
}
