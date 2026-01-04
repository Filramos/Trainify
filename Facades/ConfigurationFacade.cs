using Trainify.Interfaces;
using System.Collections.Generic;

namespace Trainify.Facades
{
    public class ConfigurationFacade
    {
        private readonly IParameterFactory _parameterFactory;

        public ConfigurationFacade(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
        }

        // Centraliza a definição dos parâmetros configuráveis
        public List<IConfigurableParameter> GetConfigurableParameters()
        {
            return new List<IConfigurableParameter>
            {
                _parameterFactory.CreateParameter("nome_treino", "text/plain"),
                _parameterFactory.CreateParameter("foco_principal", "text/plain"),
                _parameterFactory.CreateParameter("instrucoes_gerais", "text/plain"),
                _parameterFactory.CreateParameter("tempo_estimado_minutos", "integer"),
                _parameterFactory.CreateParameter("plano_exercicios_json", "text/plain")
            };
        }

        // Centraliza a geração do HTML (UI)
        public string GetConfigurationPageHtml()
        {
            return "<!DOCTYPE html>" +
                   "<html>" +
                   "<head><meta charset='UTF-8'><title>Train!fy: Configuração de Treino</title>" +
                   "<style>body { font-family: sans-serif; padding: 20px; } div { margin-bottom: 15px; } " +
                   "label { display: block; font-weight: bold; margin-bottom: 5px; } " +
                   "input, select, textarea { width: 100%; max-width: 400px; padding: 8px; }</style></head>" +
                   "<body>" +
                   "<h1>Configuração de Atividade: Train!fy</h1>" +
                   "<form>" +
                   "<div><label>Nome do Treino:</label><input type='text' name='nome_treino' placeholder='Ex: Treino A - Peito/Tríceps'/></div>" +
                   "<div><label>Foco Principal:</label><select name='foco_principal'>" +
                   "<option value='hipertrofia'>Hipertrofia</option><option value='forca_maxima'>Força Máxima</option>" +
                   "<option value='resistencia'>Resistência</option><option value='mobilidade'>Mobilidade</option></select></div>" +
                   "<div><label>Tempo Estimado (minutos):</label><input type='number' name='tempo_estimado_minutos' min='1'/></div>" +
                   "<div><label>Instruções Gerais:</label><textarea name='instrucoes_gerais' style='height: 80px;'></textarea></div>" +
                   "<div><label>Plano de Exercícios (JSON):</label><textarea name='plano_exercicios_json' style='height: 120px;'></textarea></div>" +
                   "</form></body></html>";
        }
    }
}