using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RisksManagementService.Attributes
{
    public class AttributesSupport
    {
        public string DataDescriptionDatabaseTable(Type t)
        {
            var attribute = t.GetCustomAttribute(typeof(DataDescriptionAttribute));
            string name = (attribute as DataDescriptionAttribute)?.DatabaseName;
            return name;
        }

        public string DataDescriptionDatabaseColumn(Type t, string field)
        {
            var attribute  = t.GetProperty(field)?.GetCustomAttribute(typeof(DataDescriptionAttribute));
            string name = (attribute as DataDescriptionAttribute)?.DatabaseName;
            return name;
        }
    }
}