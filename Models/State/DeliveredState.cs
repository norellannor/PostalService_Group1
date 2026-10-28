namespace PostalService.Models.State
{
    public class DeliveredState : IParcelState
    {
        public string StateText => "[Levererad] Paketet finns att hämta.";
        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new CompletedState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        {
            parcelStatus.Location = newParcelLocation;
        }
    }
}
