namespace PostalService.State
{
    public class DeliveredState : IParcelState
    {
        void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Byter tillstånd till...");
            parcelStatus.State = new PickedUpState();
        }
    }
}
