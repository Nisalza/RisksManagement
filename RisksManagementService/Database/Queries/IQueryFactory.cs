using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RisksManagementService.Database.Queries
{
    public interface IQueryFactory
    {
        IQuery Select();

        IQuery Update();

        IQuery Insert();

        IQuery Delete();

        IQuery Create();

        IQuery Alter();

        IQuery Drop();
    }
}