using PostalService.Models.State;

namespace PostalService.Models.Observer
{
    public class ReceiverObserver : IObserver
    {
        public void Update(Parcel parcel)
        {
            // Om paketet är någonannanstans än vid ombud B så gör vi ingenting. 
            if (parcel.Status.State is not DeliveredState)
            {
                return;
            }

            // Hämta mottagaren från paketet
            Customer receiver = parcel.Receiver;

            // "Skicka" meddelandet
            Console.WriteLine($"[SMS till {receiver.PhoneNumber}] Hej {receiver.Name}! " + $"Ditt paket {parcel.Id} är redo att hämtas på.");
        }
    }
}
