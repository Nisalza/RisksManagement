using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RisksManagementService.Database.SqlGenerators
{
    public class SqlGetData
    {
        public string GetNullableString(IDataReader reader, int colIndex)
        {
            if (reader.IsDBNull(colIndex)) return string.Empty;
            return reader.GetString(colIndex);
        }
    }
}