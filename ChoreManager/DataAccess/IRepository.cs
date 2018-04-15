using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreManager.DataAccess
{
    public interface IRepository<TObject>
    {
        IEnumerable<TObject> GetAll();

        TObject Get<TKey>(TKey key);

        void Delete<TKey>(TKey key);

        void Update<TKey>(TKey key, TObject o);

        void Add(TObject o);
    }
}
