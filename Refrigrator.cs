using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorApp
{

    // Class product 
    class Product
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Product(string name, double quantity, DateTime expirationDate)
        {
            Name = name;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }
    }

    // Class refrigerator and functionalities
    class Refrigerator
    {
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        // Insert
        public void InsertProduct(string name, double quantity, DateTime expirationDate)
        {
            if (products.ContainsKey(name))
            {
                products[name].Quantity += quantity;
            }
            else
            {
                products.Add(name, new Product(name, quantity, expirationDate));
            }
        }

        // Consume 
        public void ConsumeProduct(string name, double consumedQuantity)
        {
            if (products.ContainsKey(name))
            {
                if (products[name].Quantity >= consumedQuantity)
                {
                    products[name].Quantity -= consumedQuantity;
                }
                else
                {
                    Console.WriteLine("Not enough quantity available.");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        //Expired products
        public void HandleExpiredProducts()
        {
            Console.WriteLine("Checking for expired products...");
            foreach (var product in products)
            {
                if (product.Value.ExpirationDate <= DateTime.Today)
                {
                    Console.WriteLine($"{product.Key} has expired. Please remove from refrigerator.");
                    //products.Remove(product.Key);
                }
            }
        }

        // List of available products
        public void ShowCurrentStatus()
        {
            Console.WriteLine("Current status of products:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key}: {product.Value.Quantity}");
            }
        }
    }

    // Main method
    class Program
    {
        static void Main(string[] args)
        {
            Refrigerator refrigerator = new Refrigerator();

            // Insert products
            refrigerator.InsertProduct("Milk", 2.5, DateTime.Today.AddDays(7));
            refrigerator.InsertProduct("Eggs", 12, DateTime.Today.AddDays(14));
            refrigerator.InsertProduct("Cheese", 200, DateTime.Today.AddDays(30));
            refrigerator.InsertProduct("Milk", 2.5, DateTime.Today.AddDays(7));
            refrigerator.InsertProduct("Yogurt", 1, DateTime.Today.AddDays(-3)); // Adding Expired Product

            // Handle expired products
            refrigerator.HandleExpiredProducts();

            // Show current status
            refrigerator.ShowCurrentStatus();
        }
    }
}

