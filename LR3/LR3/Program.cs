// Дан массив из N элементов (натуральные числа). Определить количество элементов, кратных 3.
// объявляем переменную n, равную длине массива
uint n;
int m = 0;

// осуществляем проверку на корректность введенных значений по условию uint (положительное число)
Console.WriteLine("Введите длину массива:");
while (!uint.TryParse(Console.ReadLine(), out n))
{
    Console.WriteLine("Введите натуральное число");
}

// создаем массив arr длины n
double[] arr = new double[n];

// создаем объект rand класса Random
Random rand = new Random();

// заполяем массив arr
for (int i = 0; i < arr.Length; i++)
{
    // заполяем массив случайным числом из диапазона от 0 до 100
    arr[i] = rand.Next(0, 100);

    if (arr[i] % 3 == 0)
    {
        m++;
    }

    Console.Write($"{arr[i]} ");
}

Console.WriteLine();

// выводим количество чисел, кратных 3
Console.WriteLine($"Количество чисел кратных 3: {m}");
