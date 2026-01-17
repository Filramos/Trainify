using Microsoft.AspNetCore.Mvc;
using Trainify.Facades;
using System.Linq;

namespace Trainify.Controllers
{
    [ApiController]
    [Route("api/ap-analytics")]
    public class APAnalyticsController : ControllerBase
    {
        private readonly AnalyticsFacade _analyticsFacade;

        // Injetamos o Facade em vez da Factory
        public APAnalyticsController(AnalyticsFacade analyticsFacade)
        {
            _analyticsFacade = analyticsFacade;
        }

        /// <summary>
        /// Retorna os dados analíticos da atividade (Valores reais).
        /// </summary>
        [HttpPost("analytics_url")]
        public IActionResult GetActivityAnalytics([FromBody] int activityID)
        {
            // O Facade devolve a lista de todos os clientes desta atividade
            var results = _analyticsFacade.GetActivityAnalytics(activityID);

            if (results == null || !results.Any())
            {
                return NotFound(new { message = "Nenhum dado encontrado para esta Atividade." });
            }

            return Ok(results);
        }

        /// <summary>
        /// Retorna a lista de definições de métricas disponíveis.
        /// </summary>
        [HttpGet("analytics_list_url")]
        public IActionResult GetAnalyticsList()
        {
            // Toda a estrutura complexa de criação de métricas agora vive no Facade
            var analyticsDefinitions = _analyticsFacade.GetAnalyticsList();
            return Ok(analyticsDefinitions);
        }
    }
}