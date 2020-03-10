using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("department", "Department", FieldType.TableName)]
    public class Department
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

        [DataDescription("description", "Description")]
        public string Description { get; set; }

        [DataDescription("supervisor", "Supervisor")]
        public AppUser Supervisor { get; set; }
    }
}