using System.Net.NetworkInformation;

namespace PostalService.Models.State
{
    public class ParcelStatus
    {
        public IParcelState State { get; internal set; }
        //public string? Location { get; set; }
        public ParcelStatus()
        {
            //Starttillstånd
            State = new PendingState();
        }

        //public void NextState() => State.Handle(this);
        //public void NextState() => Console.WriteLine(State.StateText);

        //public void ChangeTo(string newLocation) => State.UpdateLocation(this, newLocation);


        public void NextState()
        {
            State.Handle(this);

            //Console.WriteLine(State.StateText);  KOMMENTERAD BORT SÅ DET INTE BLIR DUBBELT 
        }

    }


    ////Finns i program vid exempel. Detta är flödet just nu för states
    //ParcelStatus parcelStatus = new ParcelStatus();

    //parcelStatus.NextState(); //Pending => ParcelRecieved
    //parcelStatus.NextState(); //Recieved => Shipped
    //parcelStatus.NextState(); //Shipped => Delivered
    //parcelStatus.NextState(); //Delivered => PickedUp
    //parcelStatus.NextState(); //PickedUp => Completed
}


