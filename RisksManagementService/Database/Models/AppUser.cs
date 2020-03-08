using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RisksManagementService.Database.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public Role Role { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public SqlConnection Connection { get; set; }
    }
}