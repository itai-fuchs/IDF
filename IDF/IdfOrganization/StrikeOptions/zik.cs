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
    internal class Zik: IStrikeOptions
    {
        public string Name { get; } = "Hermes 460 (zik) Drone";

        public int AmmunitionCapacity { get; private set; } =3;

        public double FuelSupplyGalon { get; private set; } = 400;

        public List<string> EffectiveAgainst { get; } = new List<string> { "people", "vehicles" };


        // ID
        static string t = Guid.NewGuid().ToString();
        public string id { get; } = t.Substring(0, 7);


        //refuling method
        public void Refueling()
        {
            FuelSupplyGalon = 400;
        }

        //attack method
        public void attack()
        {
            AmmunitionCapacity -= 1;
            FuelSupplyGalon -= 55;

        }
        //AmmunitionRefill method
        public void AmmunitionRefill()
        { AmmunitionCapacity = 3; }


        //check if available method
        public bool IsAvailable()
        {
            if (AmmunitionCapacity == 0 || FuelSupplyGalon <55) return false;
            else return true;
        }
       

    }
}
