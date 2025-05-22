using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IDF_Operation___First_Strike.AMAN
{
    internal class AMAN
    {
        static Random rnd = new Random();

        private Terrorist TerroristName;
        private DateTime Timestamp;
        private string LastKnownLocation;

        public static Dictionary<Terrorist, SortedList<DateTime, string>> IntelligenceMessages = new Dictionary<Terrorist, SortedList<DateTime, string>>();
        public AMAN()
        {
            TerroristName = Hamas.GetTerroristList[rnd.Next(Hamas.GetTerroristList.Count)];
            Timestamp = DateTime.Now;

            List<string> Locations = new List<string> { "home", "car", "outside" };
            LastKnownLocation = Locations[rnd.Next(Locations.Count)];

            ToDict();
        }

        private void ToDict()
        //Adding the information to the SortedList, and preventing date conflicts
        {
            if (!IntelligenceMessages.ContainsKey(TerroristName))
            {
                IntelligenceMessages[TerroristName] = new SortedList<DateTime, string>();
            }

            var list = IntelligenceMessages[TerroristName];
            while (list.ContainsKey(Timestamp))
            {
                Timestamp = Timestamp.AddMilliseconds(1);
            }

            list.Add(Timestamp, LastKnownLocation);
        }

        public static Dictionary<Terrorist, SortedList<DateTime, string>> GetIntelligenceMessages()
        //Returns IntelligenceMessages for analysis
        {
            return IntelligenceMessages;
        }

    }
}
