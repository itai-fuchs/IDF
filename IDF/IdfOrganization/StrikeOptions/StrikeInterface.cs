using System;
using IDF;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    /// <summary>
    /// Interface of the types of IDF attack vehicles.
    /// </summary>
    internal interface IStrikeOptions
    {
        string Name { get;}
        int AmmunitionCapacity { get;}
        double FuelSupplyGalon { get;}
        List <string> EffectiveAgainst {get;}
        void Refueling();
        void AmmunitionRefill();
        void attack();
        bool IsAvailable();
    }
}
