using System;
using System.Collections.Generic;
using System.Linq;

namespace Product2;

class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        bool keepRunning = true;

        Console.WriteLine("🏪 Welcome to the Product Inventory System!");
        Console.WriteLine("==========================================");

        while (keepRunning)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a new product");
            Console.WriteLine("2. Display all products");
            Console.WriteLine("3. Quit (or type 'q')");
            Console.Write("\nYour choice: ");

            string choice = Console.ReadLine()?.Trim().ToLower();

            switch (choice)
            {
                case "1":
                    AddProduct(inventory);
                    break;
                case "2":
                    DisplayProducts(inventory);
                    break;
                case "3":
                case "q":
                    keepRunning = false;
                    Console.WriteLine("\nThank you for using Product Inventory System!\n");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddProduct(Inventory inventory)
    {

        Console.WriteLine("\n📦 Adding a new product:");
        Console.WriteLine("------------------------");

        // Get Category
        string category = GetValidInput("Enter Category: ");
        if (category.ToLower() == "q") return;

        // Get Product Name
        string productName = GetValidInput("Enter Product Name: ");
        if (productName.ToLower() == "q") return;

        // Get Price with validation
        decimal price = GetValidPrice();
        if (price == -1) return; // User quit

        // Create and add product
        Product newProduct = new Product(productName, price, category);
        inventory.AddProduct(newProduct);

        Console.WriteLine($"\nSuccessfully added: {productName}");

    }

    //Display Total Products Method
    static void DisplayProducts(Inventory inventory)
    {
        Console.WriteLine("\n" + new string('=', 50));
        inventory.DisplayProducts();
        int count = inventory.GetProductCount();
        Console.WriteLine($"Total Products: {count}");
        Console.WriteLine(new string('=', 50));
    }

    // Check if input is valid Method
    static string GetValidInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Try again (or 'q' to quit):");
            }
            else if (input.ToLower() == "q")
            {
                return input;
            }
        }
        while (string.IsNullOrEmpty(input));

        return input;
    }

    //Check if Price is valid Method
    static decimal GetValidPrice()
    {
        decimal price;
        string input;

        do
        {
            Console.Write("Enter Price (e.g., 10.99): $");
            input = Console.ReadLine()?.Trim();

            if (input?.ToLower() == "q")
            {
                return -1; // Signal to quit
            }

            if (decimal.TryParse(input, out price) && price >= 0)
            {
                return price;
            }

            Console.WriteLine("Please enter a valid price (positive number) or 'q' to quit:");
        }
        while (true);
    }
}
