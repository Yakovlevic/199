using ProjectBoat.Drawnings;

namespace ProjectBoat.CollectionGenericObjects
{
    /// <summary>
    /// Параметризованный набор объектов
    /// </summary>
    /// <typeparam name="T">Параметр: ограничение - ссылочный тип</typeparam>
    public class MassiveGenericObjects<T> : ICollectionGenericObjects<T>
    where T : class
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private T?[] _collection;
        public int Count => _collection.Length;
        public int SetMaxCount { set { if (value > 0) { _collection = new T?[value]; } } }

        /// <summary>
        /// Конструктор
        /// </summary>
        public MassiveGenericObjects()
        {
            _collection = Array.Empty<T?>();
        }
        public T? Get(int position)
        {
            // TODO проверка позиции
            if (position >= _collection.Length || position < 0)
            {
                return null;
            }
            return _collection[position];
        }
        public int Insert(T obj)
        {
            // TODO вставка в свободное место набора
            int index = 0;
            while (index < _collection.Length)
            {
                if (_collection[index] == null)
                {
                    _collection[index] = obj;
                    return index;
                }
                index++;
            }
            return -1;
        }
        public int Insert(T obj, int position)
        {
            // TODO проверка позиции
            // TODO проверка, что элемент массива по этой позиции пустой, если нет, то
            // ищется свободное место после этой позиции и идет вставка туда
            // если нет после, ищем до
            // TODO вставка
            if (position >= _collection.Length || position < 0)
            { return -1; }

            if (_collection[position] == null)
            {
                _collection[position] = obj;
                return position;
            }
            int index;

            for (index = position + 1; index < _collection.Length; ++index)
            {
                if (_collection[index] == null)
                {
                    _collection[position] = obj;
                    return position;
                }
            }

            for (index = position - 1; index >= 0; --index)
            {
                if (_collection[index] == null)
                {
                    _collection[position] = obj;
                    return position;
                }
            }
            return -1;
        }
        public T Remove(int position)
        {
            // TODO проверка позиции
            // TODO удаление объекта из массива, присвоив элементу массива значение null
            if (position >= _collection.Length || position < 0)
            { return null; }
            T drawningBoat = _collection[position];
            _collection[position] = null;
            return drawningBoat;
        }
    }
}
