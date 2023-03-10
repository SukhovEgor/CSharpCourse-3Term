using TaskSort;

namespace TaskRekursia
{
    /// <summary>
    /// Задание с рекурсивным перебором.
    /// </summary>
    internal class Program
    {

        /// <summary>
        /// Рекурсивный метод перебора массива.
        /// </summary>
        /// <param name="arr">Массив для перебора.</param>
        /// <param name="i">Количество чисел в массиве.</param>
        private static void Move(int[] arr, int i)
        {
            if (i < 1)
            {
                TaskSortClass.PrintArr(arr);
            }

            else
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    (arr[j], arr[i - 1]) = (arr[i - 1], arr[j]);
                    Move(arr, i - 1);
                    (arr[j], arr[i - 1]) = (arr[i - 1], arr[j]);
                }

            }

        }

        private static void Main()
        {
            int n = 5;
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            Move(arr, n);
        }

    }

}
