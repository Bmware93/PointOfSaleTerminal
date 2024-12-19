using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class InventoryManager
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        public InventoryManager()
        {
            ProductList.Add(new Product("Caramel Latte",  "caramel syrup mixed into steamed milk and combined with espresso", "Drink", 7.50));
            ProductList.Add(new Product( "Vanilla Latte",  "Vanilla syrup mixed into steamed milk and combined with espresso", "Drink", 7.50));
            ProductList.Add(new Product( "White Chocolate Latte",  "White chocolate syrup mixed into steamed milk and combined with espresso", "Drink", 7.50));
            ProductList.Add(new Product( "Green tea",  "Light bodied tea with mild astringency", "Drink", 4.50));
            ProductList.Add(new Product( "Chai tea",  "Black tea blended with cinnamon, cardamom, ginger clone, and star anise", "Drink", 5.00));
            ProductList.Add(new Product( "Earl grey tea", "Tea blend flavoured with oil of bergamot", "Drink", 5.25));
            ProductList.Add(new Product( "Strawberry Acai Refresher",  "Strawberry, passionfruit and acai flavors mixed with lemonade", "Drink", 5.25));
            ProductList.Add(new Product( "Blueberry Refresher", "Blueberry, passionfruit and acai flavors mixed with lemonade", "Drink", 5.25));
            ProductList.Add(new Product( "Espresso with cream",  "Espresso topped with whipped cream", "Drink", 1.50));
            ProductList.Add(new Product( "Caramel Frappe",  "Delightful cold foamed coffee with espresso, milk, and sugar.", "Drink", 7.50));
            ProductList.Add(new Product( "Breakfast sandwich",  "Crispy bacon, Fried egg, and classic American cheese on a plain bagel. ", "Food", 11.00));
            ProductList.Add(new Product( "Croissant", "Crisp and flaky on the outside and soft and tender on the inside, with a texture that can be almost pulled apart", "Food", 7.50));
            ProductList.Add(new Product( "Blueberry Muffin", "Moist, sweet, and bursting with fruity flavor", "Food", 7.50));
            ProductList.Add(new Product( "English muffin",  "Smoothie stuff", "Food", 7.50));
        }

        public void DiplayProducts()
        {
            for (int i = 0; i < ProductList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ProductList[i].Name} - {ProductList[i].Price:c}");
            }
        }

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }

    }
}
