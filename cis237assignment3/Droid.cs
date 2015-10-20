using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    abstract class Droid: IDroid
    {
        private string material, model, color;
        protected decimal totalCost;
        protected decimal baseCost;
        public Droid(String Material, String Model, String Color)
        {
            CalculateBaseCost(new droidModelPrice[] { new droidModelPrice("astromech", 1100m), new droidModelPrice("protocol", 1500m), new droidModelPrice("janitor", 1000m), new droidModelPrice("utility", 800m) });
            material = Material;
            model = Model;
            color = Color;
        }
        protected void CalculateBaseCost(droidModelPrice[] droidCosts)
        {
            foreach(droidModelPrice d in droidCosts)
                if (d.model.Equals(model))
                    baseCost = d.price;
        }
        public abstract void CalculateTotalCost();
        public decimal TotalCost
        {
            get
            {
                return totalCost;
            }
            set
            {
                totalCost = value;
            }
        }
        public override string ToString()
        {
            return "a " + color + " " + material + " " + model + " droid";
        }
        public static Droid CreateDroid()
        {
            return null;
        }
        
        protected static bool yesOrNo()
        {
            char pressed = 'u';
            while(!(pressed == 'y' || pressed == 'Y' || pressed == 'n' || pressed == 'N'))
            {
                int currentLineInt = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', 1));
                Console.SetCursorPosition(0, currentLineInt);
                
                pressed = Console.ReadKey().KeyChar;
                
            }
            Console.WriteLine("");
            return pressed == 'y' || pressed == 'Y';
        }
    }
}
