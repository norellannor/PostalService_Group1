using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.ShippingStrategy
{
    public class ExpressShipping : IShippingStrategy
    {

        public string ShippingType => "Expressfrakt";

        public int Priority => 1;

        public decimal BasePrice => 99m;

        public DateTime CalculateEstimatedDeliveryDate(DateTime sentDate) => sentDate.AddDays(2);
    }
}
