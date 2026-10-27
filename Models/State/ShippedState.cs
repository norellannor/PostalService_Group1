namespace PostalService.Models.State
{
    public class ShippedState : IParcelState
    {
        public string StateText => "[Skickad] Paketet är påväg.";
        public void Handle(ParcelStatus parcelStatus)
        {

            parcelStatus.State = new DeliveredState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        {
            parcelStatus.Location = newParcelLocation;
        }
    }
}
