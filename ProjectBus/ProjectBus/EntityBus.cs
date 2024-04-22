namespace ProjectBus;
/// <summary>
/// Класс-сущность "автобус"
/// </summary>
public class EntityBus
{
    //свойства
    /// <summary>
    /// Скорость
    /// </summary>
    public int Speed { get; private set; }
    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; private set; }
    /// <summary>
    /// Основной цвет
    /// </summary>
    public Color BodyColor { get; private set; }
    /// <summary>
    /// Дополнительный цвет (для опциональных элементов)
    /// </summary>
    public Color AdditionalColor { get; private set; }
    /// <summary>
    /// Признак (опция) наличие второго этажа
    /// </summary>
    public bool SecondFloor { get; private set; }
    /// <summary>
    /// Признак (опция) наличие лестницы
    /// </summary>
    public bool Ladder { get; private set; }
    /// <summary>
    /// Признак (опция) наличие фар
    /// </summary>
    public bool Headlights { get; private set; }
    //поле класса
    /// <summary>
    /// Шаг перемещения автомобиля
    /// </summary>
    public double Step => Speed * 100 / Weight;
    /// <summary>
    /// Инициализация полей объекта-класса крейсера
    /// </summary>
    /// <param name="speed">скорость</param>
    /// <param name="weight">вес</param>
    /// <param name="bodyColor">основной цвет</param>
    /// <param name="additionalColor">дополнительный цвет</param>
    /// <param name="secondFloor">второй этаж</param>
    /// <param name="ladder">лестница</param>
    /// <param name="headlights">наличие фар</param>
    public void Init(int speed, double weight, Color bodyColor, Color
    additionalColor, bool secondFloor, bool ladder, bool headlights)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
        AdditionalColor = additionalColor;
        SecondFloor = secondFloor;
        Ladder = ladder;
        Headlights = headlights;
    }
}
