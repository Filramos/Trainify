using Microsoft.AspNetCore.Mvc;
using Trainify.Interfaces;
using Trainify.Models;
using System.Collections.Generic;

namespace Trainify.Controllers
{
    [ApiController]
    [Route("api/ap-analytics")]
    public class APAnalyticsController : ControllerBase
    {
        private readonly IParameterFactory _parameterFactory;

        // Construtor com Injeção de Dependência (Best Practice)
        public APAnalyticsController(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
        }

        /// <summary>
        /// Retorna os dados analíticos da atividade (Valores reais).
        /// </summary>
        [HttpPost("analytics_url")]
        public IActionResult GetActivityAnalytics([FromBody] int activityID)
        {
            // Nota: Certifique-se que a classe de dados se chama ClientAnalyticsData ou ClientAnalyticsData
            // conforme o que definiu no passo anterior. Aqui uso ClientAnalyticsData para consistência.
            var allAnalytics = ClientAnalyticsData.GetAllAnalytics();

            var activityAnalytics = allAnalytics.Find(analytics => analytics.ActivityID == activityID);

            if (activityAnalytics == null)
            {
                return NotFound(new { message = "Nenhum dado encontrado para o ID da Atividade fornecido." });
            }

            return Ok(activityAnalytics);
        }

        /// <summary>
        /// Retorna a lista de definições de analytics disponíveis (Menu de métricas).
        /// Baseado no Anexo II da Proposta.
        /// </summary>
        [HttpGet("analytics_list_url")]
        public IActionResult GetAnalyticsList()
        {
            var analytics = new
            {
                // Métricas Quantitativas
                quantAnalytics = new[]
                {
                    // "Tempo total, em minutos, que o cliente dedicou à atividade"
                    _parameterFactory.CreateAnalytics("Tempo total de treino", "quantitative"),
                    
                    // "Percentagem de exercícios... completados"
                    _parameterFactory.CreateAnalytics("Taxa de conclusão do plano", "quantitative"),
                    
                    // "Volume total de treino (Séries x Repetições x Carga)"
                    _parameterFactory.CreateAnalytics("Volume total de carga", "quantitative"),
                    
                    // "Número total de exercícios... concluídos"
                    _parameterFactory.CreateAnalytics("Número de exercícios concluídos", "quantitative")
                },

                // Métricas Qualitativas (Anexo II)
                qualAnalytics = new[]
                {
                    // "Feedback fornecido pelo cliente"
                    _parameterFactory.CreateAnalytics("Feedback do cliente sobre a sessão", "qualitative"),
                    
                    // "Autoavaliação do cliente sobre a dificuldade (1-10)"
                    // Nota: Embora seja um número (integer), a proposta coloca-o sob 'qualAnalytics'
                    _parameterFactory.CreateAnalytics("Percepção de Esforço (RPE)", "qualitative"),
                    
                    // "Observações qualitativas feitas pelo trainer"
                    _parameterFactory.CreateAnalytics("Observações do Personal Trainer", "qualitative")
                }
            };

            return Ok(analytics);
        }
    }
}