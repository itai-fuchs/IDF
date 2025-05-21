using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF.IdfOrganization.StrikeOptions
{
    internal class M109_Artillery: IStrikeOptions
    {
    
        public string Name { get; } = "M109 Artillery";

        public int Ammunition_capacity { get; private set; } = 40;

        public double Fuel_supply_Galon { get; private set; } = 200;

        public List<string> Effective_against { get; } = new List<string> { "open areas" };

        public void Refueling()
        {
            Fuel_supply_Galon =200;
        }
        public void attack()
        {
            Random random = new Random();
            Ammunition_capacity -=random.Next(1,3);
            Fuel_supply_Galon -= 10;

        }
        public void AmmunitionRefill()
        { Ammunition_capacity = 40; }

       public bool IsAvailable()
        {
            if (Ammunition_capacity == 0 || Fuel_supply_Galon == 0) return false;
            else return true;
        }
        public M109_Artillery()
        {

            Static_IDF.RegisterStrike(this);


        }
    }
}
