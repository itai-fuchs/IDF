using IDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// static class of Hamas organization
/// </summary>
internal static class Hamas
{

    private static string formation_date = "10/12/1987";
    public static string  Get_formation_date() { return formation_date; }


    private static string Current_commander = "Haled Mahshal";
    public static void Get_Current_commander() { Console.WriteLine(Current_commander);}
    public static void Set_Current_commander(string current_commander) { Current_commander = current_commander;}


    private static List<Terrorist> Terrorist_list = new List<Terrorist>();
    public static List<Terrorist> Get_Terrorist_list() { return Terrorist_list; }

    public static void AddTerroristToList(Terrorist terrorist)
    {
        Terrorist_list.Add(terrorist);
    }





}
