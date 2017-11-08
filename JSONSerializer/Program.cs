using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSONSerializer
{
    public class Product
    {
        public string barcode_number { get; set; }
        public string item_name { get; set; }
        public decimal selling_price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product
            {
                barcode_number = "1234",
                item_name = "Some Product",
                selling_price = 12.50M
            };
            Product p2 = new Product
            {
                barcode_number = "1234",
                item_name = "Some Product",
                selling_price = 12.50M
            };
            Product p3 = new Product
            {
                barcode_number = "1234",
                item_name = "Some Product",
                selling_price = 12.50M
            };
            Product p4 = new Product
            {
                barcode_number = "",
                item_name = "",
                selling_price = 12.50M
            };
            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            Console.WriteLine(json);
            Console.ReadLine();

            List<Product> newProducts = JsonConvert.DeserializeObject<List<Product>>(json);
            foreach (var product in newProducts)
            {
                Console.WriteLine($"barcode : {product.barcode_number}, name : {product.item_name}, price : {product.selling_price}");
            }

            Console.ReadLine();

            File.WriteAllText(Environment.CurrentDirectory + "\\product.json", json);

            Console.ReadLine();

            List<Product> fromFileProducts =
                JsonConvert.DeserializeObject<List<Product>>(
                    File.ReadAllText(Environment.CurrentDirectory + "\\product.json"));
            foreach (var product in fromFileProducts)
            {
                Console.WriteLine($"barcode : {product.barcode_number}, name : {product.item_name}, price : {product.selling_price}");
            }

            Console.ReadLine();


        }
    }
}
