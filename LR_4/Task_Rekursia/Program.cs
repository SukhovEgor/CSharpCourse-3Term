namespace Task_Rekursia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] arr = new int[n];
            CreateArr(arr);
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
    }
}