namespace PostalService.Models.State
{
    public class PendingState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"[Registrerat] Paket är registrerat och är redo för att lämnas in.");
            parcelStatus.State = new ParcelRecievedState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string newParcelLocation)
        {
            parcelStatus.Location = newParcelLocation;
        }
    }
}
