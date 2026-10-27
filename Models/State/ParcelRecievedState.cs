namespace PostalService.Models.State
{
    public class ParcelRecievedState : IParcelState
    {
        public string State => "[Inlämnad] Paketet inlämnat.";
        public void Handle(ParcelStatus parcelStatus)
        {
           
            parcelStatus.State = new ShippedState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        { 
            parcelStatus.Location = newParcelLocation;
        }
    }
}
