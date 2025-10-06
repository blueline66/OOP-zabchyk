using System;

namespace OOP_ZABCHYK.Lab3v14
{
    public class Dog : Animal
    {
        public Dog(string name, double weightKg)
            : base(name, weightKg, dailyFoodGrams: 400.0, kcalPerGram: 3.5)
        {
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name} каже: Гав-гав!");
        }

        public override double Eat()
        {
            Console.WriteLine($"[Dog.Eat] Починається годування собаки {Name}...");
            double calories = base.Eat();
            Console.WriteLine($"[Dog.Eat] {Name} отримав(ла) {Math.Round(calories, 1)} ккал.\n");
            return calories;
        }
    }
}