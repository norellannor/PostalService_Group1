namespace postalservice.Models.State
{
    public interface IParcelState
    {
        void Handle(ParcelStatus parcelStatus);
        
    }
}
