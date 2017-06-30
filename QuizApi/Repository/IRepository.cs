using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApi.Repository
{
    public interface IRepository<T>
    {
        bool Insert(T item);
        bool Delete(T item);
        List<T> Get(Func<T, bool> query);
    }
}
