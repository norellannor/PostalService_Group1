namespace PostalService.State
{
    public interface IParcelState
    {
        void Handle(ParcelStatus parcelStatus);
        void UpdateLocation(ParcelStatus parcelStatus, string );
        
    }
}
