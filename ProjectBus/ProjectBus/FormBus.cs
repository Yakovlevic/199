namespace ProjectBus
{
    public partial class FormBus : Form
    {
        /// <summary>
        /// Поле-объект для прорисовки объекта
        /// </summary>
        private DrawningBus? _drawningBus;
        public FormBus()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Метод прорисовки круисера
        /// </summary>
        private void Draw()
        {
            if (_drawningBus == null)
            {
                return;
            }
            Bitmap bmp = new(pictureBox1.Width,
            pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _drawningBus.DrawTransport(gr);
            pictureBox1.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateBus_Click(object sender, EventArgs e)
        {
            Random random = new();
            _drawningBus = new DrawningBus();
            _drawningBus.Init(random.Next(100, 300), random.Next(1000, 3000),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Convert.ToBoolean(random.Next(0, 2)),
            Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)));
            _drawningBus.SetPictureSize(pictureBox1.Width,
            pictureBox1.Height);

            //начальное положение круисера
            _drawningBus.SetPosition(random.Next(10, 100), random.Next(10, 100));
            Draw();
        }
        /// <summary>
        /// Перемещение объекта по форме (нажатие кнопок навигации)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            if (_drawningBus == null)
            {
                return;
            }
            string name = ((Button)sender)?.Name ?? string.Empty;
            bool result = false;
            switch (name)
            {
                case "buttonUp":
                    result =
                    _drawningBus.MoveTransport(DirectionType.Up);
                    break;
                case "buttonDown":
                    result =
                    _drawningBus.MoveTransport(DirectionType.Down);
                    break;
                case "buttonLeft":
                    result =
                    _drawningBus.MoveTransport(DirectionType.Left);
                    break;
                case "buttonRight":
                    result =
                    _drawningBus.MoveTransport(DirectionType.Right);
                    break;
            }
            if (result)
            {
                Draw();
            }
        }
    }
}
