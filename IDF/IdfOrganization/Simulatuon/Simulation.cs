using IDF.IdfOrganization.StrikeOptions;
using IDF_Operation___First_Strike.AMAN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    internal class Simulation
    {

        // method that Generates a list of terrorists
        public void InitializingTerroristList()
        {
            string[] firstNames = { "Mohammed", "Ahmad", "Ali", "Yasser", "Ismail", "Rami", "Mona", "Noura", "Layna", "Sameh" };
            string[] middleNames = { "Hussein", "Fares", "Nasser", "Kamel", "Amin", "Suleiman", "Jamal", "Adnan", "Mahmoud", "Tariq" };
            string[] lastNames = { "Barghouti", "Tamimi", "Khalil", "Awad", "Salem", "Qassem", "Zayyad", "Masri", "Darwish", "Abu-Laban" };

            Random random = new Random();

            for (int i = 0; i <= random.Next(10, 20); i++)
            {
                Terrorist terrorist = new Terrorist(firstNames[random.Next(0, 10)] +" "+ middleNames[random.Next(0, 10)] +" "+ lastNames[random.Next(0, 10)]);
                Hamas.AddTerrorist(terrorist);

            }
        }

        //method that Generates a dictionary of  1 attack tool lists
        public void InitializingStrikeList()
        {
            F16 f16 = new F16();
            Zik zik = new Zik();
            M109_Artillery m109_Artillery = new M109_Artillery();
            List<IStrikeOptions> strikeOptions = new List<IStrikeOptions> { f16, zik, m109_Artillery };
            Static_IDF.AddStrike(strikeOptions[0]);
            Static_IDF.AddStrike(strikeOptions[1]);
            Static_IDF.AddStrike(strikeOptions[2]);
            

        }
        ////method that Generates Generate 10–20 random intelligence messages.

        ////public void RandomInitializingMessages()
        ////{
            
        ////    Random random = new Random();

        ////    for (int i = 0; i <= random.Next(10, 20); i++)
        ////    {
        ////     AMAN message= new AMAN();
               

        ////    }
        //}
    }
}

