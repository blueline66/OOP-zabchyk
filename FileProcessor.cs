using System;
using System.Collections.Generic;
using System.IO;

namespace lab7v3
{
    
    public class FileProcessor
    {
        private int _attemptCount = 0;
        
        public List<string> GetLines(string path)
        {
            _attemptCount++;
            
            
            if (_attemptCount <= 2)
            {
                throw new IOException($"Файл {path} недоступний. Спроба {_attemptCount}");
            }
            
        
            return new List<string> 
            { 
                "Перший рядок",
                "Другий рядок",
                "Третій рядок"
            };
        }
        
        public void ResetCounter() => _attemptCount = 0;
    }
}