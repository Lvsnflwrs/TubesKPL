using Microsoft.VisualBasic.Devices;
using NVelocity.Runtime;
using System;
using System.Windows.Forms;

namespace HalamanToko
{
    public partial class Form1 : Form
    {

        private runtime<Product> runtimeInstance;
        private Product selectedProduct;
        public Form1()
        {
            InitializeComponent();
            runtimeInstance = new runtime<Product>(@"D:\Konstruksi Perangkat Lunak\HalamanToko\json\DataProduk.json");
            PopulateListBox();
        }
        
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NamaProduk_Click(object sender, EventArgs e)
        {

        }

        private void HargaProduk_Click(object sender, EventArgs e)
        {

        }

        private void StokProduk_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedProductName = listBox1.SelectedItem.ToString();
                var selectedProduct = runtimeInstance.GetItemDetails(p => p.Nama == selectedProductName);

                if (selectedProduct != null)
                {
                    NamaProduk.Text = selectedProduct.Nama;
                    StokProduk.Text = selectedProduct.Stok.ToString();
                    HargaProduk.Text = selectedProduct.Harga.ToString();
                }
            }
        }
        private void PopulateListBox()
        {
            runtimeInstance.PopulateListBox(listBox1, p => p.Nama);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Menyembunyikan form halaman toko dan menampilkan form modifikasi produk
            Form Modif = new MOdifProduk.Form1();
            Modif.Show();
            this.Hide();
        }
       
    }
}
