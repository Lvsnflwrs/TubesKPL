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
        // Properti untuk menyimpan informasi produk
        private String _namaProduk;
        private int _hargaProduk;

        //constructor untuk menginisialisasi form dengan data produk
        public Form2(String namaProduk, int hargaProduk)
        {
            InitializeComponent();

            this._namaProduk = namaProduk;
            this._hargaProduk = hargaProduk;

            label2.Text = namaProduk;
        }

        // Metode untuk mengatur nilai TextBox1 dengan nilai rate yang diberikan.
        public void SetTextBox1(string rate)
        {
            textBox1.Text = rate;
        }

        //Metode untuk mengatur nilai TextBox2 dengan nilai review yang diberikan.
        public void SetTextBox2(string review)
        {
            textBox2.Text = review;
        }

        // Event handler untuk click button1 kembali ke halaman sebelumnya.
        private void button1_Click(object sender, EventArgs e)
        {
            //backbutton
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
    }
}
