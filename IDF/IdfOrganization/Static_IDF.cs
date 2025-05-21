using System;
using System.Collections.Generic;

namespace IDF
{
    internal static class Static_IDF
    {
        // formation_date
        static string formation_date = "26/05/1948";
        public static void Get_formation_date() { Console.WriteLine(formation_date); }


        // Current_commander
        private static string Current_commander = "Eyal zamir";
        public static void Get_Current_commander() { Console.WriteLine(Current_commander); }


        //// strikeOpetionsDict <string,IStrikeOptions>
        private static Dictionary<string, List<IStrikeOptions>> StrikeDict = new Dictionary<string, List<IStrikeOptions>>();


        public static void RegisterStrike(IStrikeOptions strike)
        {

            if (StrikeDict.ContainsKey(strike.Name))
            {
                StrikeDict[strike.Name].Add(strike);
            }
            else
            {
                StrikeDict[strike.Name] = new List<IStrikeOptions> { strike };
            }
        }

        public static IReadOnlyDictionary<string,List< IStrikeOptions>> GetStrikeDict()
        {
            return StrikeDict;
        }


    }
}
