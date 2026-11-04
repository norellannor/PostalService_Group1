namespace PostalService.Models.State
{
    public class ParcelRecievedState : IParcelState
    {
        public string StateText => "[Inlämnat] Paketet är inlämnat vid ";

        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new ShippedState();
        }
        
    }
}
