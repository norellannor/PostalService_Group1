using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.WeightStrategy
{
    public class MediumWeight : IWeightStrategy
    {

        public string WeightClass => "Upptill 15kg";
        public decimal CalculateWeightPrice(decimal weight) => 20m;


    }
}
