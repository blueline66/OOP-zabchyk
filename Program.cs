using System;
using System.IO;
using System.Net.Http;

namespace lab7v3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторна робота №7: Патерн Retry ===");
            Console.WriteLine("Студент: [Ваше Прізвище]\n");
            
            var fileProcessor = new FileProcessor();
            var networkClient = new NetworkClient();
            
            
            Console.WriteLine("\n--- Демонстрація 1: FileProcessor ---");
            Console.WriteLine("Очікується: IOException перші 2 рази, потім успіх\n");
            
            try
            {
                var lines = RetryHelper.ExecuteWithRetry(
                    operation: () => fileProcessor.GetLines("test.txt"),
                    retryCount: 3,
                    initialDelay: TimeSpan.FromSeconds(1),
                    shouldRetry: ex => ex is IOException || ex is FileNotFoundException
                );
                
                Console.WriteLine($"\n✅ Успішно отримано {lines.Count} рядків з файлу:");
                foreach (var line in lines)
                {
                    Console.WriteLine($"  - {line}");
                }
            }
            catch (AggregateException agEx)
            {
                Console.WriteLine($"\n❌ Усі спроби невдалі:");
                foreach (var ex in agEx.InnerExceptions)
                {
                    Console.WriteLine($"  - {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Помилка: {ex.Message}");
            }
            
          
            Console.WriteLine("\n\n--- Демонстрація 2: NetworkClient ---");
            Console.WriteLine("Очікується: HttpRequestException перші 4 рази, потім успіх\n");
            
           
            networkClient.ResetCounter();
            
            try
            {
                var response = RetryHelper.ExecuteWithRetry(
                    operation: () => networkClient.GetApiResponse("https://api.example.com/data"),
                    retryCount: 5,  
                    initialDelay: TimeSpan.FromMilliseconds(800)
                  
                );
                
                Console.WriteLine($"\n✅ {response}");
            }
            catch (AggregateException agEx)
            {
                Console.WriteLine($"\n❌ Усі спроби невдалі:");
                foreach (var ex in agEx.InnerExceptions)
                {
                    Console.WriteLine($"  - {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Помилка: {ex.Message}");
            }
            
          
            Console.WriteLine("\n\n--- Демонстрація 3: Вибіркова обробка винятків ---");
            Console.WriteLine("Повторюємо тільки для IOException, але не для InvalidOperationException\n");
            
            
            var fileProcessor2 = new FileProcessor();
            
            try
            {
                var result = RetryHelper.ExecuteWithRetry(
                    operation: () => 
                    {
                        
                        var random = new Random();
                        var errorType = random.Next(0, 3);
                        
                        if (errorType == 0)
                        {
                            throw new IOException("Тимчасова помилка вводу/виводу");
                        }
                        else if (errorType == 1)
                        {
                            throw new InvalidOperationException("Критична помилка операції");
                        }
                        else
                        {
                            return fileProcessor2.GetLines("demo.txt");
                        }
                    },
                    retryCount: 4,
                    initialDelay: TimeSpan.FromSeconds(0.5),
                    shouldRetry: ex => 
                    {
                        if (ex is IOException)
                        {
                            Console.WriteLine($"  -> Повторюємо спробу для IOException");
                            return true;
                        }
                        
                        Console.WriteLine($"  -> НЕ повторюємо для {ex.GetType().Name}");
                        return false;
                    }
                );
                
                Console.WriteLine($"\n✅ Операція успішна!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Фінальна помилка: {ex.GetType().Name} - {ex.Message}");
            }
            
            
            Console.WriteLine("\n\n--- Демонстрація 4: Сценарій з усіма невдалими спробами ---");
            Console.WriteLine("Очікується: IOException для всіх спроб\n");
            
            
            try
            {
                var result = RetryHelper.ExecuteWithRetry(
                    operation: () => 
                    {
                        throw new IOException("Постійна помилка доступу до файлу");
                    },
                    retryCount: 3,
                    initialDelay: TimeSpan.FromSeconds(0.3)
                );
            }
            catch (AggregateException agEx)
            {
                Console.WriteLine($"\n❌ Усі 3 спроби невдалі. Загальна кількість помилок: {agEx.InnerExceptions.Count}");
            }
            
            Console.WriteLine("\n=== Демонстрація завершена ===");
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}