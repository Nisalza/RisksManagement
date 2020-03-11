using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using RisksManagementClient;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.ViewModels
{
    public class MainViewModel : BindableBase, IServiceCallback
    {
        public ServiceClient Client;

        public EventHandler ViewLoaded;

        public MainViewModel()
        {
            ViewLoaded += OnViewLoaded;
            Client = new ServiceClient(new InstanceContext(this));
            //IServiceCallback
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            //todo Нормальный логин
            AppUser user = Client.Connect("ALZA/Dashi");
            MessageBox.Show(user.Name);
        }

        public void AppUserCallback(AppUser result)
        {
            //MessageBox.Show(result.Name);
        }
    }
}
