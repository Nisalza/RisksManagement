using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.Comparators
{
    public class AppUserComparer : IEqualityComparer<AppUser>
    {
        public bool Equals(AppUser x, AppUser y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode(AppUser obj)
        {
            return obj.Id;
        }
    }
}
