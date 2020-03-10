using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("risk_management_plan", "RiskManagementPlan", FieldType.TableName)]
    public class RiskManagementPlan
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("mitigation_strategy", "MitigationStrategy")]
        public Strategy MitigationStrategy { get; set; }

        [DataDescription("contingency_strategy", "ContingencyStrategy")]
        public Strategy ContingencyStrategy { get; set; }
    }
}