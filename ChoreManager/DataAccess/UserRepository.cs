using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChoreManager.Models;
using Dapper;

namespace ChoreManager.DataAccess
{
    public class UserRepository : IRepository<User>
    {
        private readonly IDbFactory _factory;

        public UserRepository(IDbFactory factory)
        {
            _factory = factory;
        }

        public void Add(User o)
        {
            //this should be constant or resource in production code instead of hard coded :)
            var sql = "INSERT INTO Users (Name, Score) VALUES (@Name, @Score)";

            using (var con = _factory.GetConnection())
                con.Execute(sql, o);
                  
        }

        public void Delete<TKey>(TKey key)
        {
            var sql = "DELETE FROM Users WHERE Name=@key";

            using (var con = _factory.GetConnection())
                con.Execute(sql, new { key });
        }

        public User Get<TKey>(TKey key)
        {
            var sqljoin = "SELECT * FROM Users INNER JOIN Chores ON Users.Name=Chores.UserName WHERE Users.Name = @key";
            var sql = "SELECT * FROM Users WHERE Users.Name = @key";

            User user = null;

            using (var con = _factory.GetConnection())
            {
                var queryResults = con.Query<User, Chore, User>(
                    sql: sqljoin,
                    map: (u, c) =>
                    {
                        if (user == null)
                            user = u;
                        user.Chores.Add(c);
                        return user;
                    },
                    param: new { key },
                    splitOn: "Name"
                    );

                //there are no rows returned if the User has no chores
                if (queryResults.Count() > 1)
                    return queryResults.First();
                else
                    return con.QueryFirst<User>(sql, new { key });
            }
        }

        public IEnumerable<User> GetAll()
        {
            var sql = "SELECT * FROM Users";

            using (var con = _factory.GetConnection())
                return con.Query<User>(sql);
        }

        public void Update<TKey>(TKey key, User o)
        {
            var sql = "UPDATE Users SET Score=@Score WHERE Name=@Name";

            o.Name = key as string;

            using (var con = _factory.GetConnection())
                con.Execute(sql,o);
        }
    }
}
