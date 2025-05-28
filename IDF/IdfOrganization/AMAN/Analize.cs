using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    static internal class Analize
    {


        /// <summary>
        /// A method that returns a dictionary of terrorists sorted by risk level
        /// </summary>
        /// <returns></returns>
        static public Dictionary<int, List<Terrorist>> TargetPrioritizationDict()
        {
            Dictionary<int, List<Terrorist>> ListedByRiskLevel = new Dictionary<int, List<Terrorist>>();



            foreach (Terrorist terrorist in Hamas.GetTerroristList())
            {
                int qualityScore = 0;
                if (terrorist.GetIsAlive())
                {
                    foreach (string weapon in terrorist.GetWeapons())
                    {
                        if (weapon == "knife") qualityScore += 1;

                        else if (weapon == "gun") qualityScore += 2;
                        else qualityScore += 3;
                    }
                    qualityScore = terrorist.GetRank() * qualityScore;
                    if (!ListedByRiskLevel.ContainsKey(qualityScore))
                    {
                        ListedByRiskLevel[qualityScore] = new List<Terrorist>();
                    }
                    ListedByRiskLevel[qualityScore].Add(terrorist);
                }

            }
            return ListedByRiskLevel;
        }


        static public List<Terrorist> GetMostDangerousTerrorists()
        {

            if (TargetPrioritizationDict().Count == 0)
            {
                Console.WriteLine("No intelligence messages found.");
                return null;
            }

            Dictionary<int, List<Terrorist>> temp = TargetPrioritizationDict();
            int maxKey = temp.Keys.Max();
            return temp[maxKey];
        }
    }

}




