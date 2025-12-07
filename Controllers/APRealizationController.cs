using Microsoft.AspNetCore.Mvc;
using Trainify.Models;

[ApiController]
[Route("api/ap-realization")]
public class APRealizationController : ControllerBase
{
    /// <summary>
    /// Realiza o deploy inicial da atividade.
    /// </summary>
    [HttpGet("user_url")]
    public IActionResult DeployActivity(int activityID)
    {
        string activityUrl = $"https://trainify.onrender.com?activity={activityID}";
        return Ok(new { url = activityUrl });
    }

    /// <summary>
    /// Regista o acesso do CLIENTE à atividade.
    /// </summary>
    [HttpPost("provide_client_activity_url")]
    public IActionResult ClientAccess([FromBody] ClientAccessRequest requestData)
    {
        return Ok("Exercício número " + requestData.ActivityID + " vai ser realizado pelo cliente com ID " +
            requestData.InveniraClientID + " no URL: " +
            $"https://trainify.onrender.com?activity={requestData.ActivityID}&clientID={requestData.InveniraClientID}");
    }
}