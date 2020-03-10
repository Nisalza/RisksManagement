using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("classification", "Classification", FieldType.TableName)]
    public class Classification
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

        [DataDescription("description", "Description")]
        public string Description { get; set; }

        [DataDescription("superclass", "Superclass")]
        public Classification Superclass { get; set; }
    }
}