using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.ShippingStrategy
{
    public interface IShippingStrategy
    {
        string ShippingType { get; }
        decimal BasePrice { get; }
        int Priority { get; }
        DateTime CalculateEstimatedDeliveryDate(DateTime sentDate);

    }
}
