using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    class F16 : IStrikeOptions
    {
        public string Name { get; } = "F16 Fighter Jet";

        public int Ammunition_capacity { get; private set; } = 8;

        public double Fuel_supply_Galon { get; private set; } = 700;

        public List<string> Effective_against { get; } = new List<string> { "buildings" };

        public void Refueling()
        {
            Fuel_supply_Galon = 700;
        }
        public void attack()
        {
            Ammunition_capacity -= 1;
            Fuel_supply_Galon -= 55;

        }
        public void AmmunitionRefill()
        { Ammunition_capacity = 8; }

        public bool IsAvailable()
        {
            if (Ammunition_capacity == 0 || Fuel_supply_Galon == 0) return false;
            else return true;


        }
        

    }
}