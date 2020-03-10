using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("settings", "Settings", FieldType.TableName)]
    public class Settings
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

        [DataDescription("category", "Category")]
        public string Category { get; set; }

        [DataDescription("subcategory", "Subcategory")]
        public string Subcategory { get; set; }

        //todo придумать структуру
        [DataDescription("body", "Body")]
        public object Body { get; set; }
    }
}