using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF
{
    /// <summary>
    /// A class that represents details about a terrorist.
    /// </summary>
    internal class Terrorist
    {
       

        //create random numbers
        private static Random random = new Random();

        //name
        private string Name;
        public string GetName() { return Name; }

        //rank
        private int Rank;
        public int GetRank() { return Rank; }

        //is alive
        private bool IsAlive;
        public bool GetIsAlive() { return IsAlive; }
        public void IsDied(bool is_alive) { IsAlive = is_alive; }



        //making terorist weaponsList.
        List<string> Weapons = new List<string> { };

        //get redonly weapon list.
        public ReadOnlyCollection<string> GetWeapons() => Weapons.AsReadOnly();


        //constractor
        public Terrorist(string name)
        {
            this.Name = name;
          
            this.Rank = random.Next(1, 6);
            this.IsAlive = true;
            this.Weapons = weaponslist();
           
        }

        //create random weapons_list
        List<string> weaponslist()
        {
            
            List<string> TempWeaponsList = new List<string> { "knife", "gun", "M16", "AK47" };
            List<string> selectedWeapons = new List<string>();

            for (int i = 0; i <= random.Next(1, 5); i++)
            {
                int index = random.Next(0, 4);
                if (!selectedWeapons.Contains(TempWeaponsList[index]))
                    selectedWeapons.Add(TempWeaponsList[index]);

            }
            return selectedWeapons;
        }

        
        }
}



