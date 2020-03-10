using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("exposure_computation", "ExposureComputation", FieldType.TableName)]
    public class ExposureComputation
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        //todo Интерпретатор
        [DataDescription("formula", "Formula")]
        public object Formula { get; set; }
    }
}