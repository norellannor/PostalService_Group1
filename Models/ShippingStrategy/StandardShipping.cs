using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.ShippingStrategy
{
    public class StandardShipping : IShippingStrategy
    {
        public string ShippingType => "Standardfrakt";

        public decimal BasePrice => 40m;
        public DateTime CalculateEstimatedDeliveryDate(DateTime sentDate) => sentDate.AddDays(3);
    }
}
