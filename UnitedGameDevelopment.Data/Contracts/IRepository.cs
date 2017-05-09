namespace UnitedGameDevelopment.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        bool Any(Expression<Func<T, bool>> expression);
        int Count();
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        IEnumerable<T> Entities { get; }
        T Find(int id);
        T Find(string id);
        void Remove(int bindId);
        void Remove(T entity);
    }
}