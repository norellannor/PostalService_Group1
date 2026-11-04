namespace PostalService.Models.State
{
    public interface IParcelState
    {
        string StateText { get; }
        void Handle(ParcelStatus parcelStatus);
   

    }
}
