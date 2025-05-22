using System;

namespace IDF
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Static_IDF.GetStrikeDict();
            Console.WriteLine(Static_IDF.GetCurrent_commander());

            //    Simulation simulation = new Simulation();

            //    // מאתחל רשימת הטרוריסטים ומוסיף ל-Hamas
            //    simulation.InitializingTerroristList();

            //    // מאתחל את כלי התקיפה ומוסיף ל-Static_IDF
            //    simulation.InitializingStrikeList();

            //    // בדיקה: הדפסת כל הטרוריסטים שהתווספו
            //    Console.WriteLine("Terrorists in Hamas:");
            //    foreach (var terrorist in Hamas.Get_Terrorist_list())
            //    {
            //        Console.WriteLine($"Name: {terrorist.GetName()}, Rank: {terrorist.GetRank()}, Alive: {terrorist.GetIsAlive()}");
            //        Console.WriteLine("Weapons: " + string.Join(", ", terrorist.GetWeapons()));
            //        Console.WriteLine();
            //    }

            //    // בדיקה: הדפסת כלי התקיפה שברשימת Static_IDF
            //    Console.WriteLine("Strike options registered in Static_IDF:");
            //    var strikeDict = Static_IDF.GetStrikeDict();
            //    foreach (var kvp in strikeDict)
            //    {
            //        Console.WriteLine($"Strike Name: {kvp.Key}");
            //        foreach (var strike in kvp.Value)
            //        {
            //            Console.WriteLine($"  Ammunition: {strike.Ammunition_capacity}, Fuel: {strike.Fuel_supply_Galon}");
            //            Console.WriteLine($"  Effective against: {string.Join(", ", strike.Effective_against)}");
            //            Console.WriteLine($"  Available? {strike.IsAvailable()}");
            //        }
            //        Console.WriteLine();
            //    }
        }


    }
}



