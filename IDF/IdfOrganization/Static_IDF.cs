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

        private static string FormationDate = "26/05/1948";
        public static string  GetFormationDate() {return FormationDate;}


        // Current_commander
        private static string CurrentCommander = "Eyal zamir";
        public static string GetCurrentCommander() { return CurrentCommander; }


        //// make dict of strike option
        private static Dictionary<string, List<IStrikeOptions>> StrikeDict = new Dictionary<string, List<IStrikeOptions>>();


        //method of Register Strike option to the dict
        public static void AddStrike(IStrikeOptions strike)
        {

            if (StrikeDict.ContainsKey(strike.Name))
            {
                StrikeDict[strike.Name].Add(strike);
            }
            else
            {
                StrikeDict[strike.Name] = new List<IStrikeOptions> {strike};
            }
        }

        // method that return the strike dict.
        public static Dictionary<string,List< IStrikeOptions>> GetStrikeDict()
        {
            return StrikeDict;
        }


    }
}
