using ProjectBoat.Entities;
using System.Drawing.Drawing2D;

namespace ProjectBoat.Drawnings;
/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта-сущности
/// </summary>
public class DrawningBoat
{
    /// <summary>
    /// Класс-сущность
    /// </summary>
    public EntityBoat? EntityBoat { get; protected set; }
    /// <summary>
    /// Ширина окна
    /// </summary>
    private int? _pictureWidth;
    /// <summary>
    /// Высота окна
    /// </summary>
    private int? _pictureHeight;
    /// <summary>
    /// Левая координата прорисовки автомобиля
    /// </summary>
    protected int? _startPosX;
    /// <summary>
    /// Верхняя кооридната прорисовки автомобиля
    /// </summary>
    protected int? _startPosY;

    /// <summary>
    /// Ширина прорисовки крейсера
    /// </summary>
    private readonly int _drawningBoatWidth = 150;
    /// <summary>
    /// Высота прорисовки крейсера 
    /// </summary>
    private readonly int _drawningBoatHeight = 50;
    private readonly int _drawningEnginesWidth = 3;

    /// <summary>
    /// Координата X объекта
    /// </summary>
    public int? GetPosX => _startPosX;
    /// <summary>
    /// Координата Y объекта
    /// </summary>
    public int? GetPosY => _startPosY;
    /// <summary>
    /// Ширина объекта
    /// </summary>
    public int GetWidth => _drawningBoatWidth;
    /// <summary>
    /// Высота объекта
    /// </summary>
    public int GetHeight => _drawningBoatHeight;

    /// <summary>
    /// Пустой онструктор
    /// </summary>
    private DrawningBoat()
    {
        _pictureWidth = null;
        _pictureHeight = null;
        _startPosX = null;
        _startPosY = null;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    public DrawningBoat(int speed, double weight, Color bodyColor) : this()
    {
        EntityBoat = new EntityBoat(speed, weight, bodyColor);
    }
    /// <summary>
    /// Конструктор для наследников
    /// </summary>
    /// <param name="drawningCarWidth">Ширина прорисовки автомобиля</param>
    /// <param name="drawningCarHeight">Высота прорисовки автомобиля</param>
    protected DrawningBoat(int drawningCarWidth, int drawningCarHeight) : this()
    {
        _drawningBoatWidth = drawningCarWidth;
        _pictureHeight = drawningCarHeight;
    }

    /// <summary>
    /// Установка границ поля
    /// </summary>
    /// <param name="width">Ширина поля</param>
    /// <param name="height">Высота поля</param>
    /// <returns>true - границы заданы, false - проверка не пройдена, нельзя разместить объект в этих размерах</returns>
    public bool SetPictureSize(int width, int height)
    {
        // TODO проверка, что объект "влезает" в размеры поля
        // если влезает, сохраняем границы и корректируем позицию объекта,если она была уже установлена

        if (_drawningBoatHeight > height || _drawningBoatWidth > width)
        {
            return false;

        }

        _pictureWidth = width;
        _pictureHeight = height;

        if (_startPosX.HasValue && _startPosY.HasValue)
        {
            SetPosition(_startPosX.Value, _startPosY.Value);
        }

        return true;
    }
    /// <summary>
    /// Установка позиции
    /// </summary>
    /// <param name="x">Координата X</param>
    /// <param name="y">Координата Y</param>
    public void SetPosition(int x, int y)
    {
        if (!_pictureHeight.HasValue || !_pictureWidth.HasValue)
        {
            return;
        }

        if (x < 0 || x + _drawningBoatWidth > _pictureWidth || y < 0 || y + _drawningBoatHeight > _pictureHeight)
        {
            _startPosX = _pictureWidth - _drawningBoatWidth;
            _startPosY = _pictureHeight - _drawningBoatHeight;
        }
        else
        {
            _startPosX = x;
            _startPosY = y;
        }

    }
    /// <summary>
    /// Изменение направления перемещения
    /// </summary>
    /// <param name="direction">Направление</param>
    /// <returns>true - перемещене выполнено, false - перемещение невозможно</returns>
    public bool MoveTransport(DirectionType direction)
    {
        if (EntityBoat == null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return false;
        }
        switch (direction)
        {
            //влево
            case DirectionType.Left:
                if (_startPosX.Value - EntityBoat.Step - _drawningEnginesWidth > 0)
                {
                    _startPosX -= (int)EntityBoat.Step;
                }
                return true;
            //вверх
            case DirectionType.Up:
                if (_startPosY.Value - EntityBoat.Step > 0)
                {
                    _startPosY -= (int)EntityBoat.Step;
                }
                return true;
            // вправо
            case DirectionType.Right:
                //TODO прописать логику сдвига в право
                if (_startPosX.Value + EntityBoat.Step + _drawningBoatWidth < _pictureWidth)
                {
                    _startPosX += (int)EntityBoat.Step;
                }
                return true;
            //вниз
            case DirectionType.Down:
                if (_startPosY.Value + EntityBoat.Step + _drawningBoatHeight < _pictureHeight)
                {
                    _startPosY += (int)EntityBoat.Step;
                }
                return true;
            default:
                return false;
        }
    }
    /// <summary>
    /// Прорисовка объекта
    /// </summary>
    /// <param name="g"></param>
    public virtual void DrawTransport(Graphics g)
    {
        if (EntityBoat == null || !_startPosX.HasValue ||
        !_startPosY.HasValue)
        {
            return;
        }
        Pen pen = new(EntityBoat.BodyColor, 2);
        Pen pen2 = new(Color.Black, 2);
        Brush motorBrush = new SolidBrush(Color.Black);
        Brush glassBrush = new SolidBrush(Color.Blue);
        Brush Brush = new SolidBrush(EntityBoat.BodyColor);



        //границы круисера
        Point[] points = { new Point(_startPosX.Value, _startPosY.Value), new Point(_startPosX.Value + 105, _startPosY.Value), new Point( _startPosX.Value + 147, _startPosY.Value + 24), new Point(_startPosX.Value + 105, _startPosY.Value + 49), new Point(_startPosX.Value , _startPosY.Value + 49), new Point(_startPosX.Value, _startPosY.Value ) };
        g.FillPolygon(Brush, points);
        g.DrawPolygon(pen2, points);

        //g.DrawLine(pen, _startPosX.Value, _startPosY.Value, _startPosX.Value + 105, _startPosY.Value);
        // g.DrawLine(pen, _startPosX.Value + 105, _startPosY.Value, _startPosX.Value + 147, _startPosY.Value + 24);

        // g.DrawLine(pen, _startPosX.Value, _startPosY.Value + 49, _startPosX.Value + 105, _startPosY.Value + 49);
        // g.DrawLine(pen, _startPosX.Value + 105, _startPosY.Value + 49, _startPosX.Value + 147, _startPosY.Value + 24);

        //g.DrawLine(pen, _startPosX.Value, _startPosY.Value, _startPosX.Value, _startPosY.Value + 49);

        //внутренности круисера

        g.DrawRectangle(pen2, _startPosX.Value + 25, _startPosY.Value + 10, 80, 30);
   
    }
}
    