using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    interface IRepository<T> : IDisposable 
        where T : class
    {
        List<T> GetAllElements();
        void Insert(T entity);
        IQueryable<T> GetCertainElement(Expression<Func<T, bool>> predicate);
        void Delete();
        void Save();

    }
}
