using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("app_user", "AppUser", FieldType.TableName)]
    [DataContract]
    public class AppUser : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        [DataMember]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        [DataMember]
        public string Name { get; set; }

        [DataDescription("login", "Login")]
        [DataMember]
        public string Login { get; set; }

        [DataDescription("role", "Role")]
        [DataMember]
        public Role Role { get; set; }

        [DataDescription("phone", "Phone")]
        [DataMember]
        public string Phone { get; set; }

        [DataDescription("email", "Email")]
        [DataMember]
        public string Email { get; set; }

        [DataDescription("telegram", "Telegram")]
        [DataMember]
        public string Telegram { get; set; }

        [DataDescription("is_admin", "IsAdmin")]
        [DataMember]
        public bool IsAdmin { get; set; }
        
        [DataDescription("created_by", "CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [DataDescription("modified_by", "ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [DataDescription("time_created", "TimeCreated")]
        [DataMember]
        public DateTime TimeCreated { get; set; }

        [DataDescription("time_modified", "TimeModified")]
        [DataMember]
        public DateTime TimeModified { get; set; }

        public OperationContext OperationContext { get; set; }
    }
}