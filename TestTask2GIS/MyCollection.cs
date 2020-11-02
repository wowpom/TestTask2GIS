using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2GIS
{
    class MyCollection<TId, TName, T>
    {
        private int _count;
        private readonly Dictionary<TId, Dictionary<TName, T>> _dicById;
        private readonly Dictionary<TName, Dictionary<TId, T>> _dicByName;

        public MyCollection()
        {
            _dicById = new Dictionary<TId, Dictionary<TName, T>>();
            _dicByName = new Dictionary<TName, Dictionary<TId, T>>();
        }

        /// <summary>
        /// Добавить элемент
        /// </summary>

        public void Add(TId id, TName name, T value)
        {
            Dictionary<TName, T> dicName;
            if(!_dicById.TryGetValue(id, out dicName))
            {
                dicName = new Dictionary<TName, T>();
                _dicById.Add(id, dicName);
            }
            if (dicName.ContainsKey(name))
            {
                throw new ArgumentOutOfRangeException("name", "Элемент с заданным именем(Id, Name) уже существует");
            }
            Dictionary<TId, T> dicId;
            if(!_dicByName.TryGetValue(name, out dicId))
            {
                dicId = new Dictionary<TId, T>();
                _dicByName.Add(name, dicId);
            }
            if (dicId.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("name", "Элемент с заданным именем(Id, Name) уже существует");
            }

            dicId.Add(id, value);
            dicName.Add(name, value);
            _count++;
        }

        /// <summary>
        /// удалить элемент
        /// </summary>
        public void Remove(TId id, TName name)
        {
            Dictionary<TName, T> dicName;
            if (!_dicById.TryGetValue(id, out dicName)) return;
            Dictionary<TId, T> dicId;
            if (!_dicByName.TryGetValue(name, out dicId)) return;

            dicId.Remove(id);
            dicName.Remove(name);
            _count--;
        }
        /// <summary>
        /// Получить элемент по ключу  
        /// </summary>
        
        public T Get(TId id, TName name) 
        {
            Dictionary<TName, T> dicName;
            if (_dicById.TryGetValue(id, out dicName)) return default(T);
            T value;
            if (dicName.TryGetValue(name, out value)) return value;
            return default(T);
        }

        /// <summary>
        /// Получить элементы, по name
        /// </summary>
        public IList<T> GetByName(TName name)
        {
            Dictionary<TId, T> dicId;
            if (!_dicByName.TryGetValue(name, out dicId)) return new List<T>();
            return dicId.Values.ToList();
        }

        /// <summary>
        /// Получить элементы, по name
        /// </summary>
        public IList<T> GetById(TId id)
        {
            Dictionary<TName, T> dicName;
            if (!_dicById.TryGetValue(id, out dicName)) return new List<T>();
            return dicName.Values.ToList();
        }
        public int Count
        {
            get
            {
                return _count;
            }
        }
    }
}
