using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RisksManagementService.Database.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }

        public string Subcategory { get; set; }

        //todo придумать структуру
        public object Body { get; set; }
    }
}