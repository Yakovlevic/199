using ProjectBoat.Drawnings;

namespace ProjectBoat.CollectionGenericObjects
{
    /// <summary>
    /// Абстракция компании, хранящий коллекцию автомобилей
    /// </summary>
    public abstract class AbstractCompany
    {
        /// <summary>
        /// Размер места (ширина)
        /// </summary>
        protected readonly int _placeSizeWidth = 180;

        /// <summary>
        /// Размер места (высота)
        /// </summary>
        protected readonly int _placeSizeHeight = 70;

        /// <summary>
        /// Ширина окна
        /// </summary>
        protected readonly int _pictureWidth;

        /// <summary>
        /// Высота окна
        /// </summary>
        protected readonly int _pictureHeight;

        /// <summary>
        /// Коллекция автомобилей
        /// </summary>
        protected ICollectionGenericObjects<DrawningBoat>? _collection = null;

        /// <summary>
        /// Вычисление максимального количества элементов, который можно разместить в окне
        /// </summary>
        private int GetMaxCount => _pictureWidth * _pictureHeight / (_placeSizeWidth * _placeSizeHeight);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Ширина окна</param>
        /// <param name="picHeight">Высота окна</param>
        /// <param name="collection">Коллекция автомобилей</param>
        public AbstractCompany(int picWidth, int picHeight,
        ICollectionGenericObjects<DrawningBoat> collection)
        {
            _pictureWidth = picWidth;
            _pictureHeight = picHeight;
            _collection = collection;
            _collection.SetMaxCount = GetMaxCount;
        }

        /// <summary>
        /// Перегрузка оператора сложения для класса
        /// </summary>
        /// <param name="company">Компания</param>
        /// <param name="сruiser">Добавляемый объект</param>
        /// <returns></returns>
        public static int operator +(AbstractCompany company, DrawningBoat  сruiser)
        {
            return company._collection.Insert(сruiser);
        }

        /// <summary>
        /// Перегрузка оператора удаления для класса
        /// </summary>
        /// <param name="company">Компания</param>
        /// <param name="position">Номер удаляемого объекта</param>
        /// <returns></returns>
        public static DrawningBoat operator -(AbstractCompany company, int position)
        {
            return company._collection?.Remove(position);
        }

        /// <summary>
        /// Получение случайного объекта из коллекции
        /// </summary>
        /// <returns></returns>
        public DrawningBoat? GetRandomObject()
        {
            Random rnd = new();
            return _collection?.Get(rnd.Next(GetMaxCount));
        }

        /// <summary>
        /// Вывод всей коллекции
        /// </summary>
        /// <returns></returns>
        public Bitmap? Show()
        {
            Bitmap bitmap = new(_pictureWidth, _pictureHeight);
            Graphics graphics = Graphics.FromImage(bitmap);
            DrawBackgound(graphics);
            SetObjectsPosition();
            for (int i = 0; i < (_collection?.Count ?? 0); ++i)
            {
                DrawningBoat? obj = _collection?.Get(i);
                obj?.DrawTransport(graphics);
            }
            return bitmap;
        }
        /// <summary>
        /// Вывод заднего фона
        /// </summary>
        /// <param name="g"></param>
        protected abstract void DrawBackgound(Graphics g);

        /// <summary>
        /// Расстановка объектов
        /// </summary>
        protected abstract void SetObjectsPosition();
    }
}
