using System.Drawing.Drawing2D;
using ProjectBoat.Entities;

namespace ProjectBoat.Drawnings
{
    public class DrawningMBoat : DrawningBoat
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="bodyColor">Основной цвет</param>
        /// <param name="additionalColor">Дополнительный цвет</param>
        /// <param name="motor">Признак наличия вертолетной площадки</param>
        /// <param name="oars">Признак наличия шлюпок</param>
        /// <param name="glass">Признак наличия пушки</param>

        public DrawningMBoat(int speed, double weight, Color bodyColor, Color additionalColor, bool motor, bool oars, bool glass)
            : base(150, 50)
        {
            EntityBoat = new EntityMBoat(speed, weight, bodyColor, additionalColor, motor, oars, glass);
        }

        public override void DrawTransport(Graphics g)
        {
            if (EntityBoat == null || EntityBoat is not EntityMBoat entityMBoat || !_startPosX.HasValue ||
            !_startPosY.HasValue)
            {
                return;
            }

            Pen pen = new(EntityBoat.BodyColor, 2);
            Brush motorBrush = new SolidBrush(Color.Black);
            Brush glassBrush = new SolidBrush(Color.Blue);
            Brush oarsBrush = new HatchBrush(HatchStyle.ZigZag, Color.FromArgb(163, 163, 163));
            

            base.DrawTransport(g);

            if (entityMBoat.Motor)
            {
                g.FillRectangle(motorBrush, _startPosX.Value - 3, _startPosY.Value + 15, 20, 17);

            }

            if (entityMBoat.Oars)
            {
                g.DrawEllipse(pen, _startPosX.Value + 45, _startPosY.Value - 15, 10, 13);
                g.FillEllipse(oarsBrush, _startPosX.Value + 45, _startPosY.Value - 15, 10, 13);
                g.FillRectangle(motorBrush, _startPosX.Value + 49, _startPosY.Value - 1, 2, 20);

                g.DrawEllipse(pen, _startPosX.Value + 45, _startPosY.Value + 48, 10, 13);
                g.FillEllipse(oarsBrush, _startPosX.Value + 45, _startPosY.Value + 48, 10, 13);
                g.FillRectangle(motorBrush, _startPosX.Value + 49, _startPosY.Value + 30, 2, 20);
            }

            if (entityMBoat.Glass)
            {
                g.FillRectangle(glassBrush, _startPosX.Value + 100, _startPosY.Value + 7, 10, 36);


            }
        }
    }
}
