using System;
using System.Collections.Generic;

namespace lab4v1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string text = "Це приклад рядка із забороненими словами та зайвими пробілами.";

            // Композиція: об’єкт TextProcessor містить інші об’єкти фільтрів
            TextProcessor processor = new TextProcessor();
            processor.AddFilter(new SpaceRemoverFilter());
            processor.AddFilter(new BannedWordsFilter(new List<string> { "забороненими" }));

            Console.WriteLine("Оригінальний текст:");
            Console.WriteLine(text);

            string result = processor.Process(text);

            Console.WriteLine("\nПісля обробки:");
            Console.WriteLine(result);

            Console.WriteLine($"\nКількість змін: {processor.TotalChanges}");
        }
    }

    // Клас-композитор, який зберігає набір фільтрів
    public class TextProcessor
    {
        private List<AbstractFilter> filters = new List<AbstractFilter>();
        public int TotalChanges { get; private set; } = 0;

        public void AddFilter(AbstractFilter filter)
        {
            filters.Add(filter);
        }

        public string Process(string input)
        {
            string current = input;
            foreach (var filter in filters)
            {
                string newText = filter.Apply(current);
                TotalChanges += filter.CountChanges(current, newText);
                current = newText;
            }
            return current;
        }
    }
}
