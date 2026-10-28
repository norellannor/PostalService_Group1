namespace PostalService.Models.State
{
    public class PendingState : IParcelState
    {
        
        public string StateText => "[Registrerat] Paketet är registrerat och redo att lämnas in.";

        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new ParcelRecievedState();
        }
    }

}
