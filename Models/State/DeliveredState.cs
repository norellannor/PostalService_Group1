namespace PostalService.Models.State
{
    public class DeliveredState : IParcelState
    {
        public string StateText => "[Levererad] Paketet finns att hämta.";
        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new CompletedState();
        }
    }
}
