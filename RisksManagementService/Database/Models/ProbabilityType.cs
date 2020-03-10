using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("probability_type", "ProbabilityType", FieldType.TableName)]
    public class ProbabilityType
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }
    }
}