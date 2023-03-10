namespace LR7_ver2
{
    /// <summary>
    /// Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        // Объявления строк и столбцов.
        private int _rowCount1;
        private int _rowCount2;
        private int _columnCount1;
        private int _columnCount2;

        // Объявление матриц.
        private double[,] _matr1;
        private double[,] _matr2;
        private double[,] _matr3;

        /// <summary>
        /// Form1.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = "Не введено";
            label1.ForeColor = Color.DarkRed;
            label2.Text = "Не введено";
            label2.ForeColor = Color.DarkRed;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Чтение размерности матрицы
            if (!EmptyTextBox(textBox1.Text) ||
                !EmptyTextBox(textBox2.Text))
            {
                return;
            }

            _rowCount1 = int.Parse(textBox1.Text);
            _columnCount1 = int.Parse(textBox2.Text);

            var form = new Form2(_rowCount1, _columnCount1);

            if (_matr1 is not null)
            {
                if (_rowCount1 == _matr1.GetLength(0)
                    && _columnCount1 == _matr1.GetLength(1))
                {
                    form.FromDataGrid(_matr1);
                }
            }

            _matr1 = form.FillMatr(_rowCount1, _columnCount1);

            label1.Text = "Введено";
            label1.ForeColor = Color.DarkGreen;

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            // Чтение размерности матрицы
            if (!EmptyTextBox(textBox3.Text) ||
                !EmptyTextBox(textBox3.Text))
            {
                return;
            }

            _rowCount2 = int.Parse(textBox3.Text);
            _columnCount2 = int.Parse(textBox4.Text);

            var form = new Form2(_rowCount2, _columnCount2);

            if (_matr2 is not null)
            {
                if (_rowCount2 == _matr2.GetLength(0)
                    && _columnCount2 == _matr2.GetLength(1))
                {
                    form.FromDataGrid(_matr2);
                }
            }

            _matr2 = form.FillMatr(_rowCount2, _columnCount2);

            label2.Text = "Введено";
            label2.ForeColor = Color.DarkGreen;
        }

        /// <summary>
        /// Умножение матриц.
        /// </summary>
        private void Button3_Click(object sender, EventArgs e)
        {
            if (!NotNullMatrix(_matr1, _matr2))
            {
                return;
            }

            var form = new Form3(_matr1.GetLength(0),
                                 _matr2.GetLength(1));

            if (_matr1.GetLength(1) == _matr2.GetLength(0))
            {
                _matr3 = new double[_matr1.GetLength(0),
                                      _matr2.GetLength(1)];

                for (int i = 0; i < _matr1.GetLength(0); i++)
                {
                    for (int j = 0; j < _matr2.GetLength(1); j++)
                    {
                        for (int k = 0; k < _matr2.GetLength(0); k++)
                        {
                            _matr3[i, j] += _matr1[i, k] *
                                              _matr2[k, j];
                        }
                    }
                }
            }
            else
            {
                _ = MessageBox.Show("Ошибка размерностей матрицы");
                return;
            }

            form.WindowSize(_rowCount1, _columnCount2);
            form.FromDataGrid(_matr3);

        }

        /// <summary>
        /// Сложение матриц.
        /// </summary>
        private void Button5_Click(object sender, EventArgs e)
        {
            if (!NotNullMatrix(_matr1, _matr2))
            {
                return;
            }

            if (!CompareDimension(_rowCount1, _rowCount2,
                                  _columnCount1, _columnCount2))
            {
                return;
            }

            var form = new Form3(_rowCount1, _columnCount1);
            _matr3 = new double[_rowCount1, _columnCount1];

            for (int i = 0; i < _rowCount1; i++)
            {
                for (int j = 0; j < _columnCount1; j++)
                {
                    _matr3[i, j] = _matr1[i, j] + _matr2[i, j];
                }
            }

            form.WindowSize(_rowCount1, _columnCount1);
            form.FromDataGrid(_matr3);
        }

        /// <summary>
        /// Вычитание матриц.
        /// </summary>
        private void Button6_Click(object sender, EventArgs e)
        {
            if (!NotNullMatrix(_matr1, _matr2))
            {
                return;
            }

            if (!CompareDimension(_rowCount1, _rowCount2,
                                  _columnCount1, _columnCount2))
            {
                return;
            }

            var form = new Form3(_rowCount1, _columnCount1);
            _matr3 = new double[_rowCount1, _columnCount1];

            for (int i = 0; i < _rowCount1; i++)
            {
                for (int j = 0; j < _columnCount1; j++)
                {
                    _matr3[i, j] = _matr1[i, j] - _matr2[i, j];
                }
            }

            form.WindowSize(_rowCount1, _columnCount1);
            form.FromDataGrid(_matr3);
        }

        /// <summary>
        /// Скалярное произведение векторов.
        /// </summary>
        private void Button8_Click(object sender, EventArgs e)
        {
            Form4 vector = new Form4();
            _ = vector.ShowDialog();
        }

        /// <summary>
        /// Проверка задания размерности.
        /// </summary>
        /// <param name="number">Number from textBox.</param>
        /// <returns>Bool.</returns>
        public bool EmptyTextBox(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                _ = MessageBox.Show("Заполните размерности матриц");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка на пустую матрицу.
        /// </summary>
        /// <param name="matr1">Матрица1.</param>
        /// <param name="matr2">Матрица2.</param>
        /// <returns>bool.</returns>
        public bool NotNullMatrix(double[,] matr1, double[,] matr2)
        {
            if (matr1 == null || matr2 == null)
            {
                _ = MessageBox.Show("Заполните матрицу");
                return false;
            }

            return true;
        }

        private bool CompareDimension(int row1, int row2, int col1, int col2)
        {
            if (row1 != row2 || col1 != col2)
            {
                _ = MessageBox.Show("Разные размерности матрицы");
                return false;
            }

            return true;
        }
    }
}
