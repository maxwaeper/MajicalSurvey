using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public interface IRepository<T> : IDisposable 
        where T : class
    {
        IEnumerable<T> GetAllElements();
        void Insert(T entity);
        IQueryable<T> GetCertainElement(Expression<Func<T, bool>> predicate);
        void Delete(Expression<Func<T, bool>> predicate);
        void Save();

    }
}
