namespace PostalService.Models.Observer
{
    public class TraceParcelIDisplay : IObserver
    {
        //Om någon söker på paket så kommer meddelande. Vid en pull kommer det här meddelandet
        public void Update()
        {
            Console.WriteLine($"Paketet finns vid ...");
        }
    }
}
