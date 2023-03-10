using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7
{
    public partial class Form3 : Form
    {
        private string _pathResult = @"C:\Users\sukho\Desktop\Новая папка\Res_Matr.txt";

        /// <summary>
        /// инициализация формы 3.
        /// </summary>
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Все посчиталось. Ура!\n");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            double[,] matr = new double[dataGridView1.RowCount,
                            dataGridView1.ColumnCount];

            // Перенос строк из формы Form2 в матрицу Matr1
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    var value = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    matr[i, j] = string.IsNullOrWhiteSpace(value) ?
                        0 : Convert.ToInt32(value);
                }
            }

            // TODO: using
            // TODO: streamwriter
            // 1. Открыть файл для записи
            var file = new FileStream
                           (_pathResult
                            , FileMode.Create);

            // Число элементов матрицы Matr3
            string msg = "Кол-во эл-ов матрицы" +
                         matr.Length.ToString() + "\n\n";

            // перевод строки msg в байтовый массив msgByte
            var msgByte = Encoding.Default.GetBytes(msg);

            // запись массива msgByte в файл
            file.Write(msgByte, 0, msgByte.Length);

            // 2.2. Теперь записать саму матрицу
            msg = "";
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                // формируем строку msg из элементов матрицы
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    msg = msg + matr[i, j].ToString() + "  ";
                }

                msg += "\r\n"; // добавить перевод строки
            }

            // 3. Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // 4. запись строк матрицы в файл
            file.Write(msgByte, 0, msgByte.Length);

            // 5. Закрыть файл
            file.Close();
            _ = MessageBox.Show("Файл успешно записан");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
