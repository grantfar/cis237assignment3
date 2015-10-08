using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    class UtilityDroid : Droid
    {
        private bool toolBox, computerConnection, arm;
        public UtilityDroid(String material, String color, bool Toolbox, bool ComputerConnection, bool Arm) : base(material, "utility", color) 
        {
            toolBox = Toolbox;
            computerConnection = ComputerConnection;
            arm = Arm;
        }
        public override void CalculateTotalCost()
        {
            TotalCost = base.baseCost;
            if(toolBox)
                TotalCost += 500m;
            if(computerConnection)
                TotalCost += 700m;
            if (arm)
                TotalCost += 300m;
        }
        protected virtual string optionsString()
        {
            List<String> returnStrings = new List<string>();
            String returnString = "";
            if (!(toolBox || computerConnection || arm))
                return "no options";
            if (toolBox)
                returnStrings.Add("a toolbox");
            if (computerConnection)
                returnStrings.Add("a computer connections");
            if (arm)
                returnStrings.Add("an arm");
            for(int i = 0; i < returnStrings.Count-1; i++)
                returnString += returnStrings[i] + ", "; 
            if (returnStrings.Count != 1)
                returnString += "and ";
            returnString += returnStrings[returnStrings.Count - 1];
            return returnString;
        }
        public override string ToString()
        {
            return base.ToString() + " with " + optionsString();
        }
    }
}
