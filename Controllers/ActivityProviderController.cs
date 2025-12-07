using Microsoft.AspNetCore.Mvc;
using Trainify.Interfaces; // Importar as interfaces
using Trainify.Implementations; // Importar as implementações
using Trainify.Models;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class ActivityProviderController : ControllerBase
{
    // Dependência da factory (instanciada diretamente aqui, mas poderia ser injetada via DI)
    private readonly IParameterFactory _parameterFactory;

    public ActivityProviderController()
    {
        // Inicializar a factory para criação de parâmetros
        _parameterFactory = new ConfigurableParameterFactory();
    }

    /// <summary>
    /// Retorna a página de configuração da atividade (HTML).
    /// </summary>
    [HttpGet("config_url")]
    public ActionResult GetConfigurationPage()
    {
        // Método original para retornar a página HTML de configuração
        string htmlContent = "<!DOCTYPE html>" +
                             "<html>" +
                             "<head>" +
                             "<meta charset='UTF-8'>" +
                             "<title>Train!fy: Configuração de Treino</title>" +
                             "</head>" +
                             "<body>" +
                             "<h1>Configurar Atividade Train!fy</h1>" +
                             "<form>" +

                             // 1. Nome do Treino
                             "<div style='margin-bottom: 15px;'>" +
                             "<label style='display:block;'>Nome do Treino:</label>" +
                             "<input type='text' name='nome_treino' style='width: 300px;' placeholder='Ex: Treino A - Peito/Tríceps'/>" +
                             "</div>" +

                             // 2. Foco Principal 
                             "<div style='margin-bottom: 15px;'>" +
                             "<label style='display:block;'>Foco Principal:</label>" +
                             "<select name='foco_principal' style='width: 300px;'>" +
                             "<option value='hipertrofia'>Hipertrofia</option>" +
                             "<option value='forca_maxima'>Força Máxima</option>" +
                             "<option value='resistencia'>Resistência</option>" +
                             "<option value='mobilidade'>Mobilidade</option>" +
                             "</select>" +
                             "</div>" +

                             // 3. Tempo Estimado
                             "<div style='margin-bottom: 15px;'>" +
                             "<label style='display:block;'>Tempo Estimado (minutos):</label>" +
                             "<input type='number' name='tempo_estimado_minutos' style='width: 100px;'/>" +
                             "</div>" +

                             // 4. Instruções Gerais
                             "<div style='margin-bottom: 15px;'>" +
                             "<label style='display:block;'>Instruções Gerais:</label>" +
                             "<textarea name='instrucoes_gerais' style='width: 300px; height: 60px;' placeholder='Ex: 10 min de aquecimento...'></textarea>" +
                             "</div>" +

                             // 5. Plano de Exercícios (JSON)
                             "<div style='margin-bottom: 15px;'>" +
                             "<label style='display:block;'>Plano de Exercícios (JSON):</label>" +
                             "<textarea name='plano_exercicios_json' style='width: 300px; height: 100px;' placeholder='Cole o JSON dos exercícios aqui'></textarea>" +
                             "</div>" +

                             "</form>" +
                             "</body>" +
                             "</html>";
        return Content(htmlContent, "text/html; charset=utf-8");
    }

    /// <summary>
    /// Retorna os parâmetros configuráveis no formato JSON, usando Factory Method.
    /// </summary>
    [HttpGet("json_params_url")]
    public IActionResult GetJsonParams()
    {
        // Criar os parâmetros configuráveis com a factory (Anexo I da Proposta)
        var parameters = new List<IConfigurableParameter>
        {
            _parameterFactory.CreateParameter("nome_treino", "text/plain"),
            _parameterFactory.CreateParameter("foco_principal", "text/plain"),
            _parameterFactory.CreateParameter("instrucoes_gerais", "text/plain"),
            _parameterFactory.CreateParameter("tempo_estimado_minutos", "integer"),
            _parameterFactory.CreateParameter("plano_exercicios_json", "text/plain")
        };

        // Retornar os parâmetros no formato JSON
        return Ok(parameters);
    }

    /// <summary>
    /// Realiza o deploy inicial da atividade.
    /// </summary>
    [HttpGet("user_url")]
    public IActionResult DeployActivity(int activityID)
    {
        string activityUrl = $"https://trainify-jksy.onrender.com?activity={activityID}";
        return Ok(new { url = activityUrl });
    }

    /// <summary>
    /// Retorna os dados analíticos da atividade.
    /// </summary>
    [HttpPost("analytics_url")]
    public IActionResult GetActivityAnalytics([FromBody] int activityID)
    {
        // Obter dados simulados da classe ClientAnalyticsData
        var allAnalytics = ClientAnalyticsData.GetAllAnalytics();

        // Filtrar os dados com base no ID da atividade
        var activityAnalytics = allAnalytics.Find(analytics => analytics.ActivityID == activityID);

        // Se não for encontrado, retornar erro 404
        if (activityAnalytics == null)
        {
            return NotFound(new { message = "Nenhum dado encontrado para o ID da Atividade fornecido." });
        }

        // Retornar os dados analíticos
        return Ok(activityAnalytics);
    }

    /// <summary>
    /// Retorna a lista de analytics disponíveis, usando Factory Method.
    /// </summary>
    [HttpGet("analytics_list_url")]
    public IActionResult GetAnalyticsList()
    {
        // Analytics definidos no Anexo II da Proposta
        var analytics = new
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

        return Ok(analytics);
    }

    /// <summary>
    /// Regista o acesso do Cliente à atividade.
    /// </summary>
    [HttpPost("provide_client_activity_url")]
    public IActionResult ClientAccess([FromBody] ClientAccessRequest requestData)
    {
        return Ok("Treino número " + requestData.ActivityID + " vai ser realizado pelo cliente com ID " +
            requestData.InveniraClientID + " no URL: " +
            $"https://trainify-jksy.onrender.com?activity={requestData.ActivityID}&clientID={requestData.InveniraClientID}");
    }
}