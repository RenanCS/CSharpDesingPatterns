using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
            var shoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPurchaseFactory);
            shoppingCartForBelgium.CalculateCosts();

            var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
            var shoppingCartFroFrance = new ShoppingCart(franceShoppingCartPurchaseFactory);
            shoppingCartFroFrance.CalculateCosts();

            Console.ReadLine();
        }
    }
}
