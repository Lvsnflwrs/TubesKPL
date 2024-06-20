using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIModifikasiProduk
{
    public partial class Form1 : Form
    {
        private Runtime runtimeInstance;
        private Runtime.Product selectedProduct;
        public Form1()
        {
            InitializeComponent();
            runtimeInstance = new Runtime();
            runtimeInstance.PopulateListBox(listBox1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TambahButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = NamaProduk.Text;
                int stok = int.Parse(StokProduk.Text);
                decimal harga = decimal.Parse(HargaProduk.Text);

                Runtime.Product newProduct = new Runtime.Product
                {
                    Nama = nama,
                    Stok = stok,
                    Harga = harga
                };

                runtimeInstance.Products.Add(newProduct);
                runtimeInstance.WriteNewConfigFile();

                selectedProduct = null;
                NamaProduk.Clear();
                StokProduk.Clear();
                HargaProduk.Clear();

                MessageBox.Show("Produk berhasil disimpan.");

                runtimeInstance.PopulateListBox(listBox1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string selectedProductName = listBox1.SelectedItem.ToString();
            var selectedProduct = runtimeInstance.GetProductDetails(selectedProductName);
            if (selectedProduct != null)
            {
                try
                {
                    selectedProduct.Nama = NamaProduk.Text;
                    selectedProduct.Stok = int.Parse(StokProduk.Text);
                    selectedProduct.Harga = decimal.Parse(HargaProduk.Text);

                    runtimeInstance.WriteNewConfigFile();

                    MessageBox.Show("Produk berhasil diperbarui.");

                    runtimeInstance.PopulateListBox(listBox1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Tidak ada produk yang dipilih untuk diperbarui.");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string selectedProductName = listBox1.SelectedItem.ToString();
            var selectedProduct = runtimeInstance.GetProductDetails(selectedProductName);
            if (selectedProduct != null)
            {
                try
                {
                    runtimeInstance.Products.Remove(selectedProduct);
                    runtimeInstance.WriteNewConfigFile();

                    MessageBox.Show("Produk berhasil dihapus.");

                    // Refresh the list box
                    runtimeInstance.PopulateListBox(listBox1);

                    // textbox otomatis kosong
                    selectedProduct = null;
                    NamaProduk.Clear();
                    StokProduk.Clear();
                    HargaProduk.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Tidak ada produk yang dipilih untuk dihapus.");
            }
        }

        private void NamaProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void HargaProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void StokProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedProductName = listBox1.SelectedItem.ToString();
                var selectedProduct = runtimeInstance.GetProductDetails(selectedProductName);

                if (selectedProduct != null)
                {
                    NamaProduk.Text = selectedProduct.Nama;
                    StokProduk.Text = selectedProduct.Stok.ToString();
                    HargaProduk.Text = selectedProduct.Harga.ToString();
                }
            }
        }
    }
}
