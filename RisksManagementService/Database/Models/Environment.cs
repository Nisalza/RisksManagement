using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("environment", "Environment", FieldType.TableName)]
    [DataContract]
    public class Environment : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        [DataMember]
        public int Id { get; set; }

        [DataDescription("address", "Address")]
        [DataMember]
        public string Address { get; set; }

        [DataDescription("system", "System")]
        [DataMember]
        public string System { get; set; }

        [DataDescription("process", "Process")]
        [DataMember]
        public string Process { get; set; }

        [DataDescription("level", "Level")]
        [DataMember]
        public string Level { get; set; }

        [DataDescription("description", "Description")]
        [DataMember]
        public string Description { get; set; }

        [DataDescription("date", "Date")]
        [DataMember]
        public DateTime Date { get; set; }

        [DataDescription("risk", "Risk")]
        [DataMember]
        public Risk Risk { get; set; }

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