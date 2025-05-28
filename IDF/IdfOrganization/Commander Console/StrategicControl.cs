using IDF;
using IDF_Operation___First_Strike.AMAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    internal class StrategicControl
    {
        private static Random random = new Random();

        /// <summary>
        /// method that prints the weapons and their details.
        /// </summary>
        public void PrintStrikeAvailability()
        {
            foreach (KeyValuePair<string, List<IStrikeOptions>> kvp in Static_IDF.GetStrikeDict())
            {
                string toolName = kvp.Key;
                List<IStrikeOptions> tools = kvp.Value;
                Console.WriteLine($"{toolName}:");
                Console.WriteLine("");

                foreach (IStrikeOptions strike in tools)
                {
                    if (strike.IsAvailable())
                    {

                        Console.WriteLine($"ID: {strike.id}\n" +
                            $"AVAILBAL: {strike.IsAvailable()}\n" +
                            $"FUEL: {strike.FuelSupplyGalon}\n" +
                            $"AMMUNITION: {strike.AmmunitionCapacity}\n");
                             Console.WriteLine("");
                    }
                }
            }
        }


        /// <summary>
        /// A method that return and print  the most dangerous terrorist
        /// </summary>
        public void PrintMostDangerousTerrorists()
        {
            List<Terrorist> mostDangerous = Analize.GetMostDangerousTerrorists();
            int maxKey =Analize.TargetPrioritizationDict().Keys.Max();
            foreach (Terrorist terrorist in mostDangerous)
            {
                Console.WriteLine(terrorist + $"\nQUALITY SCORE: {maxKey}\nlatest known location: {AMAN.GetLastLocation(terrorist)}");
            }
        }


        public void PrintTargetPrioritization()
        {
            Dictionary<int, List<Terrorist>> dict = Analize.TargetPrioritizationDict();

            if (dict.Count == 0)
            {
                Console.WriteLine("No terrorists to display.");
                return;
            }

            Console.WriteLine("=== Target Prioritization by Risk Level ===");

            foreach (KeyValuePair<int, List<Terrorist>> kvp in dict.OrderByDescending(k => k.Key))
            {
                int riskLevel = kvp.Key;
                List<Terrorist> terrorists = kvp.Value;

                Console.WriteLine($"Risk Level: {riskLevel} - Count: {terrorists.Count}");
                foreach (Terrorist terrorist in terrorists)
                {
                    Console.WriteLine($"  - {terrorist.GetName()}, Rank: {terrorist.GetRank()}, Alive: {terrorist.GetIsAlive()}");
                }
                Console.WriteLine();
            }
        }


        


        // Prints a list of all terrorists and their known locations sorted by timestamp
        public void PrintAllTerroristLocations()
        {
            var intelligenceMessages = AMAN.GetIntelligenceMessages();

            if (intelligenceMessages.Count == 0)
            {
                Console.WriteLine("No intelligence data available.");
                return;
            }

            foreach (var pair in intelligenceMessages)
            {
                Terrorist terrorist = pair.Key;
                SortedList<DateTime, string> messages = pair.Value;

                Console.WriteLine($"Terrorist: {terrorist.GetName()}");

                foreach (var message in messages)
                {
                    Console.WriteLine($"  Time: {message.Key} | Location: {message.Value}");
                }

                Console.WriteLine();
            }
        }




        /// <summary>
        /// A method that returns an available attack tool
        /// </summary>

        private IStrikeOptions InventoryCheck(string unitKey)
        {
            List<IStrikeOptions> unitList = Static_IDF.GetStrikeDict()[unitKey];

            foreach (IStrikeOptions strike in unitList)
            {
                if (!strike.IsAvailable())
                {
                    strike.Refueling();
                    strike.AmmunitionRefill();
                }

                if (strike.IsAvailable())
                {
                    return strike;
                }
            }

            return null; 
        }




        /// <summary>
        /// attack method
        /// </summary>

        //public void StrikeExecution()//משופר
        //{
        //    List<Terrorist> mostdangerousTerrorists = Analize.GetMostDangerousTerrorists();

        //    if (mostdangerousTerrorists == null || mostdangerousTerrorists.Count == 0)
        //    {
        //        Console.WriteLine("No dangerous terrorist found.");
        //        return;
        //    }

        //    foreach (Terrorist terrorist in mostdangerousTerrorists)
        //    {
        //        string Location = AMAN.GetLastLocation(terrorist);
        //        IStrikeOptions strike = null;

        //        if (Location.Contains("home"))
        //        {
        //            strike = InventoryCheck("F16 Fighter Jet");
        //        }
        //        else if (Location.Contains("car"))
        //        {
        //            strike = InventoryCheck("Hermes 460 (zik) Drone");
        //        }
        //        else if (Location.Contains("outside"))
        //        {
        //            strike = InventoryCheck("M109 Artillery");
        //        }

        //        if (strike != null && strike.IsAvailable())
        //        {
        //            strike.attack();
        //            terrorist.IsDied();
        //            Console.WriteLine($"Mission accomplished\n\nthe terrorist {terrorist.GetName()} is alive?\n{terrorist.GetIsAlive()}\n\nStrike attack : {strike.Name}: {strike.id}\nRemaining fuel stock: {strike.FuelSupplyGalon}\nRemaining ammo stock: {strike.AmmunitionCapacity}");
        //            Hamas.RemoveTerrorist(terrorist);
        //        }
        //        else
        //        {
        //            if (strike == null)
        //            {
        //                Console.WriteLine($"Unable to attack: No available strike unit for location '{Location}'");
        //            }
        //            else if (!strike.IsAvailable())
        //            {
        //                Console.WriteLine($"Unable to attack: Strike unit '{strike.Name}' (ID: {strike.id}) is unavailable.\nFuel: {strike.FuelSupplyGalon}, Ammo: {strike.AmmunitionCapacity}");
        //            }
        //        }
        //    }
        //}

        public List<Terrorist> StrikeExecution()
        {
            List<Terrorist> terrorists = Analize.GetMostDangerousTerrorists();
            if (terrorists == null || terrorists.Count == 0)
            {
                Console.WriteLine("No dangerous terrorist found.");
                return new List<Terrorist>();
            }

            List<Terrorist> waitingList = new List<Terrorist>(terrorists);
            List<Terrorist> failedToStrike = new List<Terrorist>();
            bool anyStrikeExecuted;
            Dictionary<string, (int Fuel, int Ammo)> previousInventoryState = new Dictionary<string, (int, int)>();

            do
            {
                anyStrikeExecuted = false;

                for (int i = 0; i < waitingList.Count; i++)
                {
                    Terrorist terrorist = waitingList[i];
                    string location = AMAN.GetLastLocation(terrorist);
                    IStrikeOptions strike = null;

                    if (location.Contains("home"))
                        strike = InventoryCheck("F16 Fighter Jet");
                    else if (location.Contains("car"))
                        strike = InventoryCheck("Hermes 460 (zik) Drone");
                    else if (location.Contains("outside"))
                        strike = InventoryCheck("M109 Artillery");

                    if (strike != null && strike.IsAvailable())
                    {
                        strike.attack();
                        terrorist.IsDied();
                        Console.WriteLine($"Mission accomplished!");
                        Console.WriteLine($"The terrorist {terrorist.GetName()} is alive? {terrorist.GetIsAlive()}");
                        Console.WriteLine($"Strike used: {strike.Name} | ID: {strike.id}");
                        Console.WriteLine($"Remaining Fuel: {strike.FuelSupplyGalon}, Remaining Ammo: {strike.AmmunitionCapacity}");
                        Console.WriteLine("-----------------------------------------------------");

                        Hamas.RemoveTerrorist(terrorist);
                        waitingList.RemoveAt(i);
                        i--;
                        anyStrikeExecuted = true;
                    }
                    else
                    {
                        if (strike == null)
                        {
                            Console.WriteLine($"Unable to attack: No available strike unit for location '{location}'");
                        }
                        else if (!strike.IsAvailable())
                        {
                            Console.WriteLine($"Unable to attack: Strike unit '{strike.Name}' (ID: {strike.id}) is unavailable.");
                            Console.WriteLine($"Fuel: {strike.FuelSupplyGalon}, Ammo: {strike.AmmunitionCapacity}");
                        }
                        Console.WriteLine("-----------------------------------------------------");
                    }
                }

                // בדיקת שינויים במלאי
                var currentInventory = new Dictionary<string, (int Fuel, int Ammo)>
        {
            { "F16 Fighter Jet", GetInventoryStatus("F16 Fighter Jet") },
            { "Hermes 460 (zik) Drone", GetInventoryStatus("Hermes 460 (zik) Drone") },
            { "M109 Artillery", GetInventoryStatus("M109 Artillery") }
        };

                bool inventoryChanged = false;
                foreach (var kvp in currentInventory)
                {
                    if (!previousInventoryState.ContainsKey(kvp.Key) ||
                        previousInventoryState[kvp.Key] != kvp.Value)
                    {
                        inventoryChanged = true;
                        break;
                    }
                }

                if (!anyStrikeExecuted && !inventoryChanged)
                {
                    Console.WriteLine("No changes in inventory and no strikes executed. Stopping attempts.");
                    break;
                }

                previousInventoryState = currentInventory;

                if (!anyStrikeExecuted)
                {
                    Console.WriteLine("Waiting for inventory update before next attempt...");
                    System.Threading.Thread.Sleep(2000);
                }

            } while (waitingList.Count > 0);

            if (waitingList.Count > 0)
            {
                Console.WriteLine("Remaining terrorists after all attempts:");
                foreach (var t in waitingList)
                {
                    Console.WriteLine($" - {t.GetName()}");
                    failedToStrike.Add(t);
                }
            }

            return failedToStrike;
        }


        /// <summary>
        /// מחזירה את מצב המלאי (דלק ותחמושת) של יחידת תקיפה מסוימת.
        /// אם אין יחידה זמינה – מוחזרת ברירת מחדל של אפס.
        /// </summary>
        private (int Fuel, int Ammo) GetInventoryStatus(string strikeName)
        {
            var strike = InventoryCheck(strikeName);

            if (strike == null)
                return (0, 0);

            return ((int)strike.FuelSupplyGalon, strike.AmmunitionCapacity);
        }






        public void CommanderMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== COMANDOR MENUE ===");
                Console.WriteLine("FOR THE TERRORIST WITH THE MOST INTELLIGENCE REPORTS 1");
                Console.WriteLine("FOR STRIKE COLLECTION PLEASE PRESS 2");
                Console.WriteLine("FOR THE TERRORIST COLLECTION BY RISK PLEASE PRESS 3");
                Console.WriteLine("FOR THE MOST DENGEROUS TERRORIST PLEASE PRESS 4");
                Console.WriteLine("FOR ALL TERRORISSTS LOCATION PLEASE PRESS  5");
                Console.WriteLine("FOR ATTACK THE MOST DANGEROUS TERRORIST PLEASE PRESS 6");
                Console.WriteLine("FOR EXIT PRESS 0\n");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(AMAN.GetLatestMessageOfBiggestTerrorist());
                        break;

                    case "2":
                        PrintStrikeAvailability();
                        break;

                    case "3":
                        PrintTargetPrioritization();
                        break;

                    case "4":
                        PrintMostDangerousTerrorists();
                        break;

                    case "5":
                        PrintAllTerroristLocations();
                        break;


                    case "6":
                        StrikeExecution();
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("exit");
                        break;

                    default:
                        Console.WriteLine("try again");
                        break;
                }

                Console.WriteLine();


            }
        }
    }

}



