using System.IO;
using System.Text;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Reflection.Emit;

namespace LR7
{
    
    public partial class Form1 : Form
    {
        
        // ���������� ����� � ��������.
        private int _rowCount1;
        private int _rowCount2;
        private int _columnCount1;
        private int _columnCount2;

        // ���������� ������.
        private double[,] _Matr1;
        private double[,] _Matr2;
        private double[,] _Matr3;

        // ��������� ����� � �������.
        private bool _f1;
        private bool _f2;
        // ���������� ���������� ����.
        private Form2 _formMatr1;
        private Form2 _formMatr2;
        private Form3 _formMatr3;

        public Form1()
        {
            InitializeComponent();
            Text = "������ � ���������";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // ���������� ���������� ������ � ��������. �����.
            _f1 = _f2 = false;
            label1.Text = "�� �������";
            label1.ForeColor = Color.Yellow;
            label2.Text = "�� �������";
            label2.ForeColor = Color.Yellow;

            // �������� ����������� �����2
            _formMatr1 = new Form2();
            _formMatr2 = new Form2();

        }

        /// <summary>
        /// ���� ������� �
        /// (������� ������� ������).
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            // ������ ����������� �������
            if (string.IsNullOrEmpty(textBox1.Text) |
                string.IsNullOrEmpty(textBox2.Text))
            {
                _ = MessageBox.Show("��������� ����������� ������");
                return;
            }

            _rowCount1 = int.Parse(textBox1.Text);
            _columnCount1 = int.Parse(textBox2.Text);
            _Matr1 = EnterMatrix(_rowCount1, _columnCount1, _formMatr1);
            _f1 = true;
            label1.Text = "�������";
            label1.ForeColor = Color.LightGreen;

        }
        
        /// <summary>
        /// ���� ������� B
        /// (������� ������� ������).
        /// </summary>
        private void Button2_Click(object sender, EventArgs e)
        {

            // ������ ����������� �������
            if (string.IsNullOrEmpty(textBox3.Text) |
                string.IsNullOrEmpty(textBox4.Text))
            {
                _ = MessageBox.Show("��������� ����������� ������");
                return;
            }

            _rowCount2 = int.Parse(textBox3.Text);
            _columnCount2 = int.Parse(textBox4.Text);
            _Matr2 = EnterMatrix(_rowCount2, _columnCount2, _formMatr2);
            _f1 = true;
            label2.Text = "�������";
            label2.ForeColor = Color.LightGreen;
        }

        /// <summary>
        /// ��������� ������
        /// (������� ������� ������).
        /// </summary>
        private void Button3_Click(object sender, EventArgs e)
        {
            _formMatr3 = new Form3();
            if (_Matr1 != null && _Matr2 != null)
            {
                if (_Matr1.GetLength(1) == _Matr2.GetLength(0))
                {
                    _Matr3 = new double[_Matr1.GetLength(0),
                                          _Matr2.GetLength(1)];

                    for (int i = 0; i < _Matr1.GetLength(0); i++)
                    {
                        for (int j = 0; j < _Matr2.GetLength(1); j++)
                        {
                            for (int k = 0; k < _Matr2.GetLength(0); k++)
                            {
                                _Matr3[i, j] += _Matr1[i, k] *
                                                  _Matr2[k, j];
                            }
                        }
                    }
                }
                else
                {
                    _ = MessageBox.Show("������ ������������ ������� =(");
                }
            }
            else
            {
                _ = MessageBox.Show("��������� �������");
            }

            _formMatr3.dataGridView1.RowCount = Convert.ToInt32(_rowCount1);
            _formMatr3.dataGridView1.ColumnCount = Convert.ToInt32(_columnCount2);
            foreach (DataGridViewColumn column in
                     _formMatr3.dataGridView1.Columns)
            {
                column.Width = 40;
            }

            foreach (DataGridViewRow row in _formMatr3.dataGridView1.Rows)
            {
                row.Height = 40;
            }

            _formMatr3.dataGridView1.Height = _rowCount1 * 40 + 3;
            _formMatr3.dataGridView1.Width = _columnCount2 * 40 + 3;
            _formMatr3.Controls.Add(_formMatr3.dataGridView1);
            _formMatr3.Width = 10 + _rowCount1 * 40 + 225;
            _formMatr3.Height = 10 + _columnCount2 * 40 + 55;

            for (int i = 0; i < _Matr3.GetLength(0); i++)
            {
                for (int j = 0; j < _Matr3.GetLength(1); j++)
                {
                    _formMatr3.dataGridView1.Rows[i].Cells[j].Value =
                                                         _Matr3[i, j];
                }
            }

            _ = _formMatr3.ShowDialog();
        }

