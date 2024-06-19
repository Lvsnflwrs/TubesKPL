
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MOdifProduk
{
    public class runtime
    {
        public List<Product> Products = new List<Product>();
        public const string filePath = @"D:\Konstruksi Perangkat Lunak\HalamanToko\json\DataProduk.json";

        public void ReadConfigFile()
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<Data>(jsonContent);

                if (data != null)
                {
                    Products = data.Products;
                }
                else
                {
                    MessageBox.Show("Data produk tidak ditemukan.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                MessageBox.Show($"Error deserializing JSON: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
                MessageBox.Show($"File not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading config file: {ex.Message}");
                MessageBox.Show($"Error reading config file: {ex.Message}");
            }
        }

        public void WriteNewConfigFile()
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                var data = new Data
                {
                    Products = Products
                };
                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, jsonString);

                Console.WriteLine($"File written to {filePath}");
                MessageBox.Show($"File written to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing new config file: {ex.Message}");
                MessageBox.Show($"Error writing new config file: {ex.Message}");
            }
        }

        public void PopulateListBox(ListBox listBox)
        {
            ReadConfigFile();

            listBox.Items.Clear();
            foreach (var product in Products)
            {
                listBox.Items.Add(product.Nama);
            }
        }

        public Product GetProductDetails(string productName)
        {
            return Products.Find(p => p.Nama == productName);
        }

        public class Data
        {
            public List<Product> Products { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Nama { get; set; }
            public decimal Harga { get; set; }
            public int Stok { get; set; }

            public Product() { }

            public Product(int id, string nama, decimal harga, int stok)
            {
                Id = id;
                Nama = nama;
                Harga = harga;
                Stok = stok;
            }
        }
    }

}
