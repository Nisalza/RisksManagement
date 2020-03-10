using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("risk", "Risk", FieldType.TableName)]
    public class Risk
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

        [DataDescription("description", "Description")]
        public string Description { get; set; }

        [DataDescription("probability", "Probability")]
        public Probability Probability { get; set; }

        [DataDescription("impact", "Impact")]
        public Impact Impact { get; set; }

        [DataDescription("priority", "Priority")]
        public  Priority Priority { get; set; }

        [DataDescription("responsible_person", "ResponsiblePerson")]
        public AppUser ResponsiblePerson { get; set; }

        [DataDescription("risk_management_plan", "RiskManagementPlan")]
        public RiskManagementPlan RiskManagementPlan { get; set; }

        [DataDescription("is_relevance", "IsRelevance")]
        public Relevance IsRelevance { get; set; }

        [DataDescription("damage", "Damage")]
        public string Damage { get; set; }

        [DataDescription("risk_cause", "RiskCause")]
        public RiskCause RiskCause { get; set; }

        [DataDescription("project", "Project")]
        public Project Project { get; set; }

        [DataDescription("deadline", "Deadline")]
        public string Deadline { get; set; }

        [DataDescription("exposure_computation", "ExposureComputation")]
        public ExposureComputation ExposureComputation { get; set; }
    }
}