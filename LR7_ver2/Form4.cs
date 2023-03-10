namespace LR7_ver2
{
    /// <summary>
    /// Form4.
    /// </summary>
    public partial class Form4 : Form
    {
        private int _dimension;
        private int _row;

        private double[,] _vector1;
        private double[,] _vector2;
        private double[,] _result;

        /// <summary>
        /// Form4.
        /// </summary>
        public Form4()
        {
            InitializeComponent();
            Text = "Скалярное произведение векторов";
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;

            label3.Text = "Не введено";
            label3.ForeColor = Color.DarkRed;
            label4.Text = "Не введено";
            label4.ForeColor = Color.DarkRed;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var form = new Form2(_row, _dimension);

            if (!form.EmptyTextBox(textBox1.Text))
            {
                return;
            }

            _dimension = int.Parse(textBox1.Text);
            _row = 1;

            if (_vector1 is not null)
            {
                if (_row == _vector1.GetLength(0)
                    && _dimension == _vector1.GetLength(1))
                {
                    form.FromDataGrid(_vector1);
                }
            }

            _vector1 = form.FillMatr(_row, _dimension);

            label3.Text = "Введено";
            label3.ForeColor = Color.DarkGreen;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var form = new Form2(_row, _dimension);

            if (!form.EmptyTextBox(textBox1.Text))
            {
                return;
            }

            _dimension = int.Parse(textBox1.Text);
            _row = 1;

            if (_vector2 is not null)
            {
                if (_row == _vector2.GetLength(0)
                    && _dimension == _vector2.GetLength(1))
                {
                    form.FromDataGrid(_vector2);
                }
            }

            _vector2 = form.FillMatr(_row, _dimension);

            label4.Text = "Введено";
            label4.ForeColor = Color.DarkGreen;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            if (!form.NotNullMatrix(_vector1, _vector2))
            {
                return;
            }

            _result = new double[_row, _dimension];
            double a = 0;
            for (int j = 0; j < _dimension; j++)
            {
                int i = 0;
                _result[i, j] = _vector1[i, j] * _vector2[i, j];
                a += _result[i, j];
            }

            textBox2.Text = $"{a}";
        }
    }
}
