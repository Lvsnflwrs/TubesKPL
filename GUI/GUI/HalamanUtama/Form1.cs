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
        private Database database = new Database();
        private MySqlDataReader reader;
        private int loginId;

        public Form1()
        {
            InitializeComponent();
            database.Connect();
            reader = database.View("SELECT * FROM login");
            try
            {
                if (reader.Read())
                {
                    loginId = reader.GetInt32("id");
                }

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM penjual WHERE id = @id", database.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", loginId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            halTokoButtton.Visible = true;
                            bukTokoButton.Visible = false;
                        }
                        else
                        {
                            halTokoButtton.Visible = false;
                            bukTokoButton.Visible = true;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
                database.Disconnect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataToListBox();
            AddWishlist.Visible = false;
            AddKeranjang.Visible = false;
            this.Click += new EventHandler(pictureBox1_Click);
            listBox1.DoubleClick += new EventHandler(listBox1_DoubleClick);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddWishlist.Visible = false;
            AddKeranjang.Visible = false;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Database db = new Database();
                db.Connect();

                string query = "SELECT Id FROM produk WHERE nama = @nama";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@nama", listBox1.SelectedItem.ToString());

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int idProduk = reader.GetInt32("Id");
                    db.Disconnect();

                    HalamanProduk.Form1 produkForm = new HalamanProduk.Form1(idProduk);
                    produkForm.Show();
                    this.Hide();
                }

                reader.Close();
                db.Disconnect();
            }
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
            Form wishlist = new GUIWishlist.Form1();
            wishlist.Show();
            this.Hide();
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
            if (listBox1.SelectedItems.Count > 0)
            {
                string nama = listBox1.SelectedItem.ToString();

                database.Connect();
                MySqlCommand cmd = new MySqlCommand("SELECT Id FROM produk WHERE nama = @nama", database.Connection);
                cmd.Parameters.AddWithValue("@nama", nama);

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        reader.Close();
                        MySqlCommand insertCmd = new MySqlCommand("INSERT INTO wishlist(idPembeli, idProduk) VALUES(@loginId, @id) ", database.Connection);

                        insertCmd.Parameters.AddWithValue("@id", id);
                        insertCmd.Parameters.AddWithValue("@loginId", loginId);
                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Data Berhasil Ditambah!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }
                    database.Disconnect();
                }
            }
            else
            {
                MessageBox.Show("Belum memilih item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public class RuntimeJSONService
        {
            private RuntimeJSON runtime = new RuntimeJSON();

            public RuntimeJSON.Product[] GetProducts()
            {
                return runtime.ReadConfigFile();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form profile = new GUIProfile.Form1();
            profile.Show();
            this.Hide();
        }

        private void SearchButt_Click(object sender, EventArgs e)
        {
            string productName = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(productName))
            {
                int idProduk = GetProductIdByName(productName);

                if (idProduk != -1)
                {
                    // Menyiapkan dan menampilkan halaman produk
                    HalamanProduk.Form1 produkForm = new HalamanProduk.Form1(idProduk);
                    produkForm.Show();
                    this.Hide(); // Menyembunyikan form utama saat ini
                }
                else
                {
                    MessageBox.Show("Produk tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Silakan masukkan nama produk untuk mencari.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private int GetProductIdByName(string productName)
        {
            Database db = new Database();
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

        private void bukTokoButton_Click(object sender, EventArgs e)
        {
            database.Connect();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM penjual WHERE id = @id", database.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", loginId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("Anda telah terdaftar sebagai penjual!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MySqlCommand insertCmd = new MySqlCommand("INSERT INTO penjual(id) VALUES(@loginId) ", database.Connection);
                            insertCmd.Parameters.AddWithValue("@loginId", loginId);
                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("Anda berhasil terdaftar sebagai penjual!!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Disconnect();
            }
        }

        private void halTokoButtton_Click(object sender, EventArgs e)
        {
            Form HalUtama = new GUIHalamanToko.Form1();
            HalUtama.Show();
            this.Hide();
        }
    }
}
