using Trainify.Interfaces;
using Trainify.Models;
using System.Collections.Generic;

namespace Trainify.Facades
{
    // O Facade agora implementa IActivitySubject para permitir observadores
    public class RealizationFacade : IActivitySubject
    {
        // URL base para o ambiente de treino
        private const string BaseUrl = "https://trainify-app.onrender.com";

        // Lista privada para gerir os observadores subscritos
        private readonly List<IActivityObserver> _observers = new();

        #region Implementação do Padrão Observer

        public void Attach(IActivityObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IActivityObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(ClientAccessRequest request)
        {
            // Notifica cada observador registado sobre o novo acesso
            foreach (var observer in _observers)
            {
                observer.Update(request);
            }
        }

        #endregion

        public string GenerateActivityUrl(int activityID)
        {
            return $"{BaseUrl}?activity={activityID}";
        }

        public string RegisterClientAccess(int activityID, int clientID)
        {
            // 1. Executa a lógica de negócio principal (gerar o URL)
            string accessUrl = $"{BaseUrl}?activity={activityID}&clientID={clientID}";

            // 2. Prepara o objeto de estado para os observadores
            var request = new ClientAccessRequest
            {
                ActivityID = activityID,
                InveniraClientID = clientID
            };

            // 3. Notifica os observadores de forma centralizada
            // Isto garante o desacoplamento entre o acesso e o logging/analytics
            NotifyObservers(request);

            return accessUrl;
        }
    }
}