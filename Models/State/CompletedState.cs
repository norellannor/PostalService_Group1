namespace PostalService.Models.State
{
    public class CompletedState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Leveransen är nu slutförd och paketet är hämtat.");

        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string parcelLocation)
        {
            Console.WriteLine("Paketet är levererat och hämtat av mottagaren.");
        }
    }
}
