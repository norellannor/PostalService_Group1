using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.WeightStrategy
{
    public class HeavyWeight : IWeightStrategy
    {

        public string WeightClass => "över 15kg";
        public decimal CalculateWeightPrice(decimal weight) => 30m;


    }
}
