using System;
using System.Collections.Generic;
using System.Linq;
using Lab5v3.Exceptions;

namespace Lab5v3.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public bool Remove(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }

        public T Find(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item == null) throw new NotFoundException("Елемент не знайдено.");
            return item;
        }

        public IEnumerable<T> All() => _items.AsReadOnly();

        public IEnumerable<T> Where(Func<T, bool> predicate) => _items.Where(predicate);
    }
}
