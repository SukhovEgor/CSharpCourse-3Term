using System.Numerics;
using System.Xml.Serialization;

namespace Task2
{
    /// <summary>
    /// Задание 2.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Задание 2.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Введите количество человек для записи");
            uint number = uint.Parse(Console.ReadLine());

            // Пути до файлов.
            string path = @"C:\Users\sukho\Desktop\учеба\3 семестр\ПиОА\Лабораторные работы\ЛР6\Файл данных.xml";
            string pathText = @"C:\Users\sukho\Desktop\учеба\3 семестр\ПиОА\Лабораторные работы\ЛР6\Note.txt";

            Note[] arrNote = CreateNotes(number);
            WriteXML(arrNote, path);
            PrintNote(ReadXML(path));
            SearchNote(arrNote);
            WriteTxt(SortNote(arrNote), pathText);
        }

        /// <summary>
        /// gerhuerg.
        /// </summary>
        /// <param name="number">fwsfsfd.</param>
        /// <returns>vssv.</returns>
        public static Note[] CreateNotes(uint number)
        {
            var arrNote = new Note[number];
            for (int i = 0; i < arrNote.Length; i++)
            {
                Console.WriteLine("Введите фамилию и имя:");
                arrNote[i].Surname = Console.ReadLine();

                Console.WriteLine("Введите номер телефона:");
                arrNote[i].Phone = long.Parse(Console.ReadLine());

                Console.WriteLine("Введите дату рождения " +
                                    "в формате dd.mm.yyyy:");
                arrNote[i].BirthDate = Console.ReadLine();
            }

            return arrNote;
        }

        /// <summary>
        /// Вывод данных.
        /// </summary>
        /// <param name="arrNote">Массив.</param>
        private static void PrintNote(Note[] arrNote)
        {
            Console.WriteLine("Информация о человеке:");
            foreach (var person in arrNote)
            {
                // Console.WriteLine(person)
                person.PrintPerson();
            }
        }

        /// <summary>
        /// Запись данных в XML файл.
        /// </summary>
        /// <param name="arrNote">Массив.</param>
        /// <param name="path">Путь.</param>
        private static void WriteXML(Note[] arrNote, string path)
        {
            // Удаление предущего XML файла.
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }

            // Создание объекта сериализации с типом данных структуры.
            XmlSerializer myNote = new XmlSerializer(typeof(Note[]));

            // Поток записи сериализованного объекта.
            using (FileStream fs = new FileStream(path,
                FileMode.Create))
            {
                myNote.Serialize(fs, arrNote);
            }

            Console.WriteLine("\n!Данные человека записаны в файл XML!");
        }

        /// <summary>
        /// Вывод данных из формата XML.
        /// </summary>
        /// <param name="path">Путь до файла.</param>
        /// <returns>Массив.</returns>
        private static Note[] ReadXML(string path)
        {
            Console.WriteLine("\n Данные из файла XML:");
            XmlSerializer myNote = new XmlSerializer(typeof(Note[]));

            // Десериализуем объект.
            using (FileStream fs = new FileStream(path,
                                        FileMode.OpenOrCreate))
            {
                Note[]? arrNote = myNote.Deserialize(fs) as Note[];
                return arrNote;
            }

        }

        /// <summary>
        /// Поиск данных по соответствии номера телефона.
        /// </summary>
        /// <param name="arrNote">Массив.</param>
        private static void SearchNote(Note[] arrNote)
        {
            var listNote = new List<Note>();

            Console.Write("\nКого вы хотите найти? ");
            long numberPhone = long.Parse(Console.ReadLine());

            Console.WriteLine("\nДанные человека:");
            foreach (var person in arrNote)
            {
                if (person.Phone == numberPhone)
                {
                    listNote.Add(person);
                    Console.WriteLine($"\tФамилия и имя - {person.Surname}" +
                                    $", Дата рождения - {person.BirthDate}");

                }

            }

            if (listNote.Count == 0)
            {
                Console.WriteLine("\nЧеловек не найден");
            }

        }

        /// <summary>
        /// Сортировка массива по дате.
        /// </summary>
        /// <param name="arrNote">Массив.</param>
        /// <returns>Список.</returns>
        private static List<Note> SortNote(Note[] arrNote)
        {
            // Сортировка по дате
            var noteSort = arrNote.OrderBy(x => DateTime.Parse(x.BirthDate));
            return noteSort.ToList();
        }

        /// <summary>
        /// Запись данных в txt файл.
        /// </summary>
        /// <param name="listNote">Список данных.</param>
        /// <param name="pathText">Путь до файла.</param>
        private static void WriteTxt(List<Note> listNote, string pathText)
        {
            foreach (var person in listNote)
            {
                File.AppendAllText(pathText,
                                    $"Фамилия, имя: {person.Surname}, " +
                                    $"Номер телефона: {person.Phone}, " +
                                    $"Дата рождения: {person.BirthDate}\n");
            }

            /*
            using (StreamWriter writer = new StreamWriter(pathText, true))
            {
                foreach (var person in listNote)
                {
                    writer.WriteLine(person);
                }
            }
            */
            Console.WriteLine("Список записан в файл (Note.txt)");
        }
    }
}
