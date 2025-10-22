using System;

namespace lab4v1
{
    // Інтерфейс для фільтрів тексту
    public interface ITextFilter
    {
        string Apply(string input); // Метод для обробки тексту
    }
}
