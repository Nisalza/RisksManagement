using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("exposure_computation", "ExposureComputation", FieldType.TableName)]
    public class ExposureComputation : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        //todo Интерпретатор
        [DataDescription("formula", "Formula")]
        public object Formula { get; set; }

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