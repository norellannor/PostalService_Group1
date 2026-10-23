using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.PostalCheckPoints
{
    internal class ParcelStation
    {
        public required string Location { get; init; }
        public int Priority { get; }
        public DateTime ParcelRecievedDate { get; }
        private readonly PriorityQueue<string, (int, DateTime)> ParcelStationQueue = new();
    }
}
