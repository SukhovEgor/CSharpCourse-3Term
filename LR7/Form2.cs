using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Text = "Ввод матрицы";
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            button1.Text = "OK";
                        
        }

        public void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
