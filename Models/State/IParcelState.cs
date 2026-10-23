namespace PostalService.Models.State
{
    public interface IParcelState
    {
        void Handle(ParcelStatus parcelStatus);

        void UpdateLocation(ParcelStatus parcelStatus, string parcelLocation);

    }
}
