namespace PostalService.State
{
    public class ParcelStatus
    {
        public IParcelState State { get; set; }
        public ParcelStatus()
        {
            //Starttillstånd
            State = new PendingState();
        }

        public void NextState() => State.Handle(this);

        ////Finns i program vid exempel. Detta är flödet just nu för states
        //ParcelStatus parcelStatus = new ParcelStatus();

        //parcelStatus.NextState(); //Pending => Recieved
        //parcelStatus.NextState(); //Recieved => Shipped
        //parcelStatus.NextState(); //Shipped => Delivered
        //parcelStatus.NextState(); //Delivered => PickedUp
        //parcelStatus.NextState(); //PickedUp => Completed
    }

}
