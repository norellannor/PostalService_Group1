namespace PostalService.Models.State
{
    public interface IParcelState
    {
        string State { get; }
        void Handle(ParcelStatus parcelStatus);

        void UpdateLocation(ParcelStatus parcelStatus, string parcelLocation);

    }
}
