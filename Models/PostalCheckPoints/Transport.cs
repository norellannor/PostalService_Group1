using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.PostalCheckPoints
{
    internal class Transport
    {
        public string TransportName { get;  }
        public string Location { get; } // Under transport, på väg mot 
        public int Count => TransportQueue.Count;
        public Transport(string transportName)
        {
            TransportName = transportName;
        }
        //ändra string till paketobjekt
        private readonly Queue<string> TransportQueue =new();

        //lägg till objektet, fattas
        //public void AddParcelToTransport()
        //{
        //    TransportQueue.Enqueue();
        //}

        public void RemoveParcelFromTransport()
        { 
            var next = TransportQueue.Dequeue();
        }
    }
}
