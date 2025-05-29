using IDF;
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
            TerroristName = Hamas.GetTerroristList()[rnd.Next(0, Hamas.GetTerroristList().Count-1)];
            Timestamp = DateTime.Now;

            List<string> Locations = new List<string> { "home", "car", "outside" };
            LastKnownLocation = Locations[rnd.Next(0, Locations.Count-1)];

            ToDict();
        }

        private void ToDict()
        {
            if (!IntelligenceMessages.ContainsKey(TerroristName))
            {
                IntelligenceMessages[TerroristName] = new SortedList<DateTime, string>();
            }

            SortedList<DateTime, string> terroristList = IntelligenceMessages[TerroristName];

            while (terroristList.ContainsKey(Timestamp))
            {
                Timestamp = Timestamp.AddMilliseconds(1);
            }

            terroristList.Add(Timestamp, LastKnownLocation);
        }

        public static Dictionary<Terrorist, SortedList<DateTime, string>> GetIntelligenceMessages()
        {
            return IntelligenceMessages;
        }

        public static string GetLatestMessageOfBiggestTerrorist()
        {
            Dictionary<Terrorist, SortedList<DateTime, string>> intelligenceMessages = AMAN.GetIntelligenceMessages();

            if (intelligenceMessages.Count == 0)
            {
                return "No intelligence data available.";
            }

            Terrorist terroristWithMostMessages = null;
            int maxCount = 0;

            foreach (var pair in intelligenceMessages)
            {
                if (pair.Value.Count > maxCount)
                {
                    maxCount = pair.Value.Count;
                    terroristWithMostMessages = pair.Key;
                }
            }

            if (terroristWithMostMessages != null)
            {
                SortedList<DateTime, string> messages = intelligenceMessages[terroristWithMostMessages];
                int lastIndex = messages.Count - 1;
                DateTime latestTime = messages.Keys[lastIndex];
                string latestLocation = messages.Values[lastIndex];

                return $"Terrorist with the most messages: {terroristWithMostMessages.Name} Latest message time: {latestTime} Location:  {latestLocation}";
            }
            else
            {
                return "No terrorist with messages found.";
            }
        }

        public static string GetLastLocation(Terrorist terrorist)
        {
            Dictionary<Terrorist, SortedList<DateTime, string>> intelligenceMessages = AMAN.GetIntelligenceMessages();

            if (!intelligenceMessages.ContainsKey(terrorist))
            {
                return "No data available for this terrorist.";
            }

            SortedList<DateTime, string> messages = intelligenceMessages[terrorist];

            if (messages.Count == 0)
            {
                return "No messages found.";
            }

            DateTime latestTime = messages.Keys[messages.Count - 1];
            return messages[latestTime];
        }

        
        public static void GenerateIntelligence()
        {
            
            foreach (Terrorist terrorist in Hamas.GetTerroristList())
            {
                DateTime timestamp = DateTime.Now;

                List<string> Locations = new List<string> { "home", "car", "outside" };
                string location = Locations[rnd.Next(0, Locations.Count)];

                if (!IntelligenceMessages.ContainsKey(terrorist))
                {
                    IntelligenceMessages[terrorist] = new SortedList<DateTime, string>();
                }

                SortedList<DateTime, string> terroristList = IntelligenceMessages[terrorist];

                while (terroristList.ContainsKey(timestamp))
                {
                    timestamp = timestamp.AddMilliseconds(1);
                }

                terroristList.Add(timestamp, location);
            }

           
            int extraMessages = rnd.Next(10, 20);

            for (int i = 0; i < extraMessages; i++)
            {
                new AMAN(); 
            }
        }
    }
}
