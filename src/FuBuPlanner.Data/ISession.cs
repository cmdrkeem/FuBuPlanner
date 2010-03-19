using System;
using System.Linq;
using System.Linq.Expressions;

namespace FuBuPlanner.Data
{
    public interface ISession
    {
        void Commit();
        void Rollback();

        void Save<T>(T item);

        IQueryable<T> All<T>();

        void Delete<T>(T item);
        void Delete<T>(Expression<Func<T, bool>> expression);
    }
}