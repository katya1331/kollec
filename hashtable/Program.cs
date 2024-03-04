using System;
using System.Collections;
using static System.Console;

namespace hashtable
{
    class PhoneBook
    {
        static Hashtable phoneBook = new Hashtable();

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                WriteLine("Выберите действие из списка:");
                WriteLine("1.Добавить контакт");
                WriteLine("2.Удалить контакт");
                WriteLine("3.Поиск номера телефона по фамилии");
                WriteLine("4.Поиск фамилии по номеру телефона");
                WriteLine("5.Выйти");
                WriteLine();
                Write("Введите номер выбранного действия: ");
                int choice = Convert.ToInt32(ReadLine());
                WriteLine();

                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        RemoveContact();
                        break;
                    case 3:
                        SearchPhoneNumber();
                        break;
                    case 4:
                        SearchName();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        WriteLine("Вы ввели что-то не то. Попробуйте еще раз");
                        break;
                }

                WriteLine();
            }
        }

        static void AddContact()
        {
            Write("Введите фамилию: ");
            string Name = ReadLine();

            Write("Введите номер телефона: ");
            string phoneNumber = ReadLine();

            phoneBook[Name] = phoneNumber;

            WriteLine("Контакт добавлен");
        }

        static void RemoveContact()
        {
            Write("Введите фамилию для удаления контакта: ");
            string Name = ReadLine();

            if (phoneBook.Contains(Name))
            {
                phoneBook.Remove(Name);
                WriteLine("Контакт успешно удален");
            }
            else
            {
                WriteLine("Контакт не найден");
            }
        }

        static void SearchPhoneNumber()
        {
            Write("Введите фамилию для поиска номера телефона: ");
            string Name = ReadLine();

            if (phoneBook.Contains(Name))
            {
                string phoneNumber = (string)phoneBook[Name];
                WriteLine($"Номер телефона для фамилии '{Name}': {phoneNumber}");
            }
            else
            {
                WriteLine("Контакт не найден");
            }
        }

        static void SearchName()
        {
            Write("Введите номер телефона, что бы мы могли найти фамилию фамилии: ");
            string phoneNumber = ReadLine();

            bool found = false;

            foreach (DictionaryEntry entry in phoneBook)
            {
                if (entry.Value.ToString() == phoneNumber)
                {
                    WriteLine($"Фамилия для номера телефона '{phoneNumber}': {entry.Key}");
                    found = true;
                }
            }

            if (!found)
            {
               WriteLine("Контакт не найден");
            }
        }
    }
}

