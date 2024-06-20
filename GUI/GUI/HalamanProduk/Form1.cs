using GUIKeranjang;
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

namespace HalamanProduk
{
    public partial class Form1 : Form
    {
        DatabaseLibrary db = new DatabaseLibrary();
        public Form1(int idProduk)
        {
            InitializeComponent();
            db.Connect();
            LoadProductData(idProduk);
        }

        private void LoadProductData(int idProduk)
        {
            try
            {
                // Query untuk menggabungkan data dari tabel produk dan review berdasarkan idProduk
                string query = @"
                    SELECT p.nama, p.harga, p.stok, r.description
                    FROM produk p
                    LEFT JOIN review r ON p.Id = r.idProduk
                    WHERE p.Id = @idProduk";

                MySqlCommand cmd = new MySqlCommand(query, db.Connection);
                cmd.Parameters.AddWithValue("@idProduk", idProduk);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    NamaProduki.Text = reader["nama"].ToString();
                    Harga.Text = reader["harga"].ToString();
                    Stok.Text = reader["stok"].ToString();
                    Review.Text = reader["description"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.Disconnect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RuntimeJSON runtime = new RuntimeJSON();

            // Mendapatkan data produk yang dipilih
            string namaProduk = NamaProduki.Text;
            decimal harga = decimal.Parse(Harga.Text);
            int stok = int.Parse(Stok.Text);
            int id = GetProductIdByName(namaProduk); // Mengambil ID produk berdasarkan nama

            // Menambahkan produk ke keranjang menggunakan RuntimeJSON
            runtime.Products.Add(new RuntimeJSON.Product(id, namaProduk, harga, stok));
            runtime.WriteNewConfigFile(); // Menyimpan perubahan ke file JSON

            MessageBox.Show("Produk telah ditambahkan ke keranjang.");
        }

        private int GetProductIdByName(string productName)
        {
            DatabaseLibrary db = new DatabaseLibrary();
            int id = -1;

            try
            {
                db.Connect();
                string query = "SELECT Id FROM produk WHERE nama = @nama";
                MySqlCommand cmd = new MySqlCommand(query, db.Connection);
                cmd.Parameters.AddWithValue("@nama", productName);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    id = reader.GetInt32("Id");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.Disconnect();
            }
            return id;
        }

    }

    
}
