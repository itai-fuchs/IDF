using System.Collections.Generic;
using IDF.IdfOrganization.StrikeOptions;

namespace IDF.Factories
{
    internal static class StrikeFactory
    {
        public static List<IStrikeOptions> CreateDefaultStrikeOptions()
        {
            return new List<IStrikeOptions>
            {
                new F16(),
                new Zik(),
                new M109_Artillery()
            };
        }
    }
}
