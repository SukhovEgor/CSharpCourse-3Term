namespace Task164
{
    /// <summary>
    /// Структура.
    /// </summary>
    public struct DayBefore
    {
        /// <summary>
        /// Gets or sets день.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Gets or sets месяц.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets Год.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        /// <returns>Дата.</returns>
        public override string ToString()
        {
            return $"Предыдущий день: {Day}.{Month}.{Year}";
        }
    }
}
