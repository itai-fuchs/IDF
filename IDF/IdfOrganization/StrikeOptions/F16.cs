using IDF;
using System;
using System.Collections.Generic;

class F16 : IStrikeOptions
{
    public string Name { get; } = "F16 Fighter Jet";
    public int AmmunitionCapacity { get; private set; }
    public double FuelSupplyGalon { get; private set; }
    public List<string> EffectiveAgainst { get; } = new List<string> { "buildings" };
    public string id { get; }

    // Constructor
    public F16(int ammunitionCapacity = 8, double fuelSupplyGalon = 700)
    {
        AmmunitionCapacity = ammunitionCapacity;
        FuelSupplyGalon = fuelSupplyGalon;
        id = Guid.NewGuid().ToString().Substring(0, 7); 
    }

    public void Refueling()
    {
        FuelSupplyGalon = 700;
    }

    public void Attack()
    {
        AmmunitionCapacity -= 1;
        FuelSupplyGalon -= 80;
    }

    public void AmmunitionRefill()
    {
        AmmunitionCapacity = 8;
    }

    public bool IsAvailable()
    {
        return AmmunitionCapacity > 0 && FuelSupplyGalon >= 80;
    }
}
