using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("environment", "Environment", FieldType.TableName)]
    public class Environment : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("address", "Address")]
        public string Address { get; set; }

        [DataDescription("system", "System")]
        public string System { get; set; }

        [DataDescription("process", "Process")]
        public string Process { get; set; }

        [DataDescription("level", "Level")]
        public string Level { get; set; }

        [DataDescription("description", "Description")]
        public string Description { get; set; }

        [DataDescription("date", "Date")]
        public DateTime Date { get; set; }

        [DataDescription("risk", "Risk")]
        public Risk Risk { get; set; }

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