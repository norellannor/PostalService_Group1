namespace PostalService.State
{
    public interface IParcelState
    {
        void Handle(ParcelStatus parcelStatus);
        
    }
}
