namespace Task164
{
    /// <summary>
    /// Задание 1.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Задание 1.
        /// </summary>
        public static void Main()
        {
            // Объявление конструктора.
            DayBefore dayBefore = new DayBefore();

            Console.WriteLine("Введите день:");
            dayBefore.Day = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите месяц:");
            dayBefore.Month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите год:");
            dayBefore.Year = int.Parse(Console.ReadLine());

            // Получение предыдущего дня.
            dayBefore.Day--;

            // Вывод даты.
            string info = dayBefore.ToString();
            Console.WriteLine(info);

            /*
            try
            {
                DateOnly someDay = new(dayBefore.Year,
                                       dayBefore.Month,
                                       dayBefore.Day);

                someDay = someDay.AddDays(-1);

                Console.WriteLine($"Предыдущий день: {someDay.ToLongDateString()}");
            }

            catch(Exception)
            {
                Console.WriteLine("Неверный формат даты");
            }
            */
        }
    }
}
