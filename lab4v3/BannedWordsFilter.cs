using System;
using System.Collections.Generic;

namespace lab4v1
{
    // Клас для заміни заборонених слів
    public class BannedWordsFilter : AbstractFilter
    {
        private List<string> bannedWords;

        // Використання агрегації — список передається через конструктор
        public BannedWordsFilter(List<string> bannedWords)
        {
            this.bannedWords = bannedWords;
        }

        public override string Apply(string input)
        {
            string result = input;
            foreach (string word in bannedWords)
            {
                result = result.Replace(word, new string('*', word.Length), StringComparison.OrdinalIgnoreCase);
            }
            return result;
        }
    }
}
