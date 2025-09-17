using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vector3D v1 = new Vector3D(3, 4, 5);
                Vector3D v2 = new Vector3D(1, 2, 3);

                Console.WriteLine("Вектор v1: " + v1);
                Console.WriteLine("Вектор v2: " + v2);

                Vector3D sum = v1 + v2;
                Vector3D diff = v1 - v2;

                Console.WriteLine("v1 + v2 = " + sum);
                Console.WriteLine("v1 - v2 = " + diff);

                Console.WriteLine("v1 == v2 ? " + (v1 == v2));
                Console.WriteLine("v1 != v2 ? " + (v1 != v2));

                Console.WriteLine("v1[0] = " + v1[0]);
                Console.WriteLine("v1[1] = " + v1[1]);
                Console.WriteLine("v1[2] = " + v1[2]);

                v1[0] = 10;
                Console.WriteLine("v1 після зміни X через індексатор: " + v1);

                Vector3D bigVector = new Vector3D(100, 100, 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
