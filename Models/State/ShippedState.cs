namespace PostalService
{
    public class ShippedState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Paket är mottaget. Byter tillstånd till...");
            parcelStatus.State = new DeliveredState();
        }
    }
}
