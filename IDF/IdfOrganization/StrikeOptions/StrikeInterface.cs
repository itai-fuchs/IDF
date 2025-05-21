using System;
using IDF;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    internal interface IStrikeOptions
    {
        string Name { get;}
        int Ammunition_capacity { get;}
        double Fuel_supply_Galon { get;}
        List <string> Effective_against {get;}
        void Refueling();
        void AmmunitionRefill();
        void attack();
        bool IsAvailable();




    }
}
