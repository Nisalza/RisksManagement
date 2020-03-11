using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("risk_trigger", "RiskTrigger", FieldType.TableName)]
    [DataContract]
    public class RiskTrigger : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        [DataMember]
        public int Id { get; set; }

        [DataDescription("risk", "Risk")]
        [DataMember]
        public Risk Risk { get; set; }

        [DataDescription("exposure", "Exposure")]
        [DataMember]
        public float Exposure { get; set; }

        [DataDescription("notification", "Notification")]
        [DataMember]
        public Notification Notification { get; set; }

        [DataDescription("team", "Team")]
        [DataMember]
        public Team Team { get; set; }

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