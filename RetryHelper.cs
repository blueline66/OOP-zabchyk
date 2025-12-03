using System;
using System.Collections.Generic;
using System.Threading;

namespace lab7v3
{
   
    public static class RetryHelper
    {
        public static T ExecuteWithRetry<T>(
            Func<T> operation, 
            int retryCount = 3, 
            TimeSpan initialDelay = default, 
            Func<Exception, bool> shouldRetry = null)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));
                
            if (retryCount < 1)
                throw new ArgumentException("Кількість спроб має бути більше 0", nameof(retryCount));
            
            
            if (initialDelay == default)
                initialDelay = TimeSpan.FromSeconds(1);
            
            var exceptions = new List<Exception>();
            
            for (int attempt = 1; attempt <= retryCount; attempt++)
            {
                try
                {
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Спроба {attempt} з {retryCount}...");
                    return operation();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Помилка при спробі {attempt}: {ex.Message}");
                    exceptions.Add(ex);
                    
                    
                    if (shouldRetry != null && !shouldRetry(ex))
                    {
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Помилка не підтримує повторні спроби. Тип: {ex.GetType().Name}");
                        throw;
                    }
                    
                    
                    if (attempt == retryCount)
                    {
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Досягнуто максимальну кількість спроб ({retryCount})");
                        throw new AggregateException($"Операція невдала після {retryCount} спроб", exceptions);
                    }
                    
                    
                    TimeSpan delay = TimeSpan.FromMilliseconds(
                        initialDelay.TotalMilliseconds * Math.Pow(2, attempt - 1)
                    );
                    
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Затримка перед наступною спробою: {delay.TotalSeconds:F2} секунд");
                    Thread.Sleep(delay);
                }
            }
            
           
            throw new InvalidOperationException("Неможливо досягти цього коду");
        }
    }
}