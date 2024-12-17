using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class PaymentProcessor
    {
        List<Order> NewOrder { get; set; } = new();

        public void CalculateTotalPrice(  )
        {
            double subTotal = 0;
            double salesTax = 0.06;
            double grandTotal;


            for ( int i = 0; i < NewOrder.Count; i++ )
            {
                subTotal += (NewOrder[i].Product.Price * NewOrder[i].Quantity);
            }
            grandTotal = subTotal + subTotal * salesTax;
        }

    };

    




}
