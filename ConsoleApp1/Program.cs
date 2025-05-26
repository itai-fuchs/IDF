using System;
using System.Runtime.Remoting.Messaging;
using IDF_Operation___First_Strike.AMAN;

namespace IDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Static_IDF.GetStrikeDict();
            Console.WriteLine($"The current Chief of Staff of the IDF is: \n Major General {Static_IDF.GetCurrent_commander()}");

            Simulation simulation = new Simulation();

            // מאתחל רשימת הטרוריסטים ומוסיף ל-Hamas
            simulation.InitializingTerroristList();

            // מאתחל את כלי התקיפה ומוסיף ל-Static_IDF
            simulation.InitializingStrikeList();

            // מאתחל רשימת ההודעות ומוסיף ל-AMAN
            simulation.InitializingMessagesList();


            // בדיקה: הדפסת כל הטרוריסטים שהתווספו
            Console.WriteLine("\n\nTerrorists in Hamas:\n");
            foreach (var terrorist in Hamas.GetTerroristList())
            {
                Console.WriteLine($"\tName: {terrorist.GetName()}\n\t Rank: {terrorist.GetRank()}\n\tAlive: {terrorist.GetIsAlive()}");
                Console.WriteLine("\t Weapons: " + string.Join(", ", terrorist.GetWeapons()));
                Console.WriteLine($"\tCurrent location:{AMAN.GetLateLocation(terrorist)}\n");
            }

            // בדיקה: הדפסת כלי התקיפה שברשימת Static_IDF
            Console.WriteLine("\n\nStrike options registered in Static_IDF:\n");
            var strikeDict = Static_IDF.GetStrikeDict();
            foreach (var kvp in strikeDict)
            {
                Console.WriteLine($"Strike Name: {kvp.Key}");
                foreach (var strike in kvp.Value)
                {
                    Console.WriteLine($"\tAmmunition: {strike.AmmunitionCapacity}, Fuel: {strike.FuelSupplyGalon}");
                    Console.WriteLine($"\tEffective against: {string.Join(", ", strike.EffectiveAgainst)}");
                    Console.WriteLine($"\tAvailable? {strike.IsAvailable()}");
                }
                Console.WriteLine();
            }

            // בדיקה: הדפסת כל ההודעות שהתווספו
            Console.WriteLine("\n\nMessages in AMAN:\n");
            foreach (var messages in AMAN.GetIntelligenceMessages())
            {
                Console.WriteLine($"TerroristName: {messages.Key.GetName()}");
                foreach (var message in messages.Value)
                {
                    Console.WriteLine($"\tOn the date: {message.Key}\n\tViewed at location: {message.Value}\n");
                }
            }

            // בדיקה: הדפסת ההודעה האחרונה של המחבל עם הכי הרבה הודעות
            Console.WriteLine($"\n\n{AMAN.GetLatestMessageOfBiggestTerrorist()}\n");
        }
    }
}



