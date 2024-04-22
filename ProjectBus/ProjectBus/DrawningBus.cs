using ProjectBus;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.Xml;

namespace ProjectBus;
/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта-сущности
/// </summary>
public class DrawningBus
{
    /// <summary>
    /// Класс-сущность
    /// </summary>
    public EntityBus? EntityBus { get; private set; }
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
    private int? _startPosX;
    /// <summary>
    /// Верхняя кооридната прорисовки автомобиля
    /// </summary>
    private int? _startPosY;

    /// <summary>
    /// Ширина прорисовки крейсера
    /// </summary>
    private readonly int _drawningBusWidth = 150;
    /// <summary>
    /// Высота прорисовки крейсера 
    /// </summary>
    private readonly int _drawningBusHeight = 50;
    private readonly int _drawningEnginesWidth = 3;
    /// <summary>
    /// Инициализация свойств
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    /// <param name="additionalColor">Дополнительный цвет</param>
    /// <param name="secondFloor">Признак наличия второго этажа</param>
    /// <param name="ladder">Признак наличия лестнницы</param>
    /// <param name="headlights">Признак наличия фар</param>
    public void Init(int speed, double weight, Color bodyColor, Color
    additionalColor, bool secondFloor, bool ladder, bool headlights)
    {
        EntityBus = new EntityBus();
        EntityBus.Init(speed, weight, bodyColor, additionalColor,
        secondFloor, ladder, headlights);
        _pictureWidth = null;
        _pictureHeight = null;
        _startPosX = null;
        _startPosY = null;
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

        if (_drawningBusHeight > height || _drawningBusWidth > width)
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

        if (x < 0 || x + _drawningBusWidth > _pictureWidth || y < 0 || y + _drawningBusHeight > _pictureHeight)
        {
            _startPosX = _pictureWidth - _drawningBusWidth;
            _startPosY = _pictureHeight - _drawningBusHeight;
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
        if (EntityBus == null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return false;
        }
        switch (direction)
        {
            //влево
            case DirectionType.Left:
                if (_startPosX.Value - EntityBus.Step - _drawningEnginesWidth > 0)
                {
                    _startPosX -= (int)EntityBus.Step;
                }
                return true;
            //вверх
            case DirectionType.Up:
                if (_startPosY.Value - EntityBus.Step > 0)
                {
                    _startPosY -= (int)EntityBus.Step;
                }
                return true;
            // вправо
            case DirectionType.Right:
                //TODO прописать логику сдвига в право
                if (_startPosX.Value + EntityBus.Step + _drawningBusWidth < _pictureWidth)
                {
                    _startPosX += (int)EntityBus.Step;
                }
                return true;
            //вниз
            case DirectionType.Down:
                if (_startPosY.Value + EntityBus.Step + _drawningBusHeight < _pictureHeight)
                {
                    _startPosY += (int)EntityBus.Step;
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
    public void DrawTransport(Graphics g)
    {
        if (EntityBus == null || !_startPosX.HasValue ||
        !_startPosY.HasValue)
        {
            return;
        }
        Pen pen = new(EntityBus.BodyColor, 2);
        Pen pen2 = new(Color.Black, 2);
        Brush additionalBrush = new SolidBrush(Color.Black);
        Brush headlightsBrush = new SolidBrush(Color.Yellow);
        Brush headlightsBrush2 = new SolidBrush(EntityBus.AdditionalColor);
        Brush secondFloorBrush = new HatchBrush(HatchStyle.ZigZag, EntityBus.AdditionalColor, Color.FromArgb(163, 163, 163));
        Brush ladderBrush = new SolidBrush(Color.LightBlue);

        //границы круисера
        g.FillRectangle(secondFloorBrush, _startPosX.Value, _startPosY.Value + 50, 150, 50);
        g.DrawRectangle(pen, _startPosX.Value, _startPosY.Value + 50, 150, 50);

        g.FillRectangle(headlightsBrush2, _startPosX.Value + 40, _startPosY.Value + 65, 20, 35);
        g.DrawRectangle(pen, _startPosX.Value + 40, _startPosY.Value + 65, 20, 35);

        g.FillEllipse(additionalBrush, _startPosX.Value + 15, _startPosY.Value + 90, 22, 22);
        g.FillEllipse(additionalBrush, _startPosX.Value + 110, _startPosY.Value + 90, 22, 22);

        g.FillEllipse(ladderBrush, _startPosX.Value + 130, _startPosY.Value + 55, 20, 30);
        g.FillEllipse(ladderBrush, _startPosX.Value + 108, _startPosY.Value + 55, 20, 30);
        g.FillEllipse(ladderBrush, _startPosX.Value + 86, _startPosY.Value + 55, 20, 30);
        g.FillEllipse(ladderBrush, _startPosX.Value + 64, _startPosY.Value + 55, 20, 30);

       

        if (EntityBus.SecondFloor)
        {
            g.FillRectangle(secondFloorBrush, _startPosX.Value, _startPosY.Value, 150, 50);
            g.DrawRectangle(pen, _startPosX.Value, _startPosY.Value, 150, 50);
            g.FillEllipse(ladderBrush, _startPosX.Value + 130, _startPosY.Value + 5, 20, 30);
            g.FillEllipse(ladderBrush, _startPosX.Value + 105, _startPosY.Value + 5, 20, 30);
            g.FillEllipse(ladderBrush, _startPosX.Value + 80, _startPosY.Value + 5, 20, 30);
            g.FillEllipse(ladderBrush, _startPosX.Value + 55, _startPosY.Value + 5, 20, 30);
            g.FillEllipse(ladderBrush, _startPosX.Value + 30, _startPosY.Value + 5, 20, 30);
            //g.FillEllipse(ladderBrush, _startPosX.Value + 5, _startPosY.Value + 5, 20, 30);
            //g.FillEllipse(ladderBrush, _startPosX.Value + -2, _startPosY.Value + 5, 20, 30);

            if (EntityBus.Ladder)
            {
                g.FillRectangle(headlightsBrush2, _startPosX.Value, _startPosY.Value + 15, 20, 35);
                g.DrawRectangle(pen, _startPosX.Value, _startPosY.Value + 15, 20, 35);
                g.DrawLine(pen2, _startPosX.Value, _startPosY.Value + 50, _startPosX.Value, _startPosY.Value + 100);
                g.DrawLine(pen2, _startPosX.Value + 20, _startPosY.Value + 50, _startPosX.Value + 20, _startPosY.Value + 100);
                g.DrawLine(pen2, _startPosX.Value, _startPosY.Value + 60, _startPosX.Value + 20, _startPosY.Value + 60);
                g.DrawLine(pen2, _startPosX.Value, _startPosY.Value + 70, _startPosX.Value + 20, _startPosY.Value + 70);
                g.DrawLine(pen2, _startPosX.Value, _startPosY.Value + 80, _startPosX.Value + 20, _startPosY.Value + 80);
                g.DrawLine(pen2, _startPosX.Value, _startPosY.Value + 90, _startPosX.Value + 20, _startPosY.Value + 90);
               
            }
            else
            {
                g.FillEllipse(ladderBrush, _startPosX.Value + 5, _startPosY.Value + 5, 20, 30);
                g.FillEllipse(ladderBrush, _startPosX.Value + 5, _startPosY.Value + 55, 20, 30);

            }
        }
        else
        {
            g.FillEllipse(ladderBrush, _startPosX.Value + 5, _startPosY.Value + 55, 20, 30);
        }
        

        if (EntityBus.Headlights)
        {
            g.FillEllipse(headlightsBrush, _startPosX.Value + 143, _startPosY.Value + 80, 8, 15);
            
        }

    }
}