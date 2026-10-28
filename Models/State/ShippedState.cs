namespace PostalService.Models.State
{
    public class ShippedState : IParcelState
    {
        public string StateText => "[Skickad] Paketet är påväg.";
        public void Handle(ParcelStatus parcelStatus)
        {

            parcelStatus.State = new SortedAtStationAState();
        }
    }
}
