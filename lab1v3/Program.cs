// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
class Student
{
    private string name;
    private int id;

    public double AverageMark { get; set; }

    public Student(string name, int id, double averageMark)
    {
        this.name = name;
        this.id = id;
        this.AverageMark = averageMark;
    }

    ~Student()
    {
        Console.WriteLine($"Об'єкт студента {name} з id {id} знищено.");
    }

    public void PrintCard()
    {
        Console.WriteLine($"Студент: {name}, ID: {id}, Середній бал: {AverageMark}");
    }
}
partial class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Іван", 101, 85.5);
        Student s2 = new Student("Олена", 102, 92.3);
        Student s3 = new Student("Петро", 103, 77.8);

        s1.PrintCard();
        s2.PrintCard();
        s3.PrintCard();
    }
}
