using IDF.IdfOrganization.StrikeOptions;
using IDF_Operation___First_Strike.AMAN;
using System;
using System.Collections.Generic;

namespace IDF
{
    internal class Program
    {
        static void Main(string[] args)
        {

        Simulation simulation = new Simulation();
         
            simulation.InitializingTerroristList();
            simulation.InitializingStrikeList();
            AMAN.GenerateIntelligence();

            Hamas.GetTerroristList();
            StrategicControl l = new StrategicControl();
            l.CommanderMenu();

            //foreach (KeyValuePair<string, List<IStrikeOptions>> kvp in Static_IDF.GetStrikeDict())
            //    {
            //    Console.WriteLine(kvp.Value); }
            //foreach (Terrorist terrorist in Hamas.GetTerroristList())
            //{
            //    Console.WriteLine(terrorist.ToString());
            //}

        }
    }
}



