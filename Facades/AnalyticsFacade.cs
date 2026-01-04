using Trainify.Interfaces;
using Trainify.Models;
using System.Collections.Generic;
using System.Linq;

namespace Trainify.Facades
{
    public class AnalyticsFacade
    {
        private readonly IParameterFactory _parameterFactory;

        public AnalyticsFacade(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
        }

        // Obtém a definição das métricas disponíveis no sistema
        public object GetAnalyticsList()
        {
            return new
            {
                quantAnalytics = new[]
                {
                    _parameterFactory.CreateAnalytics("Tempo total de treino", "quantitative"),
                    _parameterFactory.CreateAnalytics("Taxa de conclusão do plano", "quantitative"),
                    _parameterFactory.CreateAnalytics("Volume total de carga", "quantitative"),
                    _parameterFactory.CreateAnalytics("Número de exercícios concluídos", "quantitative")
                },
                qualAnalytics = new[]
                {
                    _parameterFactory.CreateAnalytics("Feedback do cliente sobre a sessão", "qualitative"),
                    _parameterFactory.CreateAnalytics("Percepção de Esforço (RPE)", "qualitative"),
                    _parameterFactory.CreateAnalytics("Observações do Personal Trainer", "qualitative")
                }
            };
        }

        // Obtém os dados reais de performance (Analytics) dos clientes
        public List<ClientAnalytics> GetActivityAnalytics(int? activityID)
        {
            var allAnalytics = ClientAnalyticsData.GetAllAnalytics();
            if (activityID != null)
            {
                return allAnalytics
                    .Where(analytics => analytics.ActivityID == activityID)
                    .ToList();
            }
            return allAnalytics;
        }
    }
}