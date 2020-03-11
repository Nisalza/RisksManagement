﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("relevance", "Relevance")]
    public class Relevance : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("assessment", "Assessment")]
        public float Assessment { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

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