        /// <summary>
        /// ���������������� ������
        /// (������� ������� ������).
        /// </summary>
        private void Button7_Click(object sender, EventArgs e)
        {
            _formMatr3 = new Form3();

            // TODO: ������� ������
            _formMatr3.dataGridView1.RowCount = Convert.ToInt32(_columnCount1);
            _formMatr3.dataGridView1.ColumnCount = Convert.ToInt32(_rowCount1);
            foreach (DataGridViewColumn column in
                     _formMatr3.dataGridView1.Columns)
            {
                column.Width = 40;
            }

            foreach (DataGridViewRow row in _formMatr3.dataGridView1.Rows)
            {
                row.Height = 40;
            }

            _formMatr3.dataGridView1.Height = _columnCount1 * 40 + 3;
            _formMatr3.dataGridView1.Width = _rowCount1 * 40 + 3;
            _formMatr3.Controls.Add(_formMatr3.dataGridView1);
            _formMatr3.Width = 10 + _rowCount1 * 40 + 225;
            _formMatr3.Height = 10 + _columnCount1 * 40 + 55;

            // 1. ��������, ������� �� ������ � ����� ��������
            _Matr3 = new double[_columnCount1, _rowCount1];
            for (int i = 0; i < _columnCount1; i++)
            {
                for (int j = 0; j < _rowCount1; j++)
                {
                    _Matr3[i, j] = _Matr1[j, i];
                }
            }

            for (int i = 0; i < _Matr3.GetLength(0); i++)
            {
                for (int j = 0; j < _Matr3.GetLength(1); j++)
                {
                    _formMatr3.dataGridView1.Rows[i].Cells[j].Value =
                    _Matr3[i, j];
                }
            }

            _ = _formMatr3.ShowDialog();
        }

        /// <summary>
        /// �������� ������.
        /// (������� ������� ������).
        /// </summary>
        private void Button5_Click(object sender, EventArgs e)
        {
            _formMatr3 = new Form3();
            _formMatr3.dataGridView1.RowCount = Convert.ToInt32(_rowCount1);
            _formMatr3.dataGridView1.ColumnCount = Convert.ToInt32(_columnCount1);
            foreach (DataGridViewColumn column in
                     _formMatr3.dataGridView1.Columns)
            {
                column.Width = 40;
            }

            foreach (DataGridViewRow row in _formMatr3.dataGridView1.Rows)
            {
                row.Height = 40;
            }

            _formMatr3.dataGridView1.Height = _rowCount1 * 40 + 3;
            _formMatr3.dataGridView1.Width = _columnCount1 * 40 + 3;
            _formMatr3.Controls.Add(_formMatr3.dataGridView1);
            _formMatr3.Width = 10 + _columnCount1 * 40 + 225;
            _formMatr3.Height = 10 + _rowCount1 * 40 + 55;

            // 1. ��������, ������� �� ������ � ����� ��������
            // TODO: ������?? ����� null
            if (!(_f1 && _f1))
            {
                return;
            }

            // TODO: � ����� �������??
            bool matrixEmpty = !(_f1 && _f1);
            bool matricesEqual = _rowCount1 == _rowCount2 & _columnCount1 == _columnCount2;
            if (matrixEmpty | matricesEqual)
            {
                _ = MessageBox.Show("������ ����������� �������\n" +
                    "�������� �� �������� =(");
                return;
            }

            _Matr3 = new double[_rowCount1, _columnCount1];

            // TODO: ???
            Array.Clear(_Matr3, 0, _Matr3.Length);

            for (int i = 0; i < _rowCount1; i++)
            {
                for (int j = 0; j < _columnCount1; j++)
                {
                    _Matr3[i, j] = _Matr1[i, j] + _Matr2[i, j];
                }
            }

            for (int i = 0; i < _Matr3.GetLength(0); i++)
            {
                for (int j = 0; j < _Matr3.GetLength(1); j++)
                {
                    _formMatr3.dataGridView1.Rows[i].Cells[j].Value =
                    _Matr3[i, j];
                }
            }

            _ = _formMatr3.ShowDialog();
        }

