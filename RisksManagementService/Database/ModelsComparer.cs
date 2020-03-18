using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Database.Models;

namespace RisksManagementService.Database
{
    public class ModelsComparer : IEqualityComparer<IDatabaseModel>
    {
        public bool Equals(IDatabaseModel x, IDatabaseModel y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode(IDatabaseModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}