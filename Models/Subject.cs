using postalservice.Models.Observer;

namespace postalservice.Models
{
    public class Subject
    {
        //håller reda på alla lyssnare, behöver fyllas på (kompletera när vi vet mer)
       
       
        private readonly List<IObserver> _observers = new List<IObserver>();

        //registrera en ny lyssnare 
        public void Attach(IObserver observer) => _observers.Add(observer);
        
        //ta bort en lyssnare 
        public void Detach(IObserver observer) => _observers.Remove(observer);

        //Uppdatera status och meddela alla automatiskt 
        public void SetStatus()
        {
            //fattas
            Notify();
        }

        //Behöver kompleteras med info om vad som ska uppdaters
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }




    }
}
