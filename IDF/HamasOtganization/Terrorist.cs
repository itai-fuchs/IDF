using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF.HamasOtganization
{
    internal class Terrorist
    {

        //name
        string Name;
        public string GetName() { return Name; }
        //rank
        int Rank;
        public int GetRank() { return Rank; }

        //is alive
        bool IsAlive;
        public bool GetIsalive() { return IsAlive; }


        //terorist weapons
        List<string> Weapons = new List<string> { };
        public List<string> GetWeapons() { return Weapons; }



        //constractor
        public Terrorist(string name)
        {
            this.Name = name;

            //create random rank
            Random random = new Random();
            this.Rank = random.Next(1, 6);

            this.IsAlive = true;
            this.Weapons = weaponslist();
            Hamas.Terrorist_list.Add(this);


        }
        //create random weapons
        List<string> weaponslist()
        {
            Random random = new Random();
            List<string> weaponsList = new List<string> { "knife", "gun", "M16", "AK47" };

            for (int i = 0; i <= random.Next(1, 5); i++)
            {
                int index = random.Next(0, 4);
                if (!Weapons.Contains(weaponsList[index]))
                    Weapons.Add(weaponsList[index]);

            }
            return Weapons;
        }
    }
}



