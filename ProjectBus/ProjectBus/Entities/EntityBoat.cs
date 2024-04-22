namespace ProjectBoat.Entities;

/// <summary>
/// Класс-сущность "крейсер"
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
    /// Шаг перемещения автомобиля
    /// </summary>
    public double Step => Speed * 100 / Weight;
    /// <summary>
    /// Инициализация полей объекта-класса крейсера
    /// </summary>
    /// <param name="speed">скорость</param>
    /// <param name="weight">вес</param>
    /// <param name="bodyColor">основной цвет</param>    
    public EntityBoat(int speed, double weight, Color bodyColor)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
    }
}
