using System;
using System.Collections.Generic;

namespace AnimalsApp
{
    // Базовий клас
    abstract class Animal
    {
        public string Name { get; set; }
        public int CaloriesPerMeal { get; set; } // калорії за один прийом їжі
        public int MealsPerDay { get; set; }     // кількість прийомів їжі на день

        public Animal(string name, int caloriesPerMeal, int mealsPerDay)
        {
            Name = name;
            CaloriesPerMeal = caloriesPerMeal;
            MealsPerDay = mealsPerDay;
        }

        public abstract void Speak();

        public void Eat()
        {
            Console.WriteLine($"{Name} їсть {CaloriesPerMeal} калорій за один прийом.");
        }

        public int DailyCalories()
        {
            return CaloriesPerMeal * MealsPerDay;
        }
    }

    // Похідний клас Dog
    class Dog : Animal
    {
        public Dog(string name, int caloriesPerMeal, int mealsPerDay)
            : base(name, caloriesPerMeal, mealsPerDay) { }

        public override void Speak()
        {
            Console.WriteLine($"{Name} гавкає: Гав-гав!");
        }
    }

    // Похідний клас Cat
    class Cat : Animal
    {
        public Cat(string name, int caloriesPerMeal, int mealsPerDay)
            : base(name, caloriesPerMeal, mealsPerDay) { }

        public override void Speak()
        {
            Console.WriteLine($"{Name} нявкає: Мяу!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення тварин
            Dog dog = new Dog("Рекс", 300, 2);
            Cat cat = new Cat("Мурка", 150, 3);

            // Демонстрація роботи методів
            dog.Speak();
            dog.Eat();
            Console.WriteLine($"{dog.Name} споживає {dog.DailyCalories()} калорій за день.\n");

            cat.Speak();
            cat.Eat();
            Console.WriteLine($"{cat.Name} споживає {cat.DailyCalories()} калорій за день.\n");

            // Порівняння
            if (dog.DailyCalories() > cat.DailyCalories())
            {
                Console.WriteLine($"{dog.Name} споживає більше калорій за день, ніж {cat.Name}.");
            }
            else if (dog.DailyCalories() < cat.DailyCalories())
            {
                Console.WriteLine($"{cat.Name} споживає більше калорій за день, ніж {dog.Name}.");
            }
            else
            {
                Console.WriteLine($"{dog.Name} та {cat.Name} споживають однакову кількість калорій за день.");
            }
        }
    }
}