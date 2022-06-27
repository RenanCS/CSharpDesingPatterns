using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural
{
    public class CityFromExternalSystem
    {
        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }

        public string Name { get; set; }
        public string NickName { get; set; }
        public int Inhabitants { get; set; }
    }

    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
        }
    }

    public class City
    {
        public City(string fullName, int inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }

        public string FullName { get; set; }
        public int Inhabitants { get; set; }
    }

    public interface ICityAdapter
    {
        City GetCity();
    }

    public class CityAdapter : ICityAdapter
    {
        public ExternalSystem ExternalSystem { get; private set; } = new(); 
        public City GetCity()
        {
            var cityFromExternalSystem = ExternalSystem.GetCity();

            return new City($"{cityFromExternalSystem.Name}-{cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitants);
        }
    }
}
