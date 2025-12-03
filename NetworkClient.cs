using System;
using System.Net.Http;

namespace lab7v3
{
    
    public class NetworkClient
    {
        private int _attemptCount = 0;
        
        public string GetApiResponse(string endpoint)
        {
            _attemptCount++;
            
          
            if (_attemptCount <= 4)
            {
                throw new HttpRequestException($"Помилка запиту до {endpoint}. Спроба {_attemptCount}");
            }
            
            
            return $"Успішна відповідь від {endpoint} після {_attemptCount} спроб";
        }
        
        public void ResetCounter() => _attemptCount = 0;
    }
}