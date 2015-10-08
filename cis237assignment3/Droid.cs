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
        private decimal totalCost;
        protected decimal baseCost;
        public Droid(String Material, String Model, String Color)
        {
            material = Material;
            model = Model;
            color = Color;
        }

        public void CalculateBaseCost(droidModelPrice[] droidCosts)
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
            return color + " " + material + " " + model + " droid";
        }
    }
}
