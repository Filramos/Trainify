using System.Collections.Generic;

namespace Trainify.Models
{
    public class ClientAnalyticsData
    {
        public static List<ClientAnalytics> GetAllAnalytics()
        {
            return new List<ClientAnalytics>
            {
                // Cliente 1 - Bom desempenho
                new ClientAnalytics
                {
                    InveniraClientID = 1001,
                    ActivityID = 1,
                    QuantAnalytics = new List<QuantitativeAnalytic>
                    {
                        new QuantitativeAnalytic { Name = "Tempo total de treino", Value = 65.5 }, // minutos
                        new QuantitativeAnalytic { Name = "Taxa de conclusão do plano", Value = 100.0 }, // %
                        new QuantitativeAnalytic { Name = "Volume total de carga", Value = 5250.0 }, // kg
                        new QuantitativeAnalytic { Name = "Número de exercícios concluídos", Value = 8 }
                    },
                    QualAnalytics = new List<QualitativeAnalytic>
                    {
                        new QualitativeAnalytic { Name = "Feedback do cliente sobre a sessão", Value = "Senti-me com energia, aumentei a carga no supino." },
                        new QualitativeAnalytic { Name = "Percepção de Esforço (RPE)", Value = 8 }, // Escala 1-10
                        new QualitativeAnalytic { Name = "Observações do Personal Trainer", Value = "Excelente técnica, manteve a postura correta." }
                    }
                },
                // Cliente 2 - Dificuldades
                new ClientAnalytics
                {
                    InveniraClientID = 1002,
                    ActivityID = 1,
                    QuantAnalytics = new List<QuantitativeAnalytic>
                    {
                        new QuantitativeAnalytic { Name = "Tempo total de treino", Value = 40.0 },
                        new QuantitativeAnalytic { Name = "Taxa de conclusão do plano", Value = 75.0 },
                        new QuantitativeAnalytic { Name = "Volume total de carga", Value = 3000.0 },
                        new QuantitativeAnalytic { Name = "Número de exercícios concluídos", Value = 6 }
                    },
                    QualAnalytics = new List<QualitativeAnalytic>
                    {
                        new QualitativeAnalytic { Name = "Feedback do cliente sobre a sessão", Value = "Muitas dores musculares, não consegui acabar." },
                        new QualitativeAnalytic { Name = "Percepção de Esforço (RPE)", Value = 9 },
                        new QualitativeAnalytic { Name = "Observações do Personal Trainer", Value = "Cliente precisa de descansar mais entre séries." }
                    }
                }
            };
        }
    }
}