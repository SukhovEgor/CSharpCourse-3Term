while (true)
{
    double b, c, d; //Вводим переменные b и c

    Console.Write("Введите число:");
    double a = Convert.ToDouble(Console.ReadLine()); //Ввод пользователем числа

    b = a * a * a * a; // степень 4
    c = b * b; //степень 8
    d = c * b; // степень 12
    d = d * d * d; // степень 36
    d = d * c; // степень 44
    a = d * a * a * a; // степень 47

    Console.WriteLine($"Число в степени 8 равно: {c} " +
        $"\nЧисло в степени 47 равно: {a}"); //Вывод числа в степени 8 и 47
}