using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.ShippingStrategy
{
    public class EconomyShipping : IShippingStrategy

    {
        public string ShippingType => "Ekonomifrakt";

        public int Priority => 3;

        public decimal BasePrice => 39m;
        public int DeliveryDays => 7;

        public DateTime CalculateEstimatedDeliveryDate(DateTime sentDate) => sentDate.AddDays(DeliveryDays);

    }
}
