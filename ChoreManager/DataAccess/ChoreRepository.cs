using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChoreManager.Models;
using Dapper;

namespace ChoreManager.DataAccess
{
    public class ChoreRepository : IRepository<Chore>
    {
        private readonly IDbFactory _factory;

        public ChoreRepository(IDbFactory factory)
        {
            _factory = factory;
        }

        public void Add(Chore o)
        {
            var sql = "INSERT INTO Chores (Name, UserName, Points, Done) VALUES (@Name, @UserName, @Points, @Done)";

            using (var con = _factory.GetConnection())
                con.Execute(sql, o);
        }

        public void Delete<TKey>(TKey key)
        {
            var sql = "DELETE FROM Chores WHERE Name=@key";

            using (var con = _factory.GetConnection())
                con.Execute(sql, new { key });
        }

        public Chore Get<TKey>(TKey key)
        {
            var sql = "SELECT * FROM Chores WHERE Name=@key";

            using (var con = _factory.GetConnection())
                return con.QueryFirst<Chore>(sql, new { key });
        }

        public IEnumerable<Chore> GetAll()
        {
            var sql = "SELECT * FROM Chores";

            using (var con = _factory.GetConnection())
                return con.Query<Chore>(sql);
        }

        public void Update<TKey>(TKey key, Chore o)
        {
            var sql = "UPDATE Chores SET UserName=@UserName, Points=@Points, Done=@Done WHERE Name=@Name";

            o.Name = key as string;

            using (var con = _factory.GetConnection())
                con.Execute(sql, o);
        }
    }
}
