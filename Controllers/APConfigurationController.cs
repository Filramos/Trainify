using Microsoft.AspNetCore.Mvc;
using Trainify.Facades;

namespace Trainify.Controllers
{
    [ApiController]
    [Route("api/ap-configuration")]
    public class APConfigurationController : ControllerBase
    {
        private readonly ConfigurationFacade _configFacade;

        // Agora injetamos o FACADE e não a Factory diretamente
        public APConfigurationController(ConfigurationFacade configFacade)
        {
            _configFacade = configFacade;
        }

        [HttpGet("config_url")]
        public ActionResult GetConfigurationPage()
        {
            // O Controller apenas pede o conteúdo ao Facade
            string htmlContent = _configFacade.GetConfigurationPageHtml();
            return Content(htmlContent, "text/html; charset=utf-8");
        }

        [HttpGet("json_params_url")]
        public IActionResult GetJsonParams()
        {
            // O Controller apenas pede os parâmetros ao Facade
            var parameters = _configFacade.GetConfigurableParameters();
            return Ok(parameters);
        }
    }
}