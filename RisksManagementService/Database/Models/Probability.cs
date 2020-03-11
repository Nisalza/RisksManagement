﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("probability", "Probability", FieldType.TableName)]
    [DataContract]
    public class Probability : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        [DataMember]
        public int Id { get; set; }

        [DataDescription("assessment", "Assessment")]
        [DataMember]
        public float Assessment { get; set; }

        [DataDescription("name", "Name")]
        [DataMember]
        public string Name { get; set; }

        [DataDescription("interval_start", "IntervalStart")]
        [DataMember]
        public float IntervalStart { get; set; }

        [DataDescription("interval_finish", "IntervalFinish")]
        [DataMember]
        public float IntervalFinish { get; set; }

        [DataDescription("probability_type", "ProbabilityType")]
        [DataMember]
        public ProbabilityType ProbabilityType { get; set; }

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