using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormClosing += Login_FormClosing;
            checkBoxLogin.CheckedChanged += checkBoxLogin_CheckedChanged; // Menghubungkan event handler
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tombol untuk signup
            SignUp signupForm = new SignUp();
            signupForm.StartPosition = FormStartPosition.CenterScreen;
            signupForm.Show();
            this.Hide(); // Menyembunyikan form login saat ini
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string passwordInput = password.Text;

            if (string.IsNullOrEmpty(username))
            {
                TampilkanError("Username wajib diisi");
                return;
            }
            else if (string.IsNullOrEmpty(passwordInput))
            {
                TampilkanError("Password wajib diisi");
                return;
            }

            string connectionString = "server=localhost;database=tubes;uid=root;pwd=;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT password FROM pembeli WHERE nama = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["password"]?.ToString();
                                if (BCrypt.Net.BCrypt.Verify(passwordInput, storedHash))
                                {
                                    TampilkanPesan("Login berhasil", "Informasi", MessageBoxIcon.Information);
                                }
                                else
                                {
                                    TampilkanError("Username atau password salah");
                                }
                            }
                            else
                            {
                                TampilkanError("Username atau password salah");
                            }
                        }
                    }
                    password.Text = ""; // Membersihkan field password setelah digunakan
                    Username.Text = ""; // Membersihkan field username setelah digunakan
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
                TampilkanError("Terjadi kesalahan saat proses login");
            }
        }
        // Metode untuk menampilkan pesan error
        private void TampilkanError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Metode untuk menampilkan pesan informasi
        private void TampilkanPesan(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }

        // Event handler untuk CheckBox
        private void checkBoxLogin_CheckedChanged(object sender, EventArgs e)
        {
            // Jika CheckBox diperiksa, tampilkan teks password
            // Jika tidak, gunakan karakter pengganti password (*)
            password.UseSystemPasswordChar = !checkBoxLogin.Checked;
        }
    }
}
