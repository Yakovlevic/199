using ProjectBoat.Drawnings;
using ProjectBoat.MovementStrategy;

namespace ProjectBoat
{
    public partial class FormBoat : Form
    {
        /// <summary>
        /// Поле-объект для прорисовки объекта
        /// </summary>
        private DrawningBoat? _drawningBoat;

        /// <summary>
        /// Стратегия перемещения
        /// </summary>
        private AbstractStrategy? _strategy;

        public FormBoat()
        {
            InitializeComponent();
            _strategy = null;
        }

        /// <summary>
        /// Метод прорисовки круисера
        /// </summary>
        private void Draw()
        {
            if (_drawningBoat == null)
            {
                return;
            }
            Bitmap bmp = new(pictureBoxBoat.Width,
            pictureBoxBoat.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _drawningBoat.DrawTransport(gr);
            pictureBoxBoat.Image = bmp;
        }

        /// <summary>
        /// Создание объекта класса-перемещения
        /// </summary>
        /// <param name="type">Тип создаваемого объекта</param>
        private void CreateObject(string type)
        {
            Random random = new();
            switch (type)
            {
                case nameof(DrawningBoat):
                    _drawningBoat = new DrawningBoat(random.Next(100, 300),
                    random.Next(1000, 3000),
                    Color.FromArgb(random.Next(0, 256),
                    random.Next(0, 256), random.Next(0, 256)));
                    break;
                case nameof(DrawningMBoat):
                    _drawningBoat = new DrawningMBoat(random.Next(100,
                    300), random.Next(1000, 3000),
                    Color.FromArgb(random.Next(0, 256),
                    random.Next(0, 256), random.Next(0, 256)),
                    Color.FromArgb(random.Next(0, 256),
                    random.Next(0, 256), random.Next(0, 256)),
                    Convert.ToBoolean(random.Next(0, 2)),
                    Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)));
                    break;
                default:
                    return;
            }
            _drawningBoat.SetPictureSize(pictureBoxBoat.Width,
            pictureBoxBoat.Height);
            _drawningBoat.SetPosition(random.Next(10, 100), random.Next(10, 100));
            _strategy = null;
            comboBoxStrategy.Enabled = true;
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Создать военный крейсер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateBoat_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningMBoat));

        /// <summary>
        /// Обработка нажатия кнопки "Создать крейсер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCretaeBoat_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningBoat));


        /// <summary>
        /// Перемещение объекта по форме (нажатие кнопок навигации)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            if (_drawningBoat == null)
            {
                return;
            }
            string name = ((Button)sender)?.Name ?? string.Empty;
            bool result = false;
            switch (name)
            {
                case "buttonUp":
                    result =
                    _drawningBoat.MoveTransport(DirectionType.Up);
                    break;
                case "buttonDown":
                    result =
                    _drawningBoat.MoveTransport(DirectionType.Down);
                    break;
                case "buttonLeft":
                    result =
                    _drawningBoat.MoveTransport(DirectionType.Left);
                    break;
                case "buttonRight":
                    result =
                    _drawningBoat.MoveTransport(DirectionType.Right);
                    break;
            }
            if (result)
            {
                Draw();
            }
        }

        /// <summary>
        /// обработка нажатия кнопки шаг
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStrategyStep_Click(object sender, EventArgs e)
        {
            if (_drawningBoat == null)
            {
                return;
            }

            if (comboBoxStrategy.Enabled)
            {
                _strategy = comboBoxStrategy.SelectedIndex switch
                {
                    0 => new MoveToCenter(),
                    1 => new MoveToBorder(),
                    _ => null,
                };

                if (_strategy == null)
                {
                    return;
                }
                _strategy.SetData(new MoveableBoat(_drawningBoat), pictureBoxBoat.Width, pictureBoxBoat.Height);
            }

            if (_strategy == null)
            {
                return;
            }

            comboBoxStrategy.Enabled = false;
            _strategy.MakeStep();
            Draw();

            if (_strategy.GetStatus() == StrategyStatus.Finish)
            {
                comboBoxStrategy.Enabled = true;
                _strategy = null;
            }
        }

        private void FormBoat_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxBoat_Click(object sender, EventArgs e)
        {

        }
    }
}
