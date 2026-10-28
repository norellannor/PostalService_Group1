namespace PostalService.Models.Observer
{
    public interface IObserver
    {
        //alla klasser som vill lyssna måste implementera detta
        //i parantesen ska det som ska uppdateras in, vi vill uppdatera statusen på
        //ett valt paket. 
        void Update(Parcel parcel); 
    }
}
