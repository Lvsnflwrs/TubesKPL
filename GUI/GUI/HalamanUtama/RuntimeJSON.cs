using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace HalamanUtama
{
    public class RuntimeJSON
    {
        public List<Product> Products = new List<Product>();
        public const string filePath = @"D:\COOLYEAH\Semester 4\KPL\TubesNew\Json\ProdData.json";

        public Product[] ReadConfigFile()
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                Product[] products = JsonSerializer.Deserialize<Product[]>(jsonContent);
                return products;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                MessageBox.Show($"Error deserializing JSON: {ex.Message}");
                return null;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
                MessageBox.Show($"File not found: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading config file: {ex.Message}");
                MessageBox.Show($"Error reading config file: {ex.Message}");
                return null;
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
                var data = new
                {
                    Products = Products
                };
                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, jsonString);

                // Log untuk memeriksa apakah file berhasil ditulis
                Console.WriteLine($"File written to {filePath}");
                MessageBox.Show($"File written to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing new config file: {ex.Message}");
                MessageBox.Show($"Error writing new config file: {ex.Message}");
            }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Nama { get; set; }
            public decimal Harga { get; set; }
            public int Stok { get; set; }
        }
    }
}
