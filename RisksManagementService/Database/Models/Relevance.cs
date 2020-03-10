using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("relevance", "Relevance")]
    public class Relevance
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("assessment", "Assessment")]
        public float Assessment { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }
    }
}