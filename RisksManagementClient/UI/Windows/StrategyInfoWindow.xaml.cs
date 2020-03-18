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
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для StrategyInfoWindow.xaml
    /// </summary>
    public partial class StrategyInfoWindow : Window
    {
        public StrategyInfoWindow(Strategy strategy, StrategyType[] strategyTypes)
        {
            InitializeComponent();
            StrategyFullInfo.Strategy = strategy;
            StrategyFullInfo.StrategyTypes.ItemsSource = strategyTypes;

        }
    }
}
