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

        public int Ammunition_capacity { get; private set; } =3;

        public double Fuel_supply_Galon { get; private set; } = 400;

        public List<string> Effective_against { get; } = new List<string> { "people", "vehicles" };

        public void Refueling()
        {
            Fuel_supply_Galon = 400;
        }
        public void attack()
        {
            Ammunition_capacity -= 1;
            Fuel_supply_Galon -= 55;

        }
        public void AmmunitionRefill()
        { Ammunition_capacity = 3; }
        public bool IsAvailable()
        {
            if (Ammunition_capacity == 0 || Fuel_supply_Galon == 0) return false;
            else return true;
        }
       

    }
}
