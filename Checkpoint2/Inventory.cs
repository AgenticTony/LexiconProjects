using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Product2
{
    public class Inventory
    {
        private List<Product> items;
        public Inventory()
        {
            items = new List<Product>();
        }

        //Adding a Product Method
        public void AddProduct(Product product)
        {
            items.Add(product);
        }

        //Sorts products by price in ascending order using LINQ OrderBy
        public List<Product> GetSortedProducts()
        {
            var sortedItems = items.OrderBy(p => p.Price).ToList();
            return sortedItems;
        }

        //Add total of all Products Method
        public decimal GetTotal()
        {
            decimal total = items.Sum(p => p.Price);
            return total;
        }

        //Display all Products Method 
        public void DisplayProducts()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("\nProduct List (sorted by Price)");

            var sorted = GetSortedProducts();
            foreach (var item in sorted)

            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nTotal Inventory Value: ${GetTotal():F2}");
        }

        //Count how many Products Method
        public int GetProductCount()
        {
            return items.Count;
        }

        //Get Products by category Method
        public List<Product> GetProductsByCategory(string category)
        {
            return items.Where(p => p.Category == category).ToList();
        }


    }
}