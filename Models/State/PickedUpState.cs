namespace PostalService.State
{
    public class PickedUpState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Paket finns nu hos mottagaren. Byter tillstånd till...");
            parcelStatus.State = new CompletedState();
        }
    }
}
