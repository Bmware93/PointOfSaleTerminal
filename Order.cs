using System;
namespace PointOfSaleTerminal
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double LineTotal => Product.Price * Quantity;
    }
}

