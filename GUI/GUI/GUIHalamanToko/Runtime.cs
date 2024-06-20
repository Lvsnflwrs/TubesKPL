using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace GUIHalamanToko
{
    public class Runtime<T>
    {
        public List<T> Items = new List<T>();
        public string filePath;
        private string rootPropertyName;

        public Runtime(string path, string rootProperty)
        {
            filePath = path;
            rootPropertyName = rootProperty;
            ReadConfigFile();
        }

        public void ReadConfigFile()
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                var jsonData = JsonDocument.Parse(jsonContent);

                if (jsonData.RootElement.TryGetProperty(rootPropertyName, out JsonElement rootElement))
                {
                    Items = JsonSerializer.Deserialize<List<T>>(rootElement.GetRawText()) ?? new List<T>();
                }
                else
                {
                    Console.WriteLine($"Root property '{rootPropertyName}' not found in JSON file.");
                    MessageBox.Show($"Root property '{rootPropertyName}' not found in JSON file.");
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
                var data = new Dictionary<string, List<T>> { { rootPropertyName, Items } };
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
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

        public void PopulateListBox(ListBox listBox, Func<T, string> displayMember)
        {
            ReadConfigFile();

            listBox.Items.Clear();
            foreach (var item in Items)
            {
                listBox.Items.Add(displayMember(item));
            }
        }

        public T GetItemDetails(Predicate<T> match)
        {
            return Items.Find(match);
        }

        public void AddItem(T item)
        {
            Items.Add(item);
            WriteNewConfigFile();
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
            WriteNewConfigFile();
        }
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
