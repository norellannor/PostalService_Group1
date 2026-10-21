namespace PostalService.State
{
    public class CompletedState : IParcelState
    {
        void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Ordern är nu slutförd. Byter tillstånd till...");
           
        }
    }
}
