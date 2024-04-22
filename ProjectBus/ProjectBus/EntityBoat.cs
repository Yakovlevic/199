namespace ProjectBoat;
/// <summary>
/// Класс-сущность "автобус"
/// </summary>
public class EntityBoat
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
    public bool Motor { get; private set; }
    /// <summary>
    /// Признак (опция) наличие лестницы
    /// </summary>
    public bool Oars { get; private set; }
    /// <summary>
    /// Признак (опция) наличие фар
    /// </summary>
    public bool Glass { get; private set; }
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
    /// <param name="motor">второй этаж</param>
    /// <param name="oars">лестница</param>
    /// <param name="glass">наличие фар</param>
    public void Init(int speed, double weight, Color bodyColor, Color
    additionalColor, bool motor, bool oars, bool glass)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
        AdditionalColor = additionalColor;
        Motor = motor;
        Oars = oars;
        Glass = glass;
    }
}
