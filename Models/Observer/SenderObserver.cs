using PostalService.Models.State;

namespace PostalService.Models.Observer
{
    public class SenderObserver : IObserver
    {
        //behöver kompletteras med vad som ska uppdateras 
        public void Update(Parcel parcel)
        {
            Customer sender = parcel.Sender;

            if (parcel.Status.State is ParcelRecievedState)
            {
                Console.WriteLine($"[SMS till {sender.PhoneNumber}] Hej {sender.Name}! " + $"Ditt paket {parcel.Id} är inlämnat");
            }
            else if (parcel.Status.State is CompletedState)
            {
                Console.WriteLine($"[SMS till {sender.PhoneNumber}] Hej {sender.Name}! " + $"Ditt paket {parcel.Id} är levererat till mottagaren.");
            }

        }
    }
}
