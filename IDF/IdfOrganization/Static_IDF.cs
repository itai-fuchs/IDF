using System;
using System.Collections.Generic;


namespace IDF
{
    /// <summary>
    /// A static IDF department contains a dictionary of attack tools.
    /// </summary>
    internal static class Static_IDF
    {
        // formation_date

        private static string formation_date = "26/05/1948";
        public static string  Get_formation_date() {return formation_date;}


        // Current_commander
        private static string Current_commander = "Eyal zamir";
        public static string GetCurrent_commander() { return Current_commander; }


        //// make dict of strike option
        private static Dictionary<string, List<IStrikeOptions>> StrikeDict = new Dictionary<string, List<IStrikeOptions>>();


        //function of   Register Strike option to the dict
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

        // function that return the dict in readonly format.
        public static IReadOnlyDictionary<string,List< IStrikeOptions>> GetStrikeDict()
        {
            return StrikeDict;
        }


    }
}
