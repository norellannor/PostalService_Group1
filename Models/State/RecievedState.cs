namespace PostalService.State
{
    public class RecievedState : IParcelState
    {
        public void Handle(ParcelStatus parcelStatus)
        {
            Console.WriteLine($"Paket är mottaget. Byter tillstånd till...");
            parcelStatus.State = new ShippedState();
        }
    }
}
