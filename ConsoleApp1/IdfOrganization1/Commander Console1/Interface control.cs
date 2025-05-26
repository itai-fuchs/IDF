using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDF_Operation___First_Strike.AMAN;

namespace IDF.IdfOrganization.Commander_Console
{
    internal interface IStrategicControl
    {


       Terrorist TerroristMostReport(List<Dictionary<Terrorist, List<AMAN>>> list);
        void StrikeAvailability();

        void Target_Prioritization();
    }
}
