using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RisksManagementService.Database.Models;

namespace RisksManagementService
{
    //[ServiceContract]
    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void AppUserCallback(string result);
    }
}