        /// <summary>
        /// ��������� ������
        /// (������� ������� ������).
        /// </summary>
        private void Button6_Click(object sender, EventArgs e)
        {
            _formMatr3 = new Form3();

            // TODO: �������� � ������� ������������ �����
            _formMatr3.dataGridView1.RowCount = Convert.ToInt32(_rowCount1);
            _formMatr3.dataGridView1.ColumnCount = Convert.ToInt32(_columnCount1);
            foreach (DataGridViewColumn column in
                     _formMatr3.dataGridView1.Columns)
            {
                column.Width = 40;
            }

            foreach (DataGridViewRow row in _formMatr3.dataGridView1.Rows)
            {
                row.Height = 40;
            }

            _formMatr3.dataGridView1.Height = _rowCount1 * 40 + 3;
            _formMatr3.dataGridView1.Width = _columnCount1 * 40 + 3;
            _formMatr3.Controls.Add(_formMatr3.dataGridView1);
            _formMatr3.Width = 10 + _columnCount1 * 40 + 225;
            _formMatr3.Height = 10 + _rowCount1 * 40 + 55;

            // 1. ��������, ������� �� ������ � ����� ��������
            if (!((_f1) && (_f2)))
            {
                _ = MessageBox.Show("������� ������ � ��������");
                return;
            }

            if (_rowCount1 == _rowCount2 & _columnCount1 == _columnCount2)
            {
                _Matr3 = new double[_rowCount1, _columnCount1];
                Array.Clear(_Matr3, 0, _Matr3.Length);

                for (int i = 0; i < _rowCount1; i++)
                {
                    for (int j = 0; j < _columnCount1; j++)
                    {
                        _Matr3[i, j] = _Matr1[i, j] - _Matr2[i, j];
                    }
                }
            }
            else
            {
                _ = MessageBox.Show("������ ����������� �������");
                return;
            }

            for (int i = 0; i < _Matr3.GetLength(0); i++)
            {
                for (int j = 0; j < _Matr3.GetLength(1); j++)
                {
                    _formMatr3.dataGridView1.Rows[i].Cells[j].Value =
                    _Matr3[i, j];
                }
            }

            _ = _formMatr3.ShowDialog();
        }

        /// <summary>
        /// ��������� �����������
        /// (������� ����� �� ���� �����).
        /// </summary>
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            int nn = int.Parse(textBox1.Text);
            if (nn != _rowCount1)
            {
                _f1 = _f2 = false;
                label1.Text = "�� �������";
                label1.ForeColor = Color.Red;
                label2.Text = "�� �������";
                label2.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// ���� �������.
        /// </summary>
        private double[,] EnterMatrix(int n, int m, Form2 formMatrix)
        {
            // TODO: ����� ����� ������ ������
            // var form = new Form2();
            // TODO: �������� �����������
            formMatrix.dataGridView1.RowCount = Convert.ToInt32(n);
            formMatrix.dataGridView1.ColumnCount = Convert.ToInt32(m);
            foreach (DataGridViewColumn column in
                     formMatrix.dataGridView1.Columns)
            {
                column.Width = 40;
            }

            var rowCount = n;
            foreach (DataGridViewRow row in formMatrix.dataGridView1.Rows)
            {
                row.Height = 40;
            }

            formMatrix.dataGridView1.Height = n * 40 + 3;
            formMatrix.dataGridView1.Width = m * 40 + 3;
            formMatrix.Controls.Add(formMatrix.dataGridView1);

            // 4. ������������� �������� �����
            formMatrix.Width = 10 + m * 40 + 225;
            formMatrix.Height = 10 + n * 40 + 55;

            // 6. ����� ����� Form2
            double[,] matr = new double[n, m];
            if (formMatrix.ShowDialog() == DialogResult.Cancel)
            {
                // 7. ������� ����� �� ����� Form2 � ������� Matr1
                for (int i = 0; i < formMatrix.dataGridView1.RowCount; i++)
                {
                    for (int j = 0;
                             j < formMatrix.dataGridView1.ColumnCount;
                             j++)
                    {
                        if (string.IsNullOrEmpty(formMatrix.
                            dataGridView1.Rows[i].Cells[j].Value.ToString()))
                        {
                            matr[i, j] = 0;

                        }
                        else
                        {
                            matr[i, j] = Convert.ToInt32(formMatrix.dataGridView1.
                            Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }
            }

            return matr;
        }
    }
}