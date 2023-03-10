namespace Task_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            CreateArr(arr);

            Console.WriteLine("Исходный массив:");
            PrintArr(arr);

            Console.WriteLine("Отсортированный массив:");
            SortArr(arr);
            PrintArr(arr);
        }
        /// <summary>
        /// Заполнение одномерного массива рандомными целыми числами
        /// </summary>
        /// <param name="arr">Одномерный массив</param>
        static void CreateArr(int[] arr) 
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-9, 9);
            }

        }
        /// <summary>
        /// Вывод исходного массива
        /// </summary>
        /// <param name="arr">Одномерный массив</param>
        static void PrintArr(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n");
        }
        /// <summary>
        /// Сортировка массива методом простых вставок
        /// </summary>
        /// <param name="arr">Одномерный массив</param>
        static void SortArr(int[] arr)
        {
            
            int index;
            int currentNumber;

            // Сортировка всего массива по возрастанию
            for(int i = 1; i < arr.Length; i++)
            {
                
                // Индекс и число, место для которого ищется
                index = i;
                currentNumber = arr[i];

                // Сравнение с предыдущим числом
                while(index > 0 && currentNumber < arr[index - 1])
                {
                    // Элемент сдвигается на один индекс
                    arr[index] = arr[index - 1];
                    index--;
                }

                // Перемещение самого маленького из больших чисел
                arr[index] = currentNumber;
            }
            
            // Сортировка первой половины массива по убыванию
            for (int i = arr.Length/2; i < arr.Length; i++)
            {
                index = i;
                currentNumber = arr[i];
                while (index > 0 && currentNumber > arr[index - 1])
                {
                    arr[index] = arr[index - 1];
                    index--;
                }

                arr[index] = currentNumber;
            }

        }

    }

}