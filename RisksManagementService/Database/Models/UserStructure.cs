using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("user_structure", "UserStructure", FieldType.TableName)]
    public class UserStructure
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("app_user", "AppUser")]
        public AppUser AppUser { get; set; }

        [DataDescription("project", "Project")]
        public Project Project { get; set; }

        [DataDescription("department", "Department")]
        public Department Department { get; set; }
    }
}