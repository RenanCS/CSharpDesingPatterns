using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }
        public override string ToString() => GetType().Name;
    }

    public class CoutryDiscountService: DiscountService
    {
        private readonly string _countryIdentifier;
        public CoutryDiscountService(string coutryIdentifier)
        {
            _countryIdentifier = coutryIdentifier;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier) 
                {
                    case "BE": return 20;
                    default: return 10;       
                }
            }
        }
    }

    public class CodeDiscountService: DiscountService
    {
        private readonly Guid _code;
        public CodeDiscountService(Guid code)
        {
            _code = code;
        }

        public override int DiscountPercentage
        {
            get => 15;
        }
    }

    public abstract class DiscountFactory {
        public abstract DiscountService CreateDiscountService();
    }


    public class CountryDiscoutFactory: DiscountFactory
    {
        private readonly string _countryIdentifier;
        
        public CountryDiscoutFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CoutryDiscountService(_countryIdentifier);
        }
    }

    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }
}
