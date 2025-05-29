using IDF.Factories;
using IDF.IdfOrganization.StrikeOptions;
using IDF_Operation___First_Strike.AMAN;
using System;
using System.Collections.Generic;

namespace IDF
{
    internal class Simulation
    {
        public void InitializeTerroristList()
        {
            int count = new Random().Next(10, 20);
            var terrorists = TerroristFactory.CreateTerroristList(count);

            foreach (var terrorist in terrorists)
            {
                Hamas.AddTerrorist(terrorist);
            }
        }

        public void InitializeStrikeList()
        {
            var strikeOptions = StrikeFactory.CreateDefaultStrikeOptions();

            foreach (var strike in strikeOptions)
            {
                Idf.AddStrike(strike);
            }
        }

        // IntelligenceFactory
    }
}
