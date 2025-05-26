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
    private static string FormationDate = "10/12/1987";
    public static string  GetFormationDate() { return FormationDate; }


    //Current_commander
    private static string CurrentCommander = "Haled Mahshal";
    public static void GetCurrentCommander() { Console.WriteLine(CurrentCommander);}


    //make Terrorist_list
    private static List<Terrorist> TerroristList = new List<Terrorist>();

    //method that get readOnly terroristList.
    public static ReadOnlyCollection<Terrorist> GetTerroristList()
    {
        return TerroristList.AsReadOnly();
    }


    //method that add terrorist to a list.
    public static void AddTerroristToList(Terrorist terrorist)
    {
        TerroristList.Add(terrorist);
    }





}
