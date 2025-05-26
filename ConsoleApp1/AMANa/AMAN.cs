using IDF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Collections;

namespace IDF_Operation___First_Strike.AMAN
{
    internal class AMAN
    {
        private static readonly Random rnd = new Random();

        private Terrorist TerroristName;
        private DateTime Timestamp;
        private string LastKnownLocation;

        public static Dictionary<Terrorist, SortedList<DateTime, string>> IntelligenceMessages = new Dictionary<Terrorist, SortedList<DateTime, string>>();
        public AMAN()
        {
            TerroristName = Hamas.GetTerroristList()[rnd.Next(Hamas.GetTerroristList().Count)];
            Timestamp = DateTime.Now;

            Dictionary<string, List<string>> Locations = new Dictionary<string, List<string>> { ["home"] = new List<string> { "مخيم جباليا، زقاق رقم 5، بيت 17", "حي الشيخ رضوان، شارع المدارس، منزل رقم 55", "مخيم النصيرات، المنطقة B2، بيت عائلة الزويدي", "مخيم البريج، شارع السوق، منزل 23", "حي تل الزعتر، بجانب مدرسة العودة، بيت رقم 6", "حي الزيتون، شارع البستان، بيت 70", "شارع الثورة، حي الدرج، منزل رقم 9", "شارع النصر 49، الطابق الرابع، برج سبأ", "شارع حسن البنا، الطابق الأول، غزة", "شارع اليرموك، عمارة الأندلس، شقة 3", "شارع جمال عبد الناصر 88، الطابق الثاني، غزة", "شارع أحمد ياسين، عمارة القدس، غزة", "شارع حسن البنا، الطابق الأول، غزة", }, ["car"] = new List<string> { "شارع الوحدة 12، حي الرمال، غزة", "شارع صلاح الدين 220، شرق غزة", "شارع الكتيبة 73، وسط غزة", "شارع الصناعة 33، حي الصبرة، غزة", "شارع فلسطين، مقابل منتزه البلدية، غزة", "شارع بغداد، منطقة تل الهوا، غزة", "شارع بني عامر، حي الشعف، غزة", "شارع الإمام الشافعي، حي الزيتون، بيت 31", "مخيم دير البلح، شارع الوحدة، منزل 45", "شارع الكرامة، عمارة الريان، حي الرمال الجنوبي", }, ["outside"] = new List<string> { "شارع الشهداء 104، مبنى رقم 3، حي التفاح", "شارع أبو حصيرة 5، عمارة الأمل، غزة", "شارع عمر المختار 14، عمارة الفردوس، غزة", "شارع المغربي، قرب مستشفى الشفاء، غزة", "شارع البركة، قرب الجامعة الإسلامية، غزة", "شارع الثلاثيني، مقابل مسجد النور، غزة", "شارع خليل الوزير، برج العودة، غزة", "مخيم المغازي، شارع الجامع الكبير، غزة الوسطى", "حي تل الزعتر، بجانب مدرسة العودة، بيت رقم 6", "حي الزيتون، شارع البستان، بيت 70" } };
            //Random category
            List<string> keys = Locations.Keys.ToList();
            string randomCategory = keys[rnd.Next(keys.Count)];
            //Random address
            List<string> addressList = Locations[randomCategory];
            string randomAddress = addressList[rnd.Next(addressList.Count)];
            LastKnownLocation = $"{randomCategory} \n\t address: {randomAddress}\n";

            ToDict();
        }

        private void ToDict()
        //Adding the information to the SortedList, and preventing date conflicts
        {
            if (!IntelligenceMessages.ContainsKey(TerroristName))
            {
                IntelligenceMessages[TerroristName] = new SortedList<DateTime, string>();
            }

            SortedList<DateTime, string> terroristList = IntelligenceMessages[TerroristName];

            do
            //Gives a random time and makes sure each message has a different date:
            {
                Timestamp = Timestamp
                    .AddSeconds(rnd.Next(0, 60))
                    .AddMinutes(rnd.Next(0, 60))
                    .AddHours(rnd.Next(0, 24))
                    .AddDays(rnd.Next(0, 30))
                    .AddMonths(rnd.Next(0, 4));
            }
            while (terroristList.ContainsKey(Timestamp));

                terroristList.Add(Timestamp, LastKnownLocation);
        }

        public static Dictionary<Terrorist, SortedList<DateTime, string>> GetIntelligenceMessages()
        //Returns IntelligenceMessages for analysis
        {
            return IntelligenceMessages;
        }

        public static string GetLatestMessageOfBiggestTerrorist()
        // Returns the latest message of the terrorist who has the most messages.
        {
            Dictionary<Terrorist, SortedList<DateTime, string>> intelligenceMessages = AMAN.GetIntelligenceMessages();

            if (intelligenceMessages.Count == 0)
            {
                return "No intelligence data available.";
            }

            // Find the terrorist with the most messages and give his last one.
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

                return $"Terrorist with the most messages:{ terroristWithMostMessages.GetName()}\n\tLatest message time:{latestTime}\n\tLocation:  {latestLocation}";
            }
            else
            {
                return "No terrorist with messages found.";
            }
        }
        public static string GetLateLocation(Terrorist terrorist)
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

    }
}
;