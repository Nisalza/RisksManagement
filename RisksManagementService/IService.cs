using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RisksManagementService
{
    [ServiceContract(CallbackContract = typeof(IServerCallback))]
    public interface IService
    {

        [OperationContract]
        void Connect(string login);

        [OperationContract]
        void Disconnect();
    }
}
