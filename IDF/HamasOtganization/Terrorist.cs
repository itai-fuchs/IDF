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
        public string Name { get; set; }
       

        //rank
        public int Rank { get; set; }
       

        //is alive
        public bool IsAlive {  get; set; }
       

        //making terorist weaponsList.
        List<string> Weapons = new List<string> { };

        //get readonly weapon list.
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
            
            List<string> TempWeaponsList = new List<string>
            { "knife", "gun", "M16", "AK47" };
            List<string> selectedWeapons = new List<string>();

            for (int i = 0; i <= random.Next(1, 5); i++)
            {
                int index = random.Next(0, 4);
                if (!selectedWeapons.Contains(TempWeaponsList[index]))
                    selectedWeapons.Add(TempWeaponsList[index]);

            }
            return selectedWeapons;
        }

        public override string ToString()
        {
            return $"NAME: {Name}\n" +
                $"RANK: {Rank}\n" +
                $"WEAPONS:\n{GetWeaponsStr()}";
        }

        public string GetWeaponsStr()
        {
            string weapons = "";
            foreach (string weapon in Weapons)
            {
                weapons += weapon + ", ";
            }
            return weapons;
        }
    }
}



