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
        private decimal baseCost, totalCost;

        public virtual void CalculateBaseCost()
        {
            baseCost = 2000m;
            
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
    }
}
