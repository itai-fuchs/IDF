using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF.IdfOrganization.StrikeOptions
{
    internal class M109_Artillery : IStrikeOptions
    {
        public string Name { get; } = "M109 Artillery";
        public int AmmunitionCapacity { get; private set; }
        public double FuelSupplyGalon { get; private set; }
        public List<string> EffectiveAgainst { get; } = new List<string> { "open areas" };
        public string id { get; }

        // Constructor with default values
        public M109_Artillery(int ammunitionCapacity = 40, double fuelSupplyGalon = 200)
        {
            AmmunitionCapacity = ammunitionCapacity;
            FuelSupplyGalon = fuelSupplyGalon;
            id = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public void Refueling()
        {
            FuelSupplyGalon = 200;
        }

        public void Attack()
        {
            Random random = new Random();
            AmmunitionCapacity -= random.Next(1, 3);
            FuelSupplyGalon -= 10;
        }

        public void AmmunitionRefill()
        {
            AmmunitionCapacity = 40;
        }

        public bool IsAvailable()
        {
            return AmmunitionCapacity > 0 && FuelSupplyGalon >= 10;
        }
    }
}
