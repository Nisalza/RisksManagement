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
using Prism.Services.Dialogs;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для StrategyFullInfo.xaml
    /// </summary>
    public partial class StrategyFullInfo : UserControl
    {
        public Strategy Strategy { get; set; }

        public StrategyFullInfo()
        {
            InitializeComponent();
        }

        private void SaveStrategy_Click(object sender, RoutedEventArgs e)
        {
            Strategy.StrategyType = StrategyTypes.SelectedItem as StrategyType;
            Strategy.Description = StrategyDescription.Text;
            var window = Window.GetWindow(this);
            window.DialogResult = true;
            window.Close();
        }

        private void StrategyFullInfo_OnLoaded(object sender, RoutedEventArgs e)
        {
            StrategyDescription.Text = Strategy.Description;
            var items = StrategyTypes.Items;
            int index = -1;
            for (int i = 0; i < items.Count; ++i)
            {
                if (((StrategyType)items[i]).Id == Strategy.StrategyType.Id)
                {
                    index = i;
                    break;
                }
            }

            StrategyTypes.SelectedIndex = index;
        }
    }
}
