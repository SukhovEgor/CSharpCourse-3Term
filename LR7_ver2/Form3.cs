namespace LR7_ver2
{
    /// <summary>
    /// Form3.
    /// </summary>
    public partial class Form3 : Form
    {
        /// <summary>
        /// Form3.
        /// </summary>
        /// <param name="row">Строка.</param>
        /// <param name="column">Столбец.</param>
        public Form3(int row, int column)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataGridView1.RowCount = row;
            dataGridView1.ColumnCount = column;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double[,] matrix = new double[dataGridView1.RowCount,
                           dataGridView1.ColumnCount];

            // Перенос строк из формы Form2 в матрицу Matr1
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    var va = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    matrix[i, j] = string.IsNullOrWhiteSpace(va) ?
                        0 : Convert.ToInt32(va);
                }
            }

            // Настройка saveFileDialog
            saveFileDialog1.Filter =
                "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "MatrixResult";
            _ = saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("Результат операции:");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        writer.Write($"{matrix[i, j]}  |");
                    }

                    writer.WriteLine();
                }
            }

            _ = MessageBox.Show("Файл успешно сохранен");
        }

        /// <summary>
        /// Заполнение Матрицы 3 из DataGrid.
        /// </summary>
        /// <param name="matrix">Матрица3.</param>
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

            _ = ShowDialog();
        }

        /// <summary>
        /// Настройки размеров формы.
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

            if (columnMatr <= 8)
            {
                Width = 307;
            }
            else
            {
                Width = columnMatr * 40 + 50;
            }

            Height = rowMatr * 40 + 130;
        }
    }
}
