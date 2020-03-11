using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("risk_management_plan", "RiskManagementPlan", FieldType.TableName)]
    [DataContract]
    public class RiskManagementPlan : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        [DataMember]
        public int Id { get; set; }

        [DataDescription("mitigation_strategy", "MitigationStrategy")]
        [DataMember]
        public Strategy MitigationStrategy { get; set; }

        [DataDescription("contingency_strategy", "ContingencyStrategy")]
        [DataMember]
        public Strategy ContingencyStrategy { get; set; }

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