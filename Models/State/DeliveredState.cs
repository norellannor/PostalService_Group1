namespace PostalService.Models.State
{
    public class DeliveredState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Paket finns nu vid .... och är redo för att hämtas.");
            parcelStatus.State = new PickedUpState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        {
            parcelStatus.Location = newParcelLocation;
        }
    }
}
