using ProjectBoat.Drawnings;

namespace ProjectBoat.MovementStrategy
{
    /// <summary>
    /// класс реалтзация для IMoveableObject с использованием DrawningBoat
    /// </summary>
    public class MoveableBoat : IMoveableObject
    {
        /// <summary>
        /// Поле-объект класса DrawningBoat или его наследника
        /// </summary>
        private readonly DrawningBoat? _cruiser = null;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="cruiser">Объект класса DrawningBoat</param>
        public MoveableBoat(DrawningBoat cruiser)
        {
            _cruiser = cruiser;
        }
        public ObjectParameters? GetObjectPosition
        {
            get
            {
                if (_cruiser == null || _cruiser.EntityBoat == null ||
                !_cruiser.GetPosX.HasValue || !_cruiser.GetPosY.HasValue)
                {
                    return null;
                }
                return new ObjectParameters(_cruiser.GetPosX.Value,
                _cruiser.GetPosY.Value, _cruiser.GetWidth, _cruiser.GetHeight);
            }
        }
        public int GetStep => (int)(_cruiser?.EntityBoat?.Step ?? 0);
        public bool TryMoveObject(MovementDirection direction)
        {
            if (_cruiser == null || _cruiser.EntityBoat == null)
            {
                return false;
            }
            return _cruiser.MoveTransport(GetDirectionType(direction));
        }
        /// <summary>
        /// Конвертация из MovementDirection в DirectionType
        /// </summary>
        /// <param name="direction">MovementDirection</param>
        /// <returns>DirectionType</returns>
        private static DirectionType GetDirectionType(MovementDirection direction)
        {
            return direction switch
            {
                MovementDirection.Left => DirectionType.Left,
                MovementDirection.Right => DirectionType.Right,
                MovementDirection.Up => DirectionType.Up,
                MovementDirection.Down => DirectionType.Down,
                _ => DirectionType.Unknow,
            };
        }
    }
}

