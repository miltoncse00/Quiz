using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApi.Repository
{
    public class RepositoryT<T> : IRepository<T>
    {
        public static List<T> items = new List<T>();
        public bool Delete(T item)
        {
            items.Remove(item);
            return true;
        }

        public List<T> Get(Func<T, bool> query)
        {
            if (query != null)
                return items.Where(query).ToList();
            return items;
        }

        public bool Insert(T item)
        {
            items.Add(item);
            return true;
        }
    }
}
