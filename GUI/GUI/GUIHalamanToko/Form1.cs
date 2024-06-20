using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIHalamanToko
{
    public partial class Form1 : Form
    {
        private Runtime<Product> runtimeInstance;
        public Form1()
        {
            InitializeComponent();
            runtimeInstance = new Runtime<Product>(@"D:\COOLYEAH\Semester 4\KPL\TubesNew\Json\ProdData.json", "Products");
            PopulateListBox();
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

        private void ModifikasiButton_Click(object sender, EventArgs e)
        {
            Form Modif = new GUIModifikasiProduk.Form1();
            Modif.Show();
            this.Hide();
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
    }
}
