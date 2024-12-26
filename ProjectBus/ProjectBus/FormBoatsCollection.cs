using ProjectBoat.CollectionGenericObjects;
using ProjectBoat.Drawnings;

namespace ProjectBoat
{
    public partial class FormBoatsCollection : Form
    {
        /// <summary>
        /// Компания
        /// </summary>
        private AbstractCompany? _company = null;
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormBoatsCollection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSelectorCompany_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBoxSelectorCompany.Text)
            {
                case "хранилище":
                    _company = new BoatDockingService(pictureBoxBoat.Width,
                    pictureBoxBoat.Height, new MassiveGenericObjects<DrawningBoat>());
                    break;
            }
        }

        /// <summary>
        /// Создание объекта класса-перемещения
        /// </summary>
        /// <param name="type">Тип создаваемого объекта</param>
        private void CreateObject(string type)
        {
            if (_company == null)
            {
                return;
            }
            Random random = new();
            DrawningBoat drawningBoat;
            switch (type)
            {
                case nameof(DrawningBoat):
                    drawningBoat = new DrawningBoat(random.Next(100, 300), random.Next(1000, 3000), GetColor(random));
                    break;
                case nameof(DrawningMBoat):
                    drawningBoat = new DrawningMBoat(random.Next(100, 300), random.Next(1000, 3000),
                    GetColor(random),
                    GetColor(random),
                    Convert.ToBoolean(random.Next(0, 2)),
                    Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)));
                    break;
                default:
                    return;
            }
            if (_company + drawningBoat != -1)
            {
                MessageBox.Show("объект добавлен");
                pictureBoxBoat.Image = _company.Show();
            }
            else
            {
                MessageBox.Show("не удалось добавить объект");
            }
        }

        /// <summary>
        /// Получение цвета
        /// </summary>
        /// <param name="random">Генератор случайных чисел</param>
        /// <returns></returns>
        private static Color GetColor(Random random)
        {
            Color color = Color.FromArgb(random.Next(0, 256), random.Next(0,
            256), random.Next(0, 256));
            ColorDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                color = dialog.Color;
            }
            return color;
        }

        //private void ButtonAddBoat_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningBoat));

        //private void ButtonAddMBoat_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningMBoat));
        private void ButtonAddBoat_Click(object sender, EventArgs e)
        {
            CreateObject(nameof(DrawningBoat));
        }

        private void ButtonAddMBoat_Click(object sender, EventArgs e)
        {
            CreateObject(nameof(DrawningMBoat));
        }

        private void ButtonRemoveBoat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBoxPosision.Text) || _company == null)
            {
                return;
            }
            if (MessageBox.Show("удалить объект?", "удаление",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            int pos = Convert.ToInt32(maskedTextBoxPosision.Text);
            if (_company - pos != null)
            {
                MessageBox.Show("объект удален");
                pictureBoxBoat.Image = _company.Show();
            }
            else
            {
                MessageBox.Show("не удалось удалить объект");
            }
        }

        private void ButtonGetToTest_Click(object sender, EventArgs e)
        {
            if (_company == null)
            {
                return;
            }

            DrawningBoat? cruiser = null;
            int counter = 100;
            while (cruiser == null)
            {
                cruiser = _company.GetRandomObject();
                counter--;
                if (counter <= 0)
                {
                    break;
                }
            }
            if (cruiser == null)
            {
                return;
            }
            FormBoat form = new()
            {
                SetBoat = cruiser
            };
            form.ShowDialog();

        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            if (_company == null)
            {
                return;
            }

            pictureBoxBoat.Image = _company.Show();
        }


    }
}
