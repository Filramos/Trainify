namespace Trainify.Interfaces
{
    public interface IActivitySubject
    {
        void Attach(IActivityObserver observer);
        void Detach(IActivityObserver observer);
        void NotifyObservers(Models.ClientAccessRequest request);
    }
}