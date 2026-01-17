using Microsoft.AspNetCore.Mvc;
using Trainify.Models;
using Trainify.Facades;
using Trainify.Implementations.Observers;

namespace Trainify.Controllers
{
    [ApiController]
    [Route("api/ap-realization")]
    public class APRealizationController : ControllerBase
    {
        private readonly RealizationFacade _realizationFacade;

        // Injetamos o RealizationFacade e o AnalyticsFacade (necessário para o Observer)
        public APRealizationController(RealizationFacade realizationFacade, AnalyticsFacade analyticsFacade)
        {
            _realizationFacade = realizationFacade;

            // CONFIGURAÇÃO DO OBSERVER NO ARRANQUE
            // Anexamos os observadores ao "Sujeito" (Facade)
            _realizationFacade.Attach(new ActivityLoggingObserver());
            _realizationFacade.Attach(new ActivityAnalyticsObserver(analyticsFacade));
        }

        /// <summary>
        /// Realiza o deploy inicial da atividade.
        /// </summary>
        [HttpGet("user_url")]
        public IActionResult DeployActivity(int activityID)
        {
            // Agora usamos o Facade para gerar o URL
            string activityUrl = _realizationFacade.GenerateActivityUrl(activityID);
            return Ok(new { url = activityUrl });
        }

        /// <summary>
        /// Regista o acesso do CLIENTE à atividade (Gatilho para o Observer).
        /// </summary>
        [HttpPost("provide_client_activity_url")]
        public IActionResult ClientAccess([FromBody] ClientAccessRequest requestData)
        {
            // Chamamos o Facade, que executará a lógica e notificará os observadores
            string accessUrl = _realizationFacade.RegisterClientAccess(requestData.ActivityID, requestData.InveniraClientID);

            return Ok(new
            {
                message = $"Exercício número {requestData.ActivityID} vai ser realizado pelo cliente com ID {requestData.InveniraClientID}",
                url = accessUrl
            });
        }
    }
}