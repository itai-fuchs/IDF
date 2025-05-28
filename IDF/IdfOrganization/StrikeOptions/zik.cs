using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF.IdfOrganization.StrikeOptions
{
    /// <summary>
    /// Class of the Zik attack tool.
    /// </summary>
    internal class Zik : IStrikeOptions
    {
        public string Name { get; } = "Hermes 460 (zik) Drone";
        public int AmmunitionCapacity { get; private set; }
        public double FuelSupplyGalon { get; private set; }
        public List<string> EffectiveAgainst { get; } = new List<string> { "people", "vehicles" };
        public string id { get; }

        // Constructor with default values
        public Zik(int ammunitionCapacity = 3, double fuelSupplyGalon = 400)
        {
            AmmunitionCapacity = ammunitionCapacity;
            FuelSupplyGalon = fuelSupplyGalon;
            id = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public void Refueling()
        {
            FuelSupplyGalon = 400;
        }

        public void Attack()
        {
            AmmunitionCapacity -= 1;
            FuelSupplyGalon -= 55;
        }

        public void AmmunitionRefill()
        {
            AmmunitionCapacity = 3;
        }

        public bool IsAvailable()
        {
            return AmmunitionCapacity > 0 && FuelSupplyGalon >= 55;
        }
    }
}