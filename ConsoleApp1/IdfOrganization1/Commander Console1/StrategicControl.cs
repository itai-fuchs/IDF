using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using IDF_Operation___First_Strike.AMAN;

namespace IDF.IdfOrganization.Commander_Console
{
    internal class StrategicControl : IStrategicControl
    {

        public Terrorist TerroristMostReport(List<Dictionary<Terrorist, List<AMAN>>> list)
        {
            int maxReports = 0;
            Terrorist terroristWithMostReports = null;

            foreach (Dictionary<Terrorist, List<AMAN>> dict in list)
            {
                foreach (KeyValuePair<Terrorist, List<AMAN>> pair in dict)
                {
                    Terrorist terrorist = pair.Key;
                    List<AMAN> reports = pair.Value;

                    if (reports.Count > maxReports)
                    {
                        maxReports = reports.Count;
                        terroristWithMostReports = terrorist;
                    }
                }
            }

            return terroristWithMostReports;

        }

        public void StrikeAvailability()
        {
            foreach (KeyValuePair<string, List<IStrikeOptions>> kvp in Static_IDF.GetStrikeDict())
            {
                string toolName = kvp.Key;
                List<IStrikeOptions> tools = kvp.Value;
                Console.WriteLine($"{toolName}:");
                Console.WriteLine();

                foreach (IStrikeOptions strike in tools)
                {
                    if (strike.IsAvailable())
                    {

                        Console.WriteLine($"NAME: {strike.Name}\nAVAILBAL: {strike.IsAvailable()}\nFUEL STOCK: {strike.FuelSupplyGalon}\nAMMUNITION STOCK: {strike.AmmunitionCapacity}");
                    }
                }
            }
        }

        public void Target_Prioritization()
        {


            int qualityScore = 0;
            Terrorist wanted1 =null;
            foreach (Terrorist terrorist in Hamas.GetTerroristList())
            {
                int temp = 0;
                foreach (string weapon in terrorist.GetWeapons())
                {
                    if (weapon == "knife") temp += 1;
                    else if (weapon == "gun") temp += 2;
                    else temp += 3;
                }
                temp = terrorist.GetRank() * temp;
                if (temp > qualityScore)
                {
                    qualityScore = temp;
                    wanted1 = terrorist;

                }
                Console.WriteLine(wanted1 + $"QUALITY SCORE: {qualityScore}\n");

            }
    }
    }






}

