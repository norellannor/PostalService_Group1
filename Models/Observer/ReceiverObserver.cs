namespace PostalService.Models.Observer
{
    public class ReceiverObserver : IObserver
    {
        //Om någon söker på paket så kommer meddelande. Vid en pull kommer det här meddelandet
        public void Update(string message)
        {
            Console.WriteLine($"Paketet finns vid ...");
        }
    }
}
