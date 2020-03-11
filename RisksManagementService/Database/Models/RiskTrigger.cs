using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("risk_trigger", "RiskTrigger", FieldType.TableName)]
    public class RiskTrigger : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("risk", "Risk")]
        public Risk Risk { get; set; }

        [DataDescription("exposure", "Exposure")]
        public float Exposure { get; set; }

        [DataDescription("notification", "Notification")]
        public Notification Notification { get; set; }

        [DataDescription("team", "Team")]
        public Team Team { get; set; }

        [DataDescription("created_by", "CreatedBy")]
        public string CreatedBy { get; set; }

        [DataDescription("modified_by", "ModifiedBy")]
        public string ModifiedBy { get; set; }

        [DataDescription("time_created", "TimeCreated")]
        public DateTime TimeCreated { get; set; }

        [DataDescription("time_modified", "TimeModified")]
        public DateTime TimeModified { get; set; }
    }
}