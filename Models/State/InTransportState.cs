using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.State
{
    public class InTransportState : IParcelState
    {
        public string StateText => "[Under Transport]";

        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new SortedAtStationBState();
        }
    }
}
