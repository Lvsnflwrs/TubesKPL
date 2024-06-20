using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIKeranjang
{
    public partial class Form1 : Form
    {
        private RuntimeJSON runtime = new RuntimeJSON();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string productName = listBox1.SelectedItem.ToString();
                RuntimeJSON.Product selectedProduct = runtime.GetProductDetails(productName);

                if (selectedProduct != null)
                {
                    MessageBox.Show($"Nama: {selectedProduct.Nama}\nHarga: {selectedProduct.Harga}\nStok: {selectedProduct.Stok}");
                }
                else
                {
                    MessageBox.Show("Produk tidak ditemukan.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            runtime.PopulateListBox(listBox1);
        }
    }

}

