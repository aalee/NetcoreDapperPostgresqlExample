using System;
using System.Collections.Generic;
using System.Text;

namespace aalee.Test.Dapper.PostgreSQL.Contracts.Repository
{
    public interface IAdminAlee
    {
        IDbSet<string> DbSet { get; set; }

        string getDate();

    }
}
