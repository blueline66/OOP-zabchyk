using System;

namespace lab4v1
{
    // Абстрактний клас, що реалізує базову логіку для фільтрів
    public abstract class AbstractFilter : ITextFilter
    {
        public abstract string Apply(string input);

        // Метод для підрахунку змін
        public int CountChanges(string original, string filtered)
        {
            return Math.Abs(original.Length - filtered.Length);
        }
    }
}
