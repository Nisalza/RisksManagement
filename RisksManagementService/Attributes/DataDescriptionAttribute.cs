using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RisksManagementService.Attributes
{
    public class DataDescriptionAttribute : Attribute
    {
        public string DatabaseName { get; set; }

        public string FieldName { get; set; }

        public FieldType FieldType { get; set; }

        public DataDescriptionAttribute(string dbName, string fName, FieldType ft = FieldType.ColumnName)
        {
            DatabaseName = dbName;
            FieldName = fName;
            FieldType = ft;
        }
    }

    public enum FieldType : byte
    {
        TableName,
        ColumnName
    }
}