while (true)
{
    Console.Write("Введите первую сторону параллелограмма:");
    double a = Convert.ToDouble(Console.ReadLine()); //Ввод пользователем первой стороны параллелограмма

    Console.Write("Введите вторую сторону параллелограмма:");
    double b = Convert.ToDouble(Console.ReadLine()); //Ввод пользователем второй стороны параллелограмма

    Console.Write("Введите угол между сторонами параллелограмма:");
    double x = Convert.ToDouble(Console.ReadLine()); //Ввод пользователем угла между сторонами параллелограмма

    //int square = Convert.ToInt32(a * b * Math.Sin(x * Math.PI / 180));
    double square = Math.Round(a * b * Math.Sin(x * Math.PI / 180), 2); // Расчет площади параллелограмма по формуле S=a*b*sin(x)
                                                                        // Перевод градусов в радианы x*pi/180

    Console.WriteLine($"Площадь параллелограмма: {square}"); // Вывод площади параллелограмма
}
