namespace PostalService.Models.State
{
    public class ShippedState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Paket finns nu hos oss och befinner sig just nu...");
            parcelStatus.State = new DeliveredState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        {
            parcelStatus.Location = newParcelLocation;
        }
    }
}
