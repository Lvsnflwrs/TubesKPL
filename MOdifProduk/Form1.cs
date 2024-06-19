using System.Windows.Forms;
using static MOdifProduk.runtime;

namespace MOdifProduk
{
    public partial class Form1 : Form
    {
        private runtime runtimeInstance;
        private runtime.Product selectedProduct;

        public Form1()
        {
            InitializeComponent();
            runtimeInstance = new runtime();
            runtimeInstance.PopulateListBox(Mouse);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = namaProduk.Text;
                int stok = int.Parse(stokProduk.Text);
                decimal harga = decimal.Parse(HargaProduk.Text);

                runtime.Product newProduct = new runtime.Product
                {
                    Nama = nama,
                    Stok = stok,
                    Harga = harga
                };

                runtimeInstance.Products.Add(newProduct);
                runtimeInstance.WriteNewConfigFile();

                selectedProduct = null;
                namaProduk.Clear();
                stokProduk.Clear();
                HargaProduk.Clear();

                MessageBox.Show("Produk berhasil disimpan.");

                // Refresh the list box
                runtimeInstance.PopulateListBox(Mouse);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Mouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mouse.SelectedItem != null)
            {
                string selectedProductName = Mouse.SelectedItem.ToString();
                var selectedProduct = runtimeInstance.GetProductDetails(selectedProductName);

                if (selectedProduct != null)
                {
                    namaProduk.Text = selectedProduct.Nama;
                    stokProduk.Text = selectedProduct.Stok.ToString();
                    HargaProduk.Text = selectedProduct.Harga.ToString();
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string selectedProductName = Mouse.SelectedItem.ToString();
            var selectedProduct = runtimeInstance.GetProductDetails(selectedProductName);
            if (selectedProduct != null)
            {
                try
                {
                    selectedProduct.Nama = namaProduk.Text;
                    selectedProduct.Stok = int.Parse(stokProduk.Text);
                    selectedProduct.Harga = decimal.Parse(HargaProduk.Text);

                    runtimeInstance.WriteNewConfigFile();

                    MessageBox.Show("Produk berhasil diperbarui.");

                    // Refresh the list box
                    runtimeInstance.PopulateListBox(Mouse);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void namaProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void stokProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void HargaProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedProductName = Mouse.SelectedItem.ToString();
            var selectedProduct = runtimeInstance.GetProductDetails(selectedProductName);
            if (selectedProduct != null)
            {
                try
                {
                    runtimeInstance.Products.Remove(selectedProduct);
                    runtimeInstance.WriteNewConfigFile();

                    MessageBox.Show("Produk berhasil dihapus.");

                    // Refresh the list box
                    runtimeInstance.PopulateListBox(Mouse);

                    // textbox otomatis kosong
                    selectedProduct = null;
                    namaProduk.Clear();
                    stokProduk.Clear();
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
    }
}
