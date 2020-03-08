using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RisksManagementService.Database.Models
{
    public class RolePattern
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Settings Settings { get; set; }
    }
}