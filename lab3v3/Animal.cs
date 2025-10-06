using System;

namespace OOP_ZABCHYK.Lab3v14
{
    // Базовий клас Animal
    public abstract class Animal
    {
        public string Name { get; }
        public double WeightKg { get; }

        protected double DailyFoodGrams { get; }
        protected double KcalPerGram { get; }

        protected Animal(string name, double weightKg, double dailyFoodGrams, double kcalPerGram)
        {
            Name = name;
            WeightKg = weightKg;
            DailyFoodGrams = dailyFoodGrams;
            KcalPerGram = kcalPerGram;
        }

        public virtual void Speak()
        {
            Console.WriteLine($"{Name} робить звук (невідомий тип).");
        }

        public virtual double Eat()
        {
            double calories = DailyFoodGrams * KcalPerGram;
            Console.WriteLine($"{Name} з'їдає {DailyFoodGrams} г їжі і отримує {Math.Round(calories, 1)} ккал.");
            return calories;
        }

        public virtual double GetDailyCalories()
        {
            return DailyFoodGrams * KcalPerGram;
        }

        public override string ToString()
        {
            return $"{GetType().Name} \"{Name}\" ({WeightKg} кг)";
        }
    }
}