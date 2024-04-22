using ProjectBoat.Drawnings;

namespace ProjectBoat.CollectionGenericObjects
{
    /// <summary>
    /// Реализация абстрактной компании - каршеринг
    /// </summary>
    public class BoatDockingService : AbstractCompany
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth"></param>
        /// <param name="picHeight"></param>
        /// <param name="collection"></param>
        public BoatDockingService(int picWidth, int picHeight,
        ICollectionGenericObjects<DrawningBoat> collection) : base(picWidth, picHeight, collection)
        {
        }
        protected override void DrawBackgound(Graphics g)
        {
            int width = _pictureWidth / _placeSizeWidth;
            int height = _pictureHeight / _placeSizeHeight;
            Pen pen = new(Color.Black, 2);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height + 1; ++j)
                {
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + _placeSizeWidth - 20, j * _placeSizeHeight);
                    g.DrawLine(pen, i * _placeSizeWidth + _placeSizeWidth - 20, j * _placeSizeHeight, i * _placeSizeWidth + _placeSizeWidth - 20, j * _placeSizeHeight + _placeSizeHeight);
                }
            }
        }
        protected override void SetObjectsPosition()
        {
            int width = _pictureWidth / _placeSizeWidth;
            int height = _pictureHeight / _placeSizeHeight;

            int curWidth = 0;
            int curHeight = 0;

            for (int i = 0; i < (_collection?.Count ?? 0); i++)
            {
                if (_collection.Get(i) != null)
                {
                    _collection.Get(i).SetPictureSize(_pictureWidth, _pictureHeight);
                    _collection.Get(i).SetPosition(_placeSizeWidth * curWidth + 10, curHeight * _placeSizeHeight + 10);
                }

                if (curWidth < width - 1)
                    curWidth++;
                else
                {
                    curWidth = 0; 
                    curHeight ++;
                }

                if (curHeight >= height)
                {
                    return;
                }
            }
        }
    }
}
