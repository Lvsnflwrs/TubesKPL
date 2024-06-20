using HalamanUtama;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIWishlist
{
    public partial class Form1 : Form
    {
        private Database database = new Database();
        private List<String> produk = new List<String>();
        private int loginId;
        private MySqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
            deleteBtn.Visible = false;
            database.Connect();
            reader = database.View("SELECT * FROM login");
            try
            {
                if (reader.Read())
                {
                    loginId = reader.GetInt32("id");
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProduk.SelectedItems.Count > 0)
            {
                deleteBtn.Visible = true;
            }
            else
            {
                deleteBtn.Visible = false;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            listProduk.Items.Clear();
            database.Connect();
            reader = database.View("SELECT p.nama FROM wishlist w JOIN produk p ON w.idProduk = p.id WHERE w.idPembeli = " + loginId);
            try
            {
                while (reader.Read())
                {
                    listProduk.Items.Add(reader["nama"].ToString());
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (listProduk.SelectedItems.Count > 0)
            {
                string nama = listProduk.SelectedItem.ToString();
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
                        MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM wishlist WHERE idProduk = @id AND idPembeli = @loginId", database.Connection);
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        deleteCmd.Parameters.AddWithValue("@loginId", loginId);
                        deleteCmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Dihapus, Silahkan Perbarui List!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BackBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
