namespace PostalService.Model.State
{
    public class ParcelStatus
    {
        public IParcelState State { get; set; }
        public string Location { get; set; }
        //public ParcelStation? Location { get; set; }
        //Om vi får Location från ParcelStation, ? betyder att det får vara null
        public ParcelStatus()
        {
            //Starttillstånd
            State = new PendingState();
        }

        public void NextState() => State.Handle(this);

        public void ChangeTo(string Location) => State.UpdateLocation(this, Location);

        ////Finns i program vid exempel. Detta är flödet just nu för states
        //ParcelStatus parcelStatus = new ParcelStatus();

        //parcelStatus.NextState(); //Pending => ParcelRecieved
        //parcelStatus.NextState(); //Recieved => Shipped
        //parcelStatus.NextState(); //Shipped => Delivered
        //parcelStatus.NextState(); //Delivered => PickedUp
        //parcelStatus.NextState(); //PickedUp => Completed
    }

}
