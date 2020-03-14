﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RisksManagementService.Database.Models;

namespace RisksManagementService
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {

        [OperationContract]
        AppUser Connect(string login);

        [OperationContract]
        AppUser GetAppUser(int id);

        [OperationContract]
        Department[] GetUserDepartments();

        [OperationContract]
        Project[] GetUserProjects();

        [OperationContract]
        bool UpdateUser(AppUser user);

        [OperationContract]
        void Disconnect();
    }
}
