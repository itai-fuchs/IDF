using IDF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// static class of Hamas organization
/// </summary>
internal static class Hamas
{
    //formation_date
    public static string FormationDate { get; set; } = "10/12/1987";


    //Current_commander
    public static string CurrentCommander { get; set; } = "Haled Mahshal";



    //make Terrorist_list
    private static List<Terrorist> TerroristList = new List<Terrorist>();

    //method that get readOnly terroristList.
    public static List<Terrorist> GetTerroristList()
    {
        return TerroristList;
    }


    //method that add terrorist to a list.
    public static void AddTerrorist(Terrorist terrorist)
    {
        TerroristList.Add(terrorist);
    }

    public static void RemoveTerrorist(Terrorist terrorist)
    {
        TerroristList.Remove(terrorist);
    }

}
