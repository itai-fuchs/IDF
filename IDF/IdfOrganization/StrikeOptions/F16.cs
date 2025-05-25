using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    /// <summary>
    /// F16 attack aircraft class.
    /// </summary>
    class F16 : IStrikeOptions
    {
        public string Name { get; } = "F16 Fighter Jet";

        public int AmmunitionCapacity { get; private set; } = 8;

        public double FuelSupplyGalon { get; private set; } = 700;

        public List<string> EffectiveAgainst { get; } = new List<string> { "buildings" };

        //ID
        static string t = Guid.NewGuid().ToString();
        public string id { get; } = t.Substring(0, 7);
            


        //refuling method
        public void Refueling()
        {
            FuelSupplyGalon = 700;
        }

        //attack method
        public void attack()
        {
            AmmunitionCapacity -= 1;
            FuelSupplyGalon -= 80;

        }
        //AmmunitionRefill method
        public void AmmunitionRefill()
        { AmmunitionCapacity = 8; }

        //check if available method
        public bool IsAvailable()
        {
            if (AmmunitionCapacity == 0 || FuelSupplyGalon < 80) return false;
            else return true;


        }
        

    }
}