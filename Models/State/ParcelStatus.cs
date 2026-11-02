using System.Net.NetworkInformation;

namespace PostalService.Models.State
{
    public class ParcelStatus
    {
        public IParcelState State { get; internal set; }
        
        public ParcelStatus()
        {
            //Starttillstånd
            State = new PendingState();
        }

        


        public void NextState()
        {
            State.Handle(this);

            //Console.WriteLine(State.StateText);  KOMMENTERAD BORT SÅ DET INTE BLIR DUBBELT 
        }

    }

}


