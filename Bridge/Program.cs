using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var noCoupon = new NoCoupon();
            var oneEuroCoupoun = new OneEuroCoupon();

            var meatBaseMenu = new MeatBaseMenu(noCoupon);
            Console.WriteLine($"Meat no coupon {meatBaseMenu.CalculatePrice()}");

            meatBaseMenu = new MeatBaseMenu(oneEuroCoupoun);
            Console.WriteLine($"Meat one coupon {meatBaseMenu.CalculatePrice()}");

            var vegetarianMenu = new VegetarianMenu(noCoupon);
            Console.WriteLine($"Vegetarian no coupon {vegetarianMenu.CalculatePrice()}");

            vegetarianMenu = new VegetarianMenu(oneEuroCoupoun);
            Console.WriteLine($"Vegetarian one coupon {vegetarianMenu.CalculatePrice()}");

            Console.ReadKey();

        }
    }
}
