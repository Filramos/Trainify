namespace Trainify.Facades
{
    public class RealizationFacade
    {
        // URL base para o ambiente de treino (ajusta para o teu domínio real se necessário)
        private const string BaseUrl = "https://trainify-app.onrender.com";

        public string GenerateActivityUrl(int activityID)
        {
            return $"{BaseUrl}?activity={activityID}";
        }

        public string RegisterClientAccess(int activityID, int clientID)
        {
            return $"{BaseUrl}?activity={activityID}&clientID={clientID}";
        }
    }
}