using Trainify.Interfaces;

namespace Trainify.Implementations.Observers
{
    public class ActivityLoggingObserver : IActivityObserver
    {
        public void Update(Models.ClientAccessRequest request)
        {
            // Implementação para logging
            Console.WriteLine($"Log: Cliente {request.InveniraClientID} acedeu a atividade {request.ActivityID}");
        }
    }
}
