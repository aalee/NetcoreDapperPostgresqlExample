using aalee.Test.Dapper.PostgreSQL.Contracts.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace aalee.Test.Dapper.PostgreSQL.Repository
{
    public class DapperDbSet<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        protected IDbConnection Connection;
        public DapperDbSet(IDbConnection connection)
        {
            Connection = connection;
        }

        public Task<int> Exec(string command, object parameters)
        {
            try
            {
                //var parameters = new DynamicParameters();
                return Task.FromResult(SqlMapper.Execute(Connection, command, param: parameters, commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TEntity>> GetList(string command, object parameters)
        {
            return Task.FromResult(SqlMapper.Query<TEntity>(Connection, command, param: parameters, commandType: CommandType.StoredProcedure).ToList());
        }
        public Task<TEntity> Get(string command, object parameters)
        {
            return Task.FromResult(SqlMapper.Query<TEntity>(Connection, command, param: parameters, commandType: CommandType.Text).FirstOrDefault());
        }
    }
}
