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
        private Database db = new Database();
        private List<String> produk = new List<String>();
        private int loginId;
        private MySqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
            deleteBtn.Visible = false;
            db.Connect();           
            reader = db.View("SELECT * FROM login");
            try
            {
                if (reader.Read())
                {
                    loginId = reader.GetInt32("id");                   
                }
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            db.Disconnect();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            listProduk.Items.Clear();
            produk.Clear();
            db.Connect();
            reader = db.View("SELECT p.nama FROM wishlist w JOIN produk p ON w.idProduk = p.id WHERE w.idPembeli = " + loginId + "");
            if(reader.Read())
            {
                try
                {
                    while (reader.Read())
                    {
                        produk.Add(reader["nama"].ToString());
                    }
                    foreach (var item in produk)
                    {
                        listProduk.Items.Add(item);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Wishlist anda kosong!", "APA!!!!????", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }              
            db.Disconnect();
        }
    }
}
