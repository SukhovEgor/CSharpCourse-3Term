while (true)
{
    Console.Write("Введите x1:");
    double x1 = double.Parse(Console.ReadLine()); //Ввод пользователем x1

    Console.Write("Введите x2:");
    double x2 = double.Parse(Console.ReadLine()); //Ввод пользователем x2

    Console.Write("Введите x3:");
    double x3 = double.Parse(Console.ReadLine()); //Ввод пользователем x3

    Console.Write("Введите y1:");
    double y1 = double.Parse(Console.ReadLine()); //Ввод пользователем y1

    Console.Write("Введите y2:");
    double y2 = double.Parse(Console.ReadLine()); //Ввод пользователем y2

    Console.Write("Введите y3:");
    double y3 = double.Parse(Console.ReadLine()); //Ввод пользователем y3

    double S, S1, S2, S3;
    const double half = 0.5;

    S = half * Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)); // Нахождение площади заданного треугольника по координатам
    if (S == 0) Console.WriteLine("Это не треугольник, а линия");
    else
    {
        /* Решение: Находится площадь трех треугольников, одна из вершин которых находится в начале координат
           остальные вершины соответствуют заданным, при этом если сумма 3х треугольников будет больше площади
           заданного треугольника, то начало координат лежит не в заданном треугольнике */
        S1 = half * Math.Abs((x2 - 0) * (y3 - 0) - (x3 - 0) * (y2 - 0)); // Площадь первого треугольника
        S2 = half * Math.Abs((0 - x1) * (y3 - y1) - (x3 - x1) * (0 - y1)); // Площадь второго треугольника
        S3 = half * Math.Abs((x2 - x1) * (0 - y1) - (0 - x1) * (y2 - y1)); // Площадь третьего треугольника
        if (S1 + S2 + S3 > S) Console.WriteLine("Начало координат НЕ принадлежит треугольнику"); // Сравнение площадей
        else
        {
            Console.WriteLine("Начало координат принадлежит треугольнику");
        }
    }
}
