namespace ProjectBoat
{
    public partial class FormBoat : Form
    {
        /// <summary>
        /// Поле-объект для прорисовки объекта
        /// </summary>
        private DrawningBoat? _drawningBoat;
        public FormBoat()
        {
            InitializeComponent();

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
            Bitmap bmp = new(pictureBox1.Width,
            pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _drawningBoat.DrawTransport(gr);
            pictureBox1.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateBoat_Click(object sender, EventArgs e)
        {
            Random random = new();
            _drawningBoat = new DrawningBoat();
            _drawningBoat.Init(random.Next(100, 300), random.Next(1000, 3000),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Convert.ToBoolean(random.Next(0, 2)),
            Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)));
            _drawningBoat.SetPictureSize(pictureBox1.Width,
            pictureBox1.Height);

            //начальное положение круисера
            _drawningBoat.SetPosition(random.Next(10, 100), random.Next(10, 100));
            Draw();
        }
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
    }
}
