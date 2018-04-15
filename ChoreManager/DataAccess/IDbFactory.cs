using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ChoreManager.DataAccess
{
    /// <summary>
    ///     A DbFactory provides a connection to a relational database such as SQL Server, MySQL or SQLite
    /// </summary>
    public interface IDbFactory
    {
        /// <summary>
        ///     get connection
        /// </summary>
        /// <returns>connection</returns>
        IDbConnection GetConnection();
    }
}
