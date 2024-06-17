using System;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Collections.Generic;

namespace Login
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            // Menambahkan event handler untuk menutup aplikasi saat form ditutup
            this.FormClosing += new FormClosingEventHandler(Login_FormClosing);
            checkBoxSignUp.CheckedChanged += checkBoxSignUp_CheckedChanged; // Menghubungkan event handler
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Menutup aplikasi saat form Sign Up ditutup
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Tombol untuk berpindah ke form Login
            Login loginForm = new Login();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();
            this.Hide(); // Menyembunyikan form sign up saat ini
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            // Proses pembuatan pengguna baru
            BuatPengguna();
        }

        private void BuatPengguna()
        {
            // Mengambil nilai dari input pengguna
            string namaBaru = fname.Text.Trim();
            string noTelpBaru = NoTelp.Text.Trim();
            string passBaru = pass.Text.Trim();

            // Menyimpan data form dalam dictionary
            var dataForm = new Dictionary<string, string>
            {
                { "NamaPengguna", namaBaru },
                { "NomorTelepon", noTelpBaru },
                { "KataSandi", passBaru }
            };

            // Memvalidasi form, jika tidak valid tampilkan pesan error
            if (!FormValid(dataForm))
            {
                return;
            }

            try
            {
                // Mendaftarkan pengguna baru jika semua validasi berhasil
                DaftarkanPenggunaBaru(namaBaru, noTelpBaru, passBaru);
                MessageBox.Show("Akun baru berhasil dibuat!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Menangani kesalahan saat proses pendaftaran
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FormValid(Dictionary<string, string> dataForm)
        {
            // Menyusun aturan validasi dalam bentuk list tuple
            var aturanValidasi = new List<(Func<string, bool> aturan, string bidang, string pesan)>
            {
                // Validasi nama pengguna
                (data => !string.IsNullOrEmpty(data), "NamaPengguna", "Nama pengguna lengkap wajib diisi"),
                (data => data.Length >= 8 && data.Length <= 20, "NamaPengguna", "Nama pengguna harus lebih dari 8 karakter dan tidak boleh lebih dari 20 karakter"),
                (data => data.Any(char.IsDigit), "NamaPengguna", "Nama pengguna harus mengandung setidaknya satu angka"),
                
                // Validasi nomor telepon
                (data => !string.IsNullOrEmpty(data), "NomorTelepon", "Nomor telepon wajib diisi"),
                
                // Validasi kata sandi
                (data => !string.IsNullOrEmpty(data), "KataSandi", "Kata sandi wajib diisi"),
                (data => data.Length >= 8, "KataSandi", "Kata sandi kurang dari 8 karakter"),
                (data => !data.Equals(dataForm["NamaPengguna"], StringComparison.OrdinalIgnoreCase), "KataSandi", "Kata sandi tidak boleh sama dengan nama pengguna"),
                (data => MengandungKarakterUnik(data), "KataSandi", "Kata sandi harus mengandung karakter unik")
            };

            // Melakukan iterasi pada setiap aturan validasi
            foreach (var (aturan, bidang, pesan) in aturanValidasi)
            {
                // Jika ada validasi yang gagal, tampilkan pesan error dan return false
                if (!aturan(dataForm[bidang]))
                {
                    TampilkanError(pesan);
                    return false;
                }
            }

            // Jika semua validasi berhasil, return true
            return true;
        }

        private void TampilkanError(string pesan)
        {
            // Menampilkan pesan error kepada pengguna
            MessageBox.Show(pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool MengandungKarakterUnik(string kataSandi)
        {
            // Memeriksa apakah kata sandi mengandung karakter unik
            return kataSandi.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private void DaftarkanPenggunaBaru(string namaPengguna, string nomorTelepon, string kataSandi)
        {
            // Koneksi ke database MySQL
            string connectionString = "server=localhost;database=tubes;uid=root;pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // Hash kata sandi menggunakan BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(kataSandi);
                // Query untuk memasukkan data pengguna baru
                string query = "INSERT INTO pembeli(nama, password, noTelp, alamat) VALUES (@nama, @password, @noTelp, 'null')";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Menambahkan parameter untuk query
                    cmd.Parameters.AddWithValue("@nama", namaPengguna);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@noTelp", nomorTelepon);
                    // Menjalankan query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Event handler untuk CheckBox
        private void checkBoxSignUp_CheckedChanged(object sender, EventArgs e)
        {
            // Jika CheckBox diperiksa, tampilkan teks password
            // Jika tidak, gunakan karakter pengganti password (*)
            pass.UseSystemPasswordChar = !checkBoxSignUp.Checked;
        }
    }
}
