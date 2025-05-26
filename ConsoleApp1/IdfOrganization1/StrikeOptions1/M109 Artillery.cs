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

        public int AmmunitionCapacity { get; private set; } = 40;

        public double FuelSupplyGalon { get; private set; } = 200;

        public List<string> EffectiveAgainst { get; } = new List<string> { "open areas" };

        //refuling method
        public void Refueling()
        {
            FuelSupplyGalon =200;
        }

        //attack method
        public void attack()
        {
            Random random = new Random();
            AmmunitionCapacity -=random.Next(1,3);
            FuelSupplyGalon -= 10;

        }
        
        //AmmunitionRefill method
        public void AmmunitionRefill()
        { AmmunitionCapacity = 40; }


        //check if available method
        public bool IsAvailable()
        {
            if (AmmunitionCapacity == 0 || FuelSupplyGalon == 0) return false;
            else return true;
        }
       
    }
}
