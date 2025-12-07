using Microsoft.AspNetCore.Mvc;
using Trainify.Interfaces;
using System.Collections.Generic;

namespace Trainify.Controllers
{
    [ApiController]
    [Route("api/ap-configuration")]
    public class APConfigurationController : ControllerBase
    {
        private readonly IParameterFactory _parameterFactory;

        // Injeção de Dependência (Melhor prática que 'new Factory()')
        public APConfigurationController(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
        }

        /// <summary>
        /// Retorna a página de configuração da atividade (HTML).
        /// Campos baseados no Anexo I da Proposta AP.pdf .
        /// </summary>
        [HttpGet("config_url")]
        public ActionResult GetConfigurationPage()
        {
            string htmlContent = "<!DOCTYPE html>" +
                                 "<html>" +
                                 "<head>" +
                                 "<meta charset='UTF-8'>" +
                                 "<title>Train!fy: Configuração de Treino</title>" +
                                 "<style>" +
                                 "body { font-family: sans-serif; padding: 20px; }" +
                                 "div { margin-bottom: 15px; }" +
                                 "label { display: block; font-weight: bold; margin-bottom: 5px; }" +
                                 "input, select, textarea { width: 100%; max-width: 400px; padding: 8px; }" +
                                 "</style>" +
                                 "</head>" +
                                 "<body>" +
                                 "<h1>Configuração de Atividade: Train!fy</h1>" +
                                 "<form>" +

                                 // 1. Nome do Treino
                                 "<div>" +
                                 "<label>Nome do Treino:</label>" +
                                 "<input type='text' name='nome_treino' placeholder='Ex: Treino A - Peito/Tríceps'/>" +
                                 "</div>" +

                                 // 2. Foco Principal 
                                 "<div>" +
                                 "<label>Foco Principal:</label>" +
                                 "<select name='foco_principal'>" +
                                 "<option value='hipertrofia'>Hipertrofia</option>" +
                                 "<option value='forca_maxima'>Força Máxima</option>" +
                                 "<option value='resistencia'>Resistência</option>" +
                                 "<option value='mobilidade'>Mobilidade</option>" +
                                 "</select>" +
                                 "</div>" +

                                 // 3. Tempo Estimado
                                 "<div>" +
                                 "<label>Tempo Estimado (minutos):</label>" +
                                 "<input type='number' name='tempo_estimado_minutos' min='1'/>" +
                                 "</div>" +

                                 // 4. Instruções Gerais
                                 "<div>" +
                                 "<label>Instruções Gerais:</label>" +
                                 "<textarea name='instrucoes_gerais' style='height: 80px;' placeholder='Ex: Aquecer 10 min antes...'></textarea>" +
                                 "</div>" +

                                 // 5. Plano de Exercícios JSON
                                 "<div>" +
                                 "<label>Plano de Exercícios (JSON):</label>" +
                                 "<textarea name='plano_exercicios_json' style='height: 120px;' placeholder='Cole aqui a estrutura JSON dos exercícios'></textarea>" +
                                 "</div>" +

                                 "</form>" +
                                 "</body>" +
                                 "</html>";
            return Content(htmlContent, "text/html; charset=utf-8");
        }

        /// <summary>
        /// Retorna os parâmetros configuráveis no formato JSON.
        /// </summary>
        [HttpGet("json_params_url")]
        public IActionResult GetJsonParams()
        {
            var parameters = new List<IConfigurableParameter>
            {
                _parameterFactory.CreateParameter("nome_treino", "text/plain"),
                _parameterFactory.CreateParameter("foco_principal", "text/plain"),
                _parameterFactory.CreateParameter("instrucoes_gerais", "text/plain"),
                _parameterFactory.CreateParameter("tempo_estimado_minutos", "integer"),
                _parameterFactory.CreateParameter("plano_exercicios_json", "text/plain")
            };

            return Ok(parameters);
        }
    }
}