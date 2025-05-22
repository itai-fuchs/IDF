using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF.IdfOrganization.Commander_Console
{
    internal interface IStrategicControl
    {


       Terrorist TerroristMostReport(List<Dictionary<Terrorist, List<Aman>>> list);
        void StrikeAvailability();

        void Target_Prioritization();
    }
}
