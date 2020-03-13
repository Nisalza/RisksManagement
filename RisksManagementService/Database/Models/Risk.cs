using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("risk", "Risk", FieldType.TableName)]
    [DataContract]
    public class Risk : IDatabaseModel
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

        [DataDescription("probability", "Probability")]
        [DataMember]
        public Probability Probability { get; set; }

        [DataDescription("impact", "Impact")]
        [DataMember]
        public Impact Impact { get; set; }

        [DataDescription("priority", "Priority")]
        [DataMember]
        public  Priority Priority { get; set; }

        [DataDescription("responsible_person", "ResponsiblePerson")]
        [DataMember]
        public AppUser ResponsiblePerson { get; set; }

        [DataDescription("risk_management_plan", "RiskManagementPlan")]
        [DataMember]
        public RiskManagementPlan RiskManagementPlan { get; set; }

        [DataDescription("is_relevance", "IsRelevance")]
        [DataMember]
        public Relevance IsRelevance { get; set; }

        [DataDescription("risk_cause", "RiskCause")]
        [DataMember]
        public RiskCause RiskCause { get; set; }

        [DataDescription("damage", "Damage")]
        [DataMember]
        public string Damage { get; set; }

        [DataDescription("project", "Project")]
        [DataMember]
        public Project Project { get; set; }

        [DataDescription("deadline", "Deadline")]
        [DataMember]
        public string Deadline { get; set; }

        [DataDescription("classification", "Classification")]
        [DataMember]
        public Classification Classification { get; set; }

        [DataDescription("exposure_computation", "ExposureComputation")]
        [DataMember]
        public ExposureComputation ExposureComputation { get; set; }

        [DataDescription("environment", "Environment")]
        [DataMember]
        public Environment Environment { get; set; }

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