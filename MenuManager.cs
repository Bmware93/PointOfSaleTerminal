using System;

//Display the menu for product selection.
//Allow the user to select products by number/letter.
//Allow the user to specify quantities.
//Re-display the menu as needed.
//Calculate the line total for each selected product (price * quantity).
//Store and manage the selected products and their quantities.

namespace PointOfSaleTerminal
{
	public class MenuManager
		
	{
        static public void DisplayMenu()
		{
            InventoryManager inventory = new InventoryManager();
            List<Order> orders = new List<Order>();
            bool isShopping = true;
            Console.WriteLine("List of available products: \n");
            while (isShopping)
            {
                inventory.DiplayProducts();
                Console.WriteLine("Enter the number of the product you'd like to buy (or 0 to finish):");
                if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= inventory.ProductList.Count)
                {
                    Product selectedProduct = inventory.ProductList[productNumber - 1];

                    Console.WriteLine($"How many {selectedProduct.Name}'s would you like?");
                    if (int.TryParse(Console.ReadLine(), out int itemQuantity) && itemQuantity > 0)
                    {
                        orders.Add(new Order { Product = selectedProduct, Quantity = itemQuantity });
                        Console.WriteLine($"{itemQuantity} x {selectedProduct.Name} has been added to your order.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please try again.");
                    }
                }
                else if (productNumber == 0)
                {
                    isShopping = false;
                    Console.WriteLine("Thank you for shopping!");
                }
                else
                {
                    Console.WriteLine("Invalid product number. Please try again.");
                }
            }

            Console.WriteLine("Your order Summary: ");
            double subtotal = 0;
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Quantity} x {order.Product.Name} - {order.LineTotal:c}");
                subtotal += order.LineTotal;
            }
            Console.WriteLine($"Subtotal: {subtotal:c}");
        }
	}
}

