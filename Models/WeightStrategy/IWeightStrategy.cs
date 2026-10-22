using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.WeightStrategy
{
    public interface IWeightStrategy
    {
        string WeightClass { get; }
        decimal CalculateWeightPrice(decimal weight);
    }
}
