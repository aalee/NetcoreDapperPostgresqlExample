using aalee.Test.Dapper.PostgreSQL.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace aalee.Test.Dapper.PostgreSQL.Repository
{
    public class AdminAlee : IAdminAlee
    {
        public IDbSet<string> DbSet { get; set; }

        public AdminAlee(IDbConnection connection)
        {
            DbSet = new DapperDbSet<string>(connection);
        }

        public string getDate() {
            return DbSet.Get("select now()", null).Result.ToString();
        }
    }

   
}
