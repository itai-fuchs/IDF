using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
 
    internal class Terrorist
    {

        //name
        private string Name;
        public string GetName() { return Name; }
        //rank
        private int Rank;
        public int GetRank() { return Rank; }

        //is alive
        private bool IsAlive;
        public bool GetIsAlive() { return IsAlive; }
        public void SetIsAlive(bool is_alive) { IsAlive = is_alive; }



        //terorist weapons
        List<string> Weapons = new List<string> { };

        //return copy of weapon list
        public List<string> GetWeapons() { return new List<string>(Weapons);}

        //constractor
        public Terrorist(string name)
        {
            this.Name = name;
            Random random = new Random();
            this.Rank = random.Next(1, 6);
            this.IsAlive = true;
            this.Weapons = weaponslist();
            Hamas.AddTerroristToList(this);
        }

        //create random weapons_list
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



