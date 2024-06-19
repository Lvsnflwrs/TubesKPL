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
        private String namaProduk;
        private int hargaProduk;
        public Form1(String namaProduk, int hargaProduk)
        {
            InitializeComponent();

            this.namaProduk = namaProduk;
            this.hargaProduk = hargaProduk;

            label5.Text = namaProduk;
            label6.Text = hargaProduk.ToString();
            
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

        internal class SpamDetector
        {
            public enum State { Start, PossibleSpam, CertainSpam, NotSpam };

            private State currentState;

            public SpamDetector()
            {
                currentState = State.Start;
            }

            public bool DetectSpam(string review)
            {
                foreach (string word in review.ToLower().Split(' '))
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

                        if (charCount[c] > 2)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string review = textBox2.Text;
            string rate = textBox1.Text;

            SpamDetector detector = new SpamDetector();

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
                if (detector.DetectSpam(review))
                {
                    MessageBox.Show("This review is detected as spam.");
                    textBox2.Clear();
                } 
                else if (!Regex.IsMatch(rate, @"^\d+$")) 
                { 
                    MessageBox.Show("The rating must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int rating = int.Parse(rate);
                    if (rating < 0 || rating > 5)
                    {
                        MessageBox.Show("Give a rating out of 5");
                    }
                    else
                    {
                        MessageBox.Show("rating berhasil dibuat!");

                        this.Hide();
                        Form2 r = new Form2(namaProduk, hargaProduk);
                        r.SetTextBox1(rate);
                        r.SetTextBox2(review);
                        r.Show();
                      }
                }
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }
    }
           
 }
 
