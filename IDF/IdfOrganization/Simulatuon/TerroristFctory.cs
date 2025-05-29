using IDF_Operation___First_Strike.AMAN;
using System;
using System.Collections.Generic;

namespace IDF.Factories
{
    internal static class TerroristFactory
    {
        private static string[] firstNames = { "Mohammed", "Ahmad", "Ali", "Yasser", "Ismail", "Rami", "Mona", "Noura", "Layna", "Sameh" };
        private static string[] middleNames = { "Hussein", "Fares", "Nasser", "Kamel", "Amin", "Suleiman", "Jamal", "Adnan", "Mahmoud", "Tariq" };
        private static string[] lastNames = { "Barghouti", "Tamimi", "Khalil", "Awad", "Salem", "Qassem", "Zayyad", "Masri", "Darwish", "Abu-Laban" };

        private static Random random = new Random();

        public static Terrorist CreateRandomTerrorist()
        {
            string fullName = $"{firstNames[random.Next(firstNames.Length)]} {middleNames[random.Next(middleNames.Length)]} {lastNames[random.Next(lastNames.Length)]}";
            return new Terrorist(fullName);
        }

        public static List<Terrorist> CreateTerroristList(int count)
        {
            var list = new List<Terrorist>();
            for (int i = 0; i < count; i++)
            {
                list.Add(CreateRandomTerrorist());
            }
            return list;
        }
    }
}
