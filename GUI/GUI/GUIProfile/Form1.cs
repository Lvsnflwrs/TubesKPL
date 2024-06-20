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
    public partial class Form1 : Form
    {
        private Database database = new Database();
        private int loginId;
        private MySqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
            try
            {
                // Menghubungkan ke database
                database.Connect();

                // Menjalankan query untuk mendapatkan data dari tabel "login" dan menggunakan 'using' untuk memastikan MySqlDataReader ditutup dengan benar
                using (MySqlDataReader reader = database.View("SELECT * FROM login"))
                {
                    // Membaca baris pertama dari hasil query
                    if (reader.Read())
                    {
                        // Mengambil nilai kolom "id" dari hasil query dan menyimpannya di variabel loginId
                        loginId = reader.GetInt32("id");
                    }
                }

                // Menyiapkan perintah SQL untuk mengambil data dari tabel "pembeli" dengan id yang diperoleh sebelumnya
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM pembeli WHERE id = @id", database.Connection))
                {
                    // Menambahkan parameter untuk perintah SQL
                    cmd.Parameters.AddWithValue("@id", loginId);

                    // Menjalankan perintah SQL dan menggunakan 'using' untuk memastikan MySqlDataReader ditutup dengan benar
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Membaca baris pertama dari hasil query
                        if (reader.Read())
                        {
                            // Mengambil nilai kolom "nama", "noTelp", dan "alamat" dari hasil query dan menampilkan di kontrol terkait
                            NameBox.Text = reader.GetString("nama");
                            PhoneBox.Text = reader.GetInt64("noTelp").ToString();
                            AddressBox.Text = reader.GetString("alamat");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Menangani kesalahan MySQL dan menampilkan pesan kesalahan
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Memutuskan koneksi ke database
                database.Disconnect();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            // Menghubungkan ke database
            database.Connect();

            // Menyiapkan perintah SQL untuk menghapus data dari tabel "login" berdasarkan "id"
            MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM login WHERE id = @id", database.Connection);

            // Menambahkan parameter "id" ke perintah SQL
            deleteCmd.Parameters.AddWithValue("@id", loginId);

            // Memutuskan koneksi ke database
            database.Disconnect();

            // Menutup form saat ini
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 editForm = new Form2();
            editForm.Show();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
