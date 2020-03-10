using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("impact_type", "ImpactType", FieldType.TableName)]
    public class ImpactType
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }
    }
}