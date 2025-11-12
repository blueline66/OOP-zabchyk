using System;
using System.Collections.Generic;

namespace Lab5v3.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        bool Remove(Func<T, bool> predicate);
        T Find(Func<T, bool> predicate);
        IEnumerable<T> All();
        IEnumerable<T> Where(Func<T, bool> predicate);
    }
}
