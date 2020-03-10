using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("probability", "Probability", FieldType.TableName)]
    public class Probability
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("assessment", "Assessment")]
        public float Assessment { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

        [DataDescription("interval_start", "IntervalStart")]
        public float IntervalStart { get; set; }

        [DataDescription("interval_finish", "IntervalFinish")]
        public float IntervalFinish { get; set; }

        [DataDescription("probability_type", "ProbabilityType")]
        public ProbabilityType ProbabilityType { get; set; }
    }
}