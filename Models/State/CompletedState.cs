namespace PostalService.Models.State
{
    public class CompletedState : IParcelState
    {
        public string StateText => "[Mottaget] Paketet är hämtat av mottagaren.";

        //Sista tillståndet, inget mer händer
        public void Handle(ParcelStatus parcelStatus)
        {
        }




    }




}
