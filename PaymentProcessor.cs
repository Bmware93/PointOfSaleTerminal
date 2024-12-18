using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class PaymentProcessor
    {
        List<Order> NewOrder { get; set; } = new();
        double subTotal = 0;
        double salesTax = 0.06;
        double grandTotal;

        public double CalculateTotalPrice(  )
        {
            for ( int i = 0; i < NewOrder.Count; i++ )
            {
                subTotal += (NewOrder[i].Product.Price * NewOrder[i].Quantity);
            }
            grandTotal = subTotal + subTotal * salesTax;
            return grandTotal;
        }

        public void CashPayment (double amount)
        {
           double change = amount - grandTotal ;
            Console.WriteLine($"You paid {amount} your change is {change}");
        }

        public void CreditPayment ()
        {
            Console.WriteLine("Please enter your credit card number: ");
            string userInput = Console.ReadLine();
            bool isValidNumber = long.TryParse(userInput, out long number);
            if ( isValidNumber && userInput.Length == 15 || userInput.Length == 16)
            {
                Console.WriteLine("Enter the expiration date (MM/YY):");
                string expirationDate = Console.ReadLine();

                Console.WriteLine("Enter the CVV: ");
                string cvv = Console.ReadLine();

                Console.WriteLine($"You paid {grandTotal}");
            }
            else
            {
                Console.WriteLine("Please enter a valid credit card number");
            }
 
        }
        
        public void CheckPayment ()
        {
            Console.WriteLine("Please enter your check number: ");
            string checkNumber = Console.ReadLine();

            Console.WriteLine($"Paid with check: {checkNumber}");
        }
        
        public void Receipt()
        {
            Console.WriteLine("Your order Summary: ");
            double subtotal = 0;
            foreach (var order in NewOrder)
            {
                Console.WriteLine($"{order.Quantity} x {order.Product.Name} - {order.LineTotal:c}");
                subtotal += order.LineTotal;
            }
            Console.WriteLine($"Subtotal: {subtotal:c}");

        }
        

    };

    




}
