// Дано 10 вещественных чисел: a1,a2,...,a10.Требуется найти порядковый
// номер того из них, которое наиболее близко к какому-нибудь целому числу

/*int j = 0;

// Массив
double[] nums = new double[10];
for (int m = 0; m < 10; m++)
{
    Console.Write($"Введите a{m}:");
    nums[m] = double.Parse(Console.ReadLine());
}

// Цикл перебора
for (int i = 0; i < nums.Length; i++)
{
    // Нахождение "расстояния" до целого числа
    double search = Math.Abs(nums[0] - Math.Round(nums[0]));

    // Если это целое число, то оно сразу же выводится
    if (search == 0)
    {
        j = i;
    }

    // цикл перебора сравнения
    for (i = 1; i < nums.Length; i++)
    {
        // сравнение с начальным числом цикла
        if (Math.Abs(nums[i] - Math.Round(nums[0])) < search)
        {
            // обновление "расстояния"
            search = Math.Abs(nums[i] - Math.Round(nums[0]));
            j = i;
        }

    }

}

Console.WriteLine($"Индекс числа, наиболее близкого к целому числу: {j}");*/

double[] nums = new double[10];
double[] distance = new double[10];

for (int m = 0; m < 10; m++)
{
    Console.Write($"Введите a{m + 1}:");
    nums[m] = double.Parse(Console.ReadLine());
}

// Цикл перебора
for (int i = 0; i < nums.Length; i++)
{
    // Нахождение "расстояния" до целого числа
    distance[i] = Math.Abs(nums[i] - Math.Round(nums[i]));
}

int j = 0;
double min = distance[0];
for (int i = 0; i < distance.Length; i++)
{
    if (distance[i] < min)
    {
        min = distance[i];
        j = i;
    }
}

Console.WriteLine($"Индекс числа, наиболее близкого к целому числу: {j}");
