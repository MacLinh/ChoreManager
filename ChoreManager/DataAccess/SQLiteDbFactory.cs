using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ChoreManager.DataAccess
{
    public class SQLiteDbFactory : IDbFactory
    {

        private readonly string _connectionString;

        public SQLiteDbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        ///     Get a new SQLite conenction
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConnection()
        {
            //CheckExists();
            return new SQLiteConnection(_connectionString);
        }
    }
}
