using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Review
{
    public partial class Form2 : Form
    {
        private String namaProduk;
        private int hargaProduk;

        public Form2(String namaProduk, int hargaProduk)
        {
            InitializeComponent();

            this.namaProduk = namaProduk;
            this.hargaProduk = hargaProduk;

            label2.Text = namaProduk;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        public void SetTextBox1(string rate)
        {
            textBox1.Text = rate;
        }

        public void SetTextBox2(string review)
        {
            textBox2.Text = review;
        }
    }
}
