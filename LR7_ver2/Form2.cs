namespace LR7_ver2
{
    /// <summary>
    /// Form2.
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// Form2.
        /// </summary>
        /// <param name="row">Строки.</param>
        /// <param name="column">Столбцы.</param>
        public Form2(int row, int column)
        {
            InitializeComponent();
            Text = "Ввод матрицы";
            dataGridView1.RowCount = row;
            dataGridView1.ColumnCount = column;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            // WindowSize(row, column);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rnd.Next(-10, 10);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                }
            }
        }

        /// <summary>
        /// Проверка задания размерности.
        /// </summary>
        /// <param name="number">Number from textbox.</param>
        /// <returns>bool.</returns>
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
        /// Настройка размеров формы.
        /// </summary>
        /// <param name="rowMatr">Строки.</param>
        /// <param name="columnMatr">Столбцы.</param>
        public void WindowSize(int rowMatr, int columnMatr)
        {
            dataGridView1.RowCount = rowMatr;
            dataGridView1.ColumnCount = columnMatr;

            foreach (DataGridViewColumn column in
                     dataGridView1.Columns)
            {
                column.Width = 40;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 40;
            }

            dataGridView1.Height = rowMatr * 40 + 5;
            dataGridView1.Width = columnMatr * 40 + 5;
            Controls.Add(dataGridView1);

            // 4. Корректировка размеров формы
            Height = rowMatr * 40 + 130;

            if (columnMatr <= 8)
            {
                Width = 371;
            }
            else
            {
                Width = columnMatr * 40 + 50;
            }

        }

        /// <summary>
        /// Заполнение Матрицы.
        /// </summary>
        /// <param name="rowMatrix">Строки.</param>
        /// <param name="columnMatrix">Столбцы.</param>
        /// <returns>Матрица.</returns>
        public double[,] FillMatr(int rowMatrix, int columnMatrix)
        {
            WindowSize(rowMatrix, columnMatrix);

            // 6. Вызов формы Form2
            double[,] matrix = new double[rowMatrix, columnMatrix];
            if (ShowDialog() == DialogResult.OK)
            {
                var row = dataGridView1.RowCount;
                var column = dataGridView1.ColumnCount;

                // 7. Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        var value = dataGridView1.Rows[i].Cells[j].Value;
                        matrix[i, j] = value == null ? 0
                                    : Convert.ToInt32(value);
                    }
                }
            }

            return matrix;
        }

        /// <summary>
        /// Заполнение Матрицы 3 из DataGrid.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        public void FromDataGrid(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value =
                    matrix[i, j];
                }
            }
        }
    }
}
