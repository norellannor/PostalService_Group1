namespace PostalService.Models.State
{
    public class PickedUpState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Paket har nu hämtats. Tack för att du änvänder Postal Service! :)");
            parcelStatus.State = new CompletedState();
        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string parcelLocation)
        {
            Console.WriteLine("Paketet är levererat och hämtat av mottagaren.");
        }
    }
}
