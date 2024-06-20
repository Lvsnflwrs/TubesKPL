using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Review
{
    public partial class Form1 : Form
    {
        // Properti untuk menyimpan informasi produk
        private String namaProduk;
        private int hargaProduk;

        //constructor untuk menginisialisasi form dengan data produk
        public Form1(String namaProduk, int hargaProduk)
        {
            InitializeComponent();

            this.namaProduk = namaProduk;
            this.hargaProduk = hargaProduk;

            label5.Text = namaProduk;
            label6.Text = hargaProduk.ToString();
        }

        //Internal class untuk mendeteksi spam berdasarkan dari review.
        internal class SpamDetector
        {
            // Enumerasi yang mewakili kemungkinan status spam pada deskripsi review.
            public enum State { Start, PossibleSpam, CertainSpam, NotSpam };

            // Variabel untuk menyimpan status spam saat ini.
            private State currentState;

            // Menginisialisasi status spam saat ini ke Start.
            public SpamDetector()
            {
                currentState = State.Start;
            }

            // Method untuk mendeteksi apakah review spam atau tidak.
            public bool DetectSpam(string review)
            {
                // Ubah review menjadi lowercase dan pecah menjadi kata-kata
                string[] words = review.ToLower().Split(' ');

                foreach (string word in words)
                {
                    Dictionary<char, int> charCount = new Dictionary<char, int>();

                    foreach (char c in word)
                    {
                        if (charCount.ContainsKey(c))
                        {
                            charCount[c]++;
                        }
                        else
                        {
                            charCount[c] = 1;
                        }

                        // Jika ada karakter yang muncul lebih dari 2 kali, transisi ke CertainSpam
                        if (charCount[c] > 2)
                        {
                            currentState = State.CertainSpam;
                            return true; // Jika ada karakter yang muncul lebih dari 2 kali, dianggap sebagai spam
                        }
                    }

                    // Jika kata memiliki karakter yang diulang dua kali, transisi ke PossibleSpam
                    if (charCount.Values.Any(count => count == 2))
                    {
                        currentState = State.PossibleSpam;
                    }
                }

                // Jika tidak ada karakteristik spam pada review, transisi ke NotSpam
                currentState = State.NotSpam;
                return false;
            }

            // Method untuk mendapatkan status spam saat ini
            public State GetCurrentState()
            {
                return currentState;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Mendapatkan nilai dari TextBox untuk review dan rating
            string review = textBox2.Text;
            string rate = textBox1.Text;

            // Membuat instance dari kelas SpamDetector untuk mendeteksi spam pada review
            SpamDetector detector = new SpamDetector();

            // Memeriksa apakah review kosong
            if (string.IsNullOrEmpty(review))
            {
                MessageBox.Show("Description cannot be empty");
            }
            else if (string.IsNullOrEmpty(rate))
            {
                MessageBox.Show("Must give a rating");
            }
            else
            {
                // Memeriksa apakah review terdeteksi sebagai spam
                if (detector.DetectSpam(review))
                {
                    MessageBox.Show("This review is detected as spam.");
                    textBox2.Clear();// mengosongkan TextBox review
                }
                // Memeriksa apakah input rating valid (berupa angka)
                else if (!Regex.IsMatch(rate, @"^\d+$")) 
                { 
                    MessageBox.Show("The rating must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Mengonversi input rating dari string menjadi integer
                    int rating = int.Parse(rate);
                    // Memeriksa apakah rating berada dalam rentang yang valid (0-5)
                    if (rating < 0 || rating > 5)
                    {
                        MessageBox.Show("Give a rating out of 5");
                    }
                    else
                    {
                        MessageBox.Show("rating berhasil dibuat!");
                        // Menyembunyikan form ini
                        this.Hide();

                        // Membuat instance dari Form2 dengan data produk
                        Form2 r = new Form2(namaProduk, hargaProduk);

                        // Mengatur nilai TextBox pada Form2 dengan input pengguna
                        r.SetTextBox1(rate);
                        r.SetTextBox2(review);

                        // Menampilkan Form2
                        r.Show();
                      }
                }
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
           
 }
 
