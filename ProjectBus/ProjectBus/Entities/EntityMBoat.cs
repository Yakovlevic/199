namespace ProjectBoat.Entities
{
    internal class EntityMBoat : EntityBoat
    {
        /// <summary>
        /// Признак (опция) наличие вертолетной площадки
        /// </summary>
        public bool Motor { get; private set; }
        /// <summary>
        /// Признак (опция) наличие шлюпок
        /// </summary>
        public bool Oars { get; private set; }
        /// <summary>
        /// Признак (опция) наличие пушки
        /// </summary>
        public bool Glass { get; private set; }
        /// <summary>
        /// Дополнительный цвет (для опциональных элементов)
        /// </summary>
        public Color AdditionalColor { get; private set; }

        public EntityMBoat(int speed, double weight, Color bodyColor, Color additionalColor, bool motor, bool oars, bool glass) : base(speed, weight, bodyColor)
        {
            AdditionalColor = additionalColor;
            Motor = motor;
            Oars = oars;
            Glass = glass;
        }
    }
}
