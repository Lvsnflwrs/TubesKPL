using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIKeranjang;


namespace HalamanUtama
{
    public partial class Form1 : Form
    {
        private RuntimeJSON runtime = new RuntimeJSON();
        private RuntimeJSON.Product selectedProduct;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataToListBox();
            AddWishlist.Visible = false;
            AddKeranjang.Visible = false;
            this.Click += new EventHandler(pictureBox1_Click);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddWishlist.Visible = false;
            AddKeranjang.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                AddWishlist.Visible = true;
                AddKeranjang.Visible = true;

                Database db = new Database();
                db.Connect();

                string query = "SELECT id, nama, harga, stok FROM produk WHERE nama = @nama";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@nama", listBox1.SelectedItem.ToString());

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    selectedProduct = new RuntimeJSON.Product
                    {
                        Id = reader.GetInt32("id"),
                        Nama = reader.GetString("nama"),
                        Harga = reader.GetDecimal("harga"),
                        Stok = reader.GetInt32("stok")
                    };

                    Console.WriteLine($"Product selected: {selectedProduct.Nama}, {selectedProduct.Harga}, {selectedProduct.Stok}");
                    MessageBox.Show($"Product selected: {selectedProduct.Nama}, {selectedProduct.Harga}, {selectedProduct.Stok}");
                }

                reader.Close();
                db.Disconnect();
            }
        }

        private void LoadDataToListBox()
        {
            listBox1.Items.Clear();

            Database db = new Database();
            db.Connect();

            string query = "SELECT nama FROM produk";
            MySqlDataReader reader = db.View(query);

            while (reader.Read())
            {
                listBox1.Items.Add(reader["nama"].ToString());
            }

            reader.Close();
            db.Disconnect();
        }

        private void wishlist_Click(object sender, EventArgs e)
        {

        }

        private void Keranjang_Click(object sender, EventArgs e)
        {
            // Menyembunyikan form saat ini dan menampilkan form Keranjang
            Form KeranjangForm = new GUIKeranjang.Form1();
            KeranjangForm.Show();
            this.Hide();
        }

        private void AddKeranjang_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
            {
                // Menambahkan produk yang dipilih ke dalam list produk di RuntimeJSON
                runtime.Products.Add(selectedProduct);
                runtime.WriteNewConfigFile();

                Console.WriteLine("Product added to cart and written to file.");
                MessageBox.Show("Product added to cart and written to file.");
            }
            else
            {
                MessageBox.Show("Please select a product from the list first.");
            }
        }

        private void AddWishlist_Click(object sender, EventArgs e)
        {

        }

        public class RuntimeJSONService
        {
            private RuntimeJSON runtime = new RuntimeJSON();

            public RuntimeJSON.Product[] GetProducts()
            {
                return runtime.ReadConfigFile();
            }
        }
    }
}
