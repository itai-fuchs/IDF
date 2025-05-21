using IDF;

using IDF.IdfOrganization.StrikeOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
         zik a = new zik();
            Terrorist bibi = new Terrorist("itai");

            Console.WriteLine(Static_IDF.GetStrikeDict()[a.Name][0].Name);

        }
    }
}



