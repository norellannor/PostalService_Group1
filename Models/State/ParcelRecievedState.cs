namespace PostalService.Models.State
{
    public class ParcelRecievedState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Paket är mottaget och redo för leverans.");
            parcelStatus.State = new ShippedState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        { 
            parcelStatus.Location = newParcelLocation;
        }
    }
}
