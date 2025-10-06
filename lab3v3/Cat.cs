using System;

namespace OOP_ZABCHYK.Lab3v14
{
    public class Cat : Animal
    {
        public Cat(string name, double weightKg)
            : base(name, weightKg, dailyFoodGrams: 70.0, kcalPerGram: 4.0)
        {
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name} каже: Мяу!");
        }

        public override double Eat()
        {
            Console.WriteLine($"[Cat.Eat] Починається годування кішки {Name}...");
            double calories = base.Eat();
            Console.WriteLine($"[Cat.Eat] {Name} отримав(ла) {Math.Round(calories, 1)} ккал.\n");
            return calories;
        }
    }
}