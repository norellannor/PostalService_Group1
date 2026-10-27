namespace PostalService.Models.State
{
    public class CompletedState : IParcelState
    {
        public string StateText => "[Hämtad] Paketet är hämtat.";
        public void Handle(ParcelStatus parcelStatus)
        {

        }

        //behöver uppdateras när vår poststation är klar
        public void UpdateLocation(ParcelStatus parcelStatus, string parcelLocation)
        {
            Console.WriteLine("Paketet är levererat och hämtat av mottagaren.");
        }
    }
}
