using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("app_user", "AppUser", FieldType.TableName)]
    public class AppUser : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

        [DataDescription("login", "Login")]
        public string Login { get; set; }

        [DataDescription("role", "Role")]
        public Role Role { get; set; }

        [DataDescription("email", "Email")]
        public string Email { get; set; }

        [DataDescription("is_admin", "IsAdmin")]
        public bool IsAdmin { get; set; }
        
        [DataDescription("created_by", "CreatedBy")]
        public string CreatedBy { get; set; }

        [DataDescription("modified_by", "ModifiedBy")]
        public string ModifiedBy { get; set; }

        [DataDescription("time_created", "TimeCreated")]
        public DateTime TimeCreated { get; set; }

        [DataDescription("time_modified", "TimeModified")]
        public DateTime TimeModified { get; set; }

        public OperationContext OperationContext { get; set; }
    }
}