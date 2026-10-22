namespace PostalService.Model.State
{
    public interface IParcelState
    {
        void Handle(ParcelStatus parcelStatus);

        //alla parcelLocation behöver ändras till rätt efter vi gjort de olika stationerna ex ParcelTerminal Location typ
        void UpdateLocation(ParcelStatus parcelStatus, string parcelLocation);
        
    }
}
