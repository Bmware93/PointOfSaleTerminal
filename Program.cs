// See https://aka.ms/new-console-template for more information
using System;



namespace PointOfSaleTerminal

{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = MenuManager.CreateOrder();
            PaymentProcessor payment = new PaymentProcessor();
            payment.CalculateGrandTotal(orders);
            string processPayment = payment.ProcessPayment();
            payment.Receipt(orders);


        }

    }
}







