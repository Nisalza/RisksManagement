using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("project", "Project", FieldType.TableName)]
    [DataContract]
    public class Project : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        [DataMember]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        [DataMember]
        public string Name { get; set; }

        [DataDescription("description", "Description")]
        [DataMember]
        public string Description { get; set; }

        [DataDescription("supervisor", "Supervisor")]
        [DataMember]
        public AppUser Supervisor { get; set; }

        [DataDescription("department", "Department")]
        [DataMember]
        public Department Department { get; set; }

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
    }
}