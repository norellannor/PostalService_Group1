using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.WeightStrategy
{
    public class LightWeight : IWeightStrategy
    {

        public string WeightClass => "Upptill 2kg ";
        public decimal CalculateWeightPrice(decimal weight) => 0m;


    }
}
