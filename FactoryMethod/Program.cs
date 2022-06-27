using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var factories = new List<DiscountFactory>
           {
               new CodeDiscountFactory(Guid.NewGuid()),
               new CountryDiscoutFactory("BE")
           };

            foreach (var factory in factories)
            {
                var discountService = factory.CreateDiscountService();
                Console.WriteLine($"Percentage {discountService.DiscountPercentage} comming from {discountService}");
            }

            Console.ReadLine();
        }
    }
}
