using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RisksManagementService.Database.Models
{
    public interface IDatabaseModel
    {
        int Id { get; set; }

        string CreatedBy { get; set; }

        string ModifiedBy { get; set; }

        DateTime TimeCreated { get; set; }

        DateTime TimeModified { get; set; }
    }
}
