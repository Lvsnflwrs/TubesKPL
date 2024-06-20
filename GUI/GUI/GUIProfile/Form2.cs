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

namespace GUIProfile
{
    public partial class Form2 : Form
    {
        private Database database = new Database();
        private int loginId;
        private MySqlDataReader reader;
        public Form2()
        {
            InitializeComponent();
            // Menghubungkan ke database
            database.Connect();

            // Menjalankan query untuk mendapatkan data dari tabel "login"
            reader = database.View("SELECT * FROM login");

            try
            {
                // Membaca baris pertama dari hasil query
                if (reader.Read())
                {
                    // Mengambil nilai kolom "id" dari hasil query dan menyimpannya di variabel loginId
                    loginId = reader.GetInt32("id");
                }
            }
            catch (MySqlException ex)
            {
                // Menangani kesalahan MySQL dan mencetak pesan kesalahan ke console
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Menutup reader untuk membebaskan sumber daya
                reader.Close();

                // Memutuskan koneksi ke database
                database.Disconnect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = EditNama.Text;
            string phoneInput = EditPhone.Text;
            string address = EditAddress.Text;

            // Validasi input kosong
            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(phoneInput) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Data tidak boleh kosong!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validasi input phone berupa angka
            if (!int.TryParse(phoneInput, out int phone))
            {
                MessageBox.Show("Nomor telepon harus berupa angka!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Menghubungkan ke database
                database.Connect();

                // Menyiapkan perintah SQL untuk mengupdate data
                MySqlCommand editCmd = new MySqlCommand("UPDATE pembeli SET nama = @nama, noTelp = @phone, alamat = @address WHERE id = @id", database.Connection);
                editCmd.Parameters.AddWithValue("@id", loginId);
                editCmd.Parameters.AddWithValue("@nama", nama);
                editCmd.Parameters.AddWithValue("@phone", phone);
                editCmd.Parameters.AddWithValue("@address", address);

                // Eksekusi perintah SQL
                editCmd.ExecuteNonQuery();

                // Menampilkan Form1 dan menutup form saat ini
                Form1 profileForm = new Form1();
                profileForm.Show();
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Menutup koneksi ke database
                database.Disconnect();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
