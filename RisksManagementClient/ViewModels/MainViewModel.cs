using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using RisksManagementClient.ServiceRisksManagement;
using RisksManagementService;
using RisksManagementService.Database.Models;

namespace RisksManagementClient.ViewModels
{
    public class MainViewModel : BindableBase, IServerCallback
    {
        public ServiceClient Client;

        public EventHandler ViewLoaded;

        public MainViewModel()
        {
            ViewLoaded += OnViewLoaded;
            Client = new ServiceClient(new InstanceContext(this));
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            //todo Нормальный логин
            Client.Connect("ALZA/Dashi");
        }

        public void AppUserCallback(AppUser result)
        {
            MessageBox.Show(result.Name);
        }
    }
}
