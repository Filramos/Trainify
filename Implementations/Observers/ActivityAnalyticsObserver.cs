using Trainify.Interfaces;

namespace Trainify.Implementations.Observers
{
    public class ActivityAnalyticsObserver : IActivityObserver
    {
        private readonly Facades.AnalyticsFacade _analyticsFacade;

        public ActivityAnalyticsObserver(Facades.AnalyticsFacade analyticsFacade)
        {
            _analyticsFacade = analyticsFacade;
        }

        public void Update(Models.ClientAccessRequest request)
        {
            // Implementação para atualizar analytics
            Console.WriteLine($"Analytics atualizados para atividade {request.ActivityID}");
        }
    }
}