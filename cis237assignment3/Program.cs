using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            droidModelPrice[] listOfPrices =  {new droidModelPrice("astromech",1000m),new droidModelPrice("protocal",1300m), new droidModelPrice("janitor", 800m) };
            UtilityDroid ut1 = new UtilityDroid("iron", "golden", true, true, true);
            UtilityDroid ut2 = new UtilityDroid("iron", "golden", true, false, true);
            UtilityDroid ut3 = new UtilityDroid("iron", "golden", false, false , true);
            UtilityDroid ut4 = new UtilityDroid("iron", "golden", false, false, false);
            Console.WriteLine(ut1.ToString());
            Console.WriteLine(ut2.ToString());
            Console.WriteLine(ut3.ToString());
            Console.WriteLine(ut4.ToString());
        }
    }
}
