while (true)
{
    double b, c; //Вводим переменные b и c

    Console.Write("Введите число:"); 
    double a = Convert.ToDouble(Console.ReadLine()); //Ввод пользователем числа

    b = a * a * a * a; //степень 4
    c = a * a; //степень 2
    b = b * c; //степень 6
    c = c * c; // степень 4
    b = b * c; //степень 10
    a = b * b * c * a; //степень 25

    Console.WriteLine($"Число в степени 25 равно: {a}"); //Вывод числа в степени 25
}