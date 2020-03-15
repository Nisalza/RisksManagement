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
using RisksManagementService.Database.Models;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для RiskFullInfoView.xaml
    /// </summary>
    public partial class RiskFullInfoView : UserControl
    {
        private Risk _risk;

        public RiskFullInfoView(Risk risk)
        {
            InitializeComponent();
            _risk = risk;
        }
    }
}
