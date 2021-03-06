﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RisksManagementService.Database.Models;

namespace RisksManagementService
{
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void DbModelCallback(IDatabaseModel result);
    }
}
