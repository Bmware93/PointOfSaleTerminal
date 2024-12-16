using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class PaymentProcessor
    { 
       //

        public void CalculateTotalPrice(List < Product > items )
        {
            double subTotal = 0;
            double salesTax = 0.06;
            double grandTotal;


            for ( int i = 0; i < items.Count; i++ )
            {
                subTotal += items[i].Price * items.quantity;
            }
            grandTotal = subTotal + subTotal * salesTax;
        }

    };

    




}
