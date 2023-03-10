/*Результаты соревнований по прыжкам в длину представлены
в виде матрицы 5х3 (5 спортсменов по 3 попытки у каждого).
Указать, какой спортсмен и в какой попытке показал наилучший результат.*/

// объявляем и определяем переменные
int recSportsmen;
int nRows = 5;
int nColumns = 3;
int[,] arr = new int[nRows, nColumns];
Random rand = new Random();

// заполянем массив (матрицу)
for (int i = 0; i < nRows; i++)
{
    for (int j = 0; j < nColumns; j++)
    {
        arr[i, j] = rand.Next(170, 250);
    }
}

// выводим исходный массив (матрицу)
Console.WriteLine("Исходная матрица:");
for (int i = 0; i < nRows; i++)
{
    int numSportsmen = i + 1;
    for (int j = 0; j < nColumns; j++)
    {
        Console.Write($"{arr[i, j]}\t");
    }

    Console.WriteLine($"- {numSportsmen} спортcмен");
}

// цикл перебора, если значение попытки больше предыдущего,
// то записывается записывается значение и номер спортсмена
for (int j = 0; j < 3; j++)
{
    recSportsmen = 0;
    int numSportsmen2 = 0;
    int i = 0;
    while (i < 5)
    {
        if (arr[i, j] > recSportsmen)
        {
            recSportsmen = arr[i, j];
            numSportsmen2 = i + 1;
        }

        i++;
    }

    Console.WriteLine($"{j + 1} попытка, результат - {recSportsmen}," +
        $" Номер спортсмена - {numSportsmen2})");
}
