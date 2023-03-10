/* В приведенных ниже заданиях рассмотреть указанную последовательность
 в цикле и выйти из цикла, достигнув указанного условия с выдачей
 порядкового номера члена, при котором достигнуто условие. Если же
 за m оборотов цикла условие не достигнуто, напечатать об этом сообщение.*/

double aN = 1;
uint m;
double n = 0;
double factorial = 1;

// осуществляем проверку на корректность введённых
// значений по условию uint (положительное число)
Console.WriteLine("Введите значение m:");
while (!uint.TryParse(Console.ReadLine(), out m))
{
    Console.WriteLine("Введите целое положительное число");
}

// осуществляем расчет числа циклов по условию
while (Math.Abs(aN) >= 0.1)
{
    n += 1;
    factorial *= n;
    aN = 1 / (Math.Pow(factorial, 1 / n));
}

// сравниваем желаемое и фактическое значение числа циклов
if (n > m)
{
    Console.WriteLine($"Условие не достигнуто за {m} циклов");
}
else
{
    Console.WriteLine($"Условие достигнуто за n = {n} циклов");
}

Console.ReadKey();
