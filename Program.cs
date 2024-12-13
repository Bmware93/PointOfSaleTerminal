// See https://aka.ms/new-console-template for more information
using PointOfSaleTerminal;

Console.WriteLine("Hello, World!");

InventoryManager newInventory = new InventoryManager();

newInventory.AddProduct(new Product("Blah", "blah", "blah", 1.00));
newInventory.DiplayProduct();