using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aalee.Test.Dapper.PostgreSQL.Contracts.Repository
{
    public interface IDbSet<TEntity> where TEntity : class
    {
        Task<int> Exec(string command, object parameters = null);
        Task<List<TEntity>> GetList(string command, object parameters);
        Task<TEntity> Get(string command, object parameters);
    }
}
