using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product2
{
    public class Product
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product(string productName, decimal price, string category)
        {
            ProductName = productName;
            Price = price;
            Category = category;
        }


        public override string ToString()
        {
            return $"\nProduct Name: {ProductName,-30}\nCategory: {Category}\nPrice:  ${Price}";
        }
    }
}