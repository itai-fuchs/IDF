using IDF.HamasOtganization;
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
          Terrorist a = new Terrorist("muhamad");
            Terrorist b = new Terrorist("muhamad");


            Console.Write(Hamas.Terrorist_list[1].GetRank());
            
          
        }
    }
}
