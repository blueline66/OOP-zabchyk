using System;

namespace Lab2
{
    using System;

public class Vector3D
{
    private double x;
    private double y;
    private double z;

    public double X
    {
        get => x;
        set
        {
            if (IsValidLength(value, y, z))
                x = value;
            else
                throw new ArgumentException("Довжина вектора не може перевищувати 100!");
        }
    }

    public double Y
    {
        get => y;
        set
        {
            if (IsValidLength(x, value, z))
                y = value;
            else
                throw new ArgumentException("Довжина вектора не може перевищувати 100!");
        }
    }

    public double Z
    {
        get => z;
        set
        {
            if (IsValidLength(x, y, value))
                z = value;
            else
                throw new ArgumentException("Довжина вектора не може перевищувати 100!");
        }
    }

    // Конструктор
    public Vector3D(double x, double y, double z)
    {
        if (!IsValidLength(x, y, z))
            throw new ArgumentException("Довжина вектора не може перевищувати 100!");
        
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Довжина вектора
    public double Length => Math.Sqrt(x * x + y * y + z * z);

    private static bool IsValidLength(double x, double y, double z)
    {
        double length = Math.Sqrt(x * x + y * y + z * z);
        return length <= 100;
    }

    // Оператори
    public static Vector3D operator +(Vector3D a, Vector3D b)
        => new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z);

    public static Vector3D operator -(Vector3D a, Vector3D b)
        => new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z);

    public static bool operator ==(Vector3D a, Vector3D b)
        => a.x == b.x && a.y == b.y && a.z == b.z;

    public static bool operator !=(Vector3D a, Vector3D b)
        => !(a == b);

    // Перевизначення Equals та GetHashCode
    public override bool Equals(object? obj)
    {
        if (obj is Vector3D other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
        => (x, y, z).GetHashCode();

    // Для зручного виводу
    public override string ToString()
        => $"({x}, {y}, {z}), |V| = {Length:F2}";
}

// Приклад використання
class Program
{
    static void Main()
    {
        Vector3D v1 = new Vector3D(3, 4, 5);
        Vector3D v2 = new Vector3D(1, 2, 3);

        Console.WriteLine("Вектор 1: " + v1);
        Console.WriteLine("Вектор 2: " + v2);

        Console.WriteLine("Сума: " + (v1 + v2));
        Console.WriteLine("Різниця: " + (v1 - v2));
        Console.WriteLine("Чи рівні? " + (v1 == v2));
        Console.WriteLine("Чи різні? " + (v1 != v2));
    }
}

}
