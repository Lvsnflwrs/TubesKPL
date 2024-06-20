using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaymentLibrary_;


namespace Payment
{
    public partial class Form1 : Form
    {
        // Properti untuk menyimpan informasi produk
        private String _namaProduk;
        private int _hargaProduk;
        private int _jumlah;

        // Constructor untuk menginisialisasi form dengan data produk
        public Form1(String namaproduk, int hargaproduk, int jumlahproduk)
        {
            InitializeComponent();
            this._namaProduk = namaproduk;
            this._hargaProduk = hargaproduk;
            this._jumlah = jumlahproduk;
            getSubtotal(hargaproduk, jumlahproduk);
        }

        // Method untuk menghitung subtotal, diskon, pajak, dan total pembayaran
        private void getSubtotal(int hargaProduk, int jumlah)
        {
            double subtotal, discount, tax, total;

            subtotal = PaymentCalculator.subtotal(hargaProduk, jumlah);
            label6.Text = subtotal.ToString("F2");
            discount = PaymentCalculator.discount(subtotal);
            label7.Text = discount.ToString("F2");
            tax = PaymentCalculator.tax(subtotal);
            label8.Text = tax.ToString("F2");
            total = PaymentCalculator.Total(subtotal,discount,tax); 
            label9.Text = total.ToString("F2");
        }

        // Event handler untuk memilih method pembayaran
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPaymentMethod = comboBox1.SelectedItem.ToString();
            switch (selectedPaymentMethod)
            {
                case "Debit Card":
                    pictureBox3.Image = Properties.Resources.debit_card_bni_1;
                    break;
                case "Credit Card":
                    pictureBox3.Image = Properties.Resources.credit;
                    break;
                case "Ewallet":
                    pictureBox3.Image = Properties.Resources.ewallet;
                    break;
                default:
                    MessageBox.Show("Pilihan tidak valid");
                    break;
            }

        }

        // Event handler untuk tombol pembayaran
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 paid = new Form2();
            paid.Show();
            this.Hide();

            // Mengatur timer untuk membuka form3 setelah 3 detik
            Timer timer = new Timer();
            timer.Interval = 3000; 
            timer.Tick += (s, args) =>
            {
                paid.Dispose(); 
                Form3 frame3 = new Form3(); 
                frame3.Show(); 
                timer.Stop(); 
            };
            timer.Start();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
