namespace Task2
{
    /// <summary>
    /// Структура Note.
    /// </summary>
    public struct Note
    {
        /// <summary>
        /// Gets or setsФамилия и имя.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or setsНомер телефона.
        /// </summary>
        public long Phone { get; set; }

        /// <summary>
        /// Gets or sets Дата рождения.
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Конструктор Note.
        /// </summary>
        /// <param name="surname">Фамилия и имя.</param>
        /// <param name="phone">Номер телефона.</param>
        /// <param name="birthdate">Дата рождения.</param>
        public Note(string surname, long phone, string birthdate)
        {
            Surname = surname;
            Phone = phone;
            BirthDate = birthdate;
        }

        /// <summary>
        /// Вывод структуры.
        /// </summary>
        public void PrintPerson()
        {
            Console.Write($"Фамилия, имя: {Surname}, " +
                          $"Номер телефона: {Phone}, " +
                          $"Дата рождения: {BirthDate}\n");

        }
    }
}
