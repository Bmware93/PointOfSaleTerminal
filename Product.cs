using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    internal class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price {  get; set; }
        public Product(string name, string description, string category, double price)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
        }
    }
}
