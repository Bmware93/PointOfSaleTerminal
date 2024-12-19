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
        double subTotal = 0;
        double salesTax = 0;
        public double GrandTotal {  get; set; }





        public string ProcessPayment()
        {
            Console.WriteLine($"The total for your order is: {GrandTotal:c}");
            Console.WriteLine("How would you like to pay? \n1.Cash\n2.Card\n3.Check");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ProcessCashPayment();
                    return "Cash";
                case "2":
                    ProcessCardPayment();
                    return "Credit Card";

                case "3":
                    ProcessCheckPayment();
                    return "Check";
                default:
                    Console.WriteLine("Not a valid input. Please try again");
                    return ProcessPayment();
            }
            return "";
        }
        public double CalculateGrandTotal(List<Order> orders)
        {
            for ( int i = 0; i < orders.Count; i++ )
            {
                subTotal += (orders[i].Product.Price * orders[i].Quantity);
            }
            GrandTotal = subTotal + (subTotal * 0.06);
            return GrandTotal;
        }

        public void ProcessCashPayment()
        {
            double cashGiven;
            do
            {
                Console.WriteLine($"Enter cash amount: ");
                if (double.TryParse(Console.ReadLine(), out cashGiven) && cashGiven >= GrandTotal)
                {
                    Console.WriteLine($"Change: {cashGiven - GrandTotal:c}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid amount or insufficient funds. Please try again.");
                }
            } while (true);
        }
        private void ProcessCardPayment()
        {
            string creditCardNumber = GetValidCreditCardNumber();
            string expirationDate = GetValidExpirationDate();
            string cvv = GetValidCVV();
            Console.WriteLine("Payment Successful");
        }

        public void ProcessCheckPayment()
        {
            Console.WriteLine("Please enter your check number: ");
            string checkNumber = Console.ReadLine();

            Console.WriteLine($"Paid with check: {checkNumber}");
        }

        #region "Card Validations"
        private string GetValidCreditCardNumber()
        {
            string creditCardNumber;
            do
            {
                Console.WriteLine("Please enter the credit card number: ");
                creditCardNumber = Console.ReadLine();
                if (isValidCreditCardNumber(creditCardNumber) == false)
                {
                    Console.WriteLine("Invalid credit card number. Please try again.");
                }


            } while (isValidCreditCardNumber(creditCardNumber) == false);
            return creditCardNumber;
        }

        private bool isValidCreditCardNumber(string creditCardNumber)
        {
            return creditCardNumber.All(char.IsDigit) && creditCardNumber.Length == 15 || creditCardNumber.Length == 16;
        }
        private string GetValidExpirationDate()
        {
            string expirationDate;
            do
            {
                Console.WriteLine("Enter the expiration date (MM/YY)");
                expirationDate = Console.ReadLine();
                if (IsValidExpirationDate(expirationDate) == false)
                {
                    Console.WriteLine("Invalid expiration date. Please try again.");
                }
            } while (IsValidExpirationDate(expirationDate) == false);
            return expirationDate;
        }

        private bool IsValidExpirationDate(string expirationDate)
        {
            if (DateTime.TryParseExact(expirationDate, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                return date > DateTime.Now;
            }
            return false;
        }
        private string GetValidCVV()
        {
            string cvv;
            do
            {
                Console.WriteLine("What is the credit card CVV?");
                cvv = Console.ReadLine();
                if (IsValidCVV(cvv) == false)
                {
                    Console.WriteLine("Invalid input for CVV. Please try again");
                }
                return cvv;
            } while (IsValidCVV(cvv) == false);

        }

        private bool IsValidCVV(string cvv)
        {
            if (cvv.All(char.IsDigit) && cvv.Length == 3 || cvv.Length == 4)
            {
                return true;
            }
            return false;
        }
        #endregion

        public void Receipt(List<Order> orders)
        {
            subTotal = 0;
            salesTax = 0;
            Console.WriteLine("Your order Summary: ");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Quantity} x {order.Product.Name} - {order.LineTotal:c}");
                subTotal += order.LineTotal;
            }
            salesTax = 0.06 * subTotal;
            Console.WriteLine($"Subtotal: {subTotal:c}");
            Console.WriteLine($"Sales Tax: {salesTax:c}");
            Console.WriteLine($"Grand Toal: {GrandTotal:c}");
            Console.WriteLine("-----------------");
        }


    };

    




}
