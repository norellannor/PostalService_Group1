namespace PostalService.Models.State
{
    public class DeliveredState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"P[Levererad Paketet finns att hämta." );
            parcelStatus.State = new CompletedState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        {
            parcelStatus.Location = newParcelLocation;
        }
    }
}